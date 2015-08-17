using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Windows.Web.Http;
using Cimbalino.Toolkit.Services;
using Newtonsoft.Json;
using OhYeah.Core.Extensions;
using OhYeah.Core.Helpers;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using ScottIsAFool.Windows.Core.Extensions;

namespace OhYeah.Core.Social.Instagram
{
    public class InstagramProvider : BaseSocialProvider
    {
        private readonly IWebAuthService _webAuthenticationBroker;
        private const string AuthUrl = "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code";//&scope=relationships";
        private const string TokenUrl = "https://api.instagram.com/oauth/access_token";

        public override string Name => "Instagram";
        public override string AppId => Constants.Api.Instagram.AppId;
        public override Provider Provider { get; } = Provider.Instagram;

        public InstagramProvider(
            IApplicationSettingsService applicationSettingsService,
            IWebAuthService webAuthenticationBroker) : base(applicationSettingsService)
        {
            _webAuthenticationBroker = webAuthenticationBroker;
        }

        public override Task Authenticate()
        {
            var url = string.Format(AuthUrl, Constants.Api.Instagram.AppId, Constants.Api.Instagram.RedirectUrl);

            _webAuthenticationBroker.Authenticate(new Uri(url), new Uri(Constants.Api.Instagram.RedirectUrl));

            return base.Authenticate();
        }

        public override async Task CompleteAuthentication(string code)
        {
            var args = GetAuthParams(code);
            using (var client = HttpClientHelper.Client())
            {
                var response = await client.PostAsync(new Uri(TokenUrl), new HttpFormUrlEncodedContent(args));

                if (response.StatusCode == HttpStatusCode.Ok)
                {
                    var responseString = await response.Content.ReadAsStringAsync();
                    if (!string.IsNullOrEmpty(responseString))
                    {
                        var userResponse = JsonConvert.DeserializeObject<InstagramTokenResponse>(responseString);
                        SetUser(userResponse.User.ToUser());
                        await SetAuthenticationDetails(new AuthenticationDetails {AccessToken = userResponse.AccessToken});
                    }
                }
            }
        }

        public override async Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            var today = DateTime.Now.Date;
            var tasks = today.GetPreviousYears().Select(x => GetPosts(cancellationToken, x));
            var groups = await Task.WhenAll(tasks);
            return groups != null ? groups.Where(x => x.Date != DateTime.MinValue).ToList() : new List<DateGroup<OhYeahPost>>();
        }

        public override Task<Social.User> GetUser(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult<Social.User>(null);
        }

        private async Task<DateGroup<OhYeahPost>> GetPosts(CancellationToken cancellationToken, DateTime today)
        {
            if (!IsSignedIn)
            {
                return new DateGroup<OhYeahPost>();
            }

            var tomorrow = today.AddDays(1);
            using (var client = HttpClientHelper.Client())
            {
                var url = string.Format(Constants.Api.Instagram.ApiCall.ToLower(), AuthenticationDetails.AccessToken, today.ToEpoch(), tomorrow.ToEpoch());
                var response = await client.GetAsync(new Uri(url)).AsTask(cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    return new DateGroup<OhYeahPost>();
                }

                var postResponse = await response.DeserialiseResponse<PostResponse>();

                if (postResponse != null && !postResponse.Data.IsNullOrEmpty())
                {
                    return postResponse.Data.Select(x => x.ToPost()).GroupByDate(today);
                }

                return new DateGroup<OhYeahPost>();
            }
        }

        private static Dictionary<string, string> GetAuthParams(string code)
        {
            return new Dictionary<string, string>
            {
                {"client_id", Constants.Api.Instagram.AppId},
                {"client_secret", Constants.Api.Instagram.Secret},
                {"grant_type", "authorization_code"},
                {"redirect_uri", Constants.Api.Instagram.RedirectUrl},
                {"code", code}
            };
        }
    }
}
