using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using Facebook;
using Facebook.Client;
using Newtonsoft.Json;
using OhYeah.Core.Extensions;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using ScottIsAFool.Windows.Core.Extensions;

namespace OhYeah.Core.Social.Facebook
{
    public class FacebookProvider : BaseSocialProvider, ISocialProvider
    {
        private readonly ILauncherService _launcherService;
        private const string FbConnectUri = "fbconnect://authorize?client_id={0}&scope={1}&redirect_uri=msft-{2}://authorize";
        private const string DateFormat = "yyyy-MM-dd";
        private FacebookClient _facebookClient;
        public override string Name => "Facebook";
        public override string AppId => Constants.Api.Facebook.AppId;
        public Provider Provider { get; } = Provider.Facebook;

        public FacebookProvider(
            IApplicationSettingsService applicationSettingsService,
            ILauncherService launcherService) 
            : base(applicationSettingsService)
        {
            _launcherService = launcherService;
        }

        protected override Task PostAuthenticationLoaded()
        {
            _facebookClient = new FacebookClient(AuthenticationDetails.AccessToken);
            return base.PostAuthenticationLoaded();
        }

        public async Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken))
        {
            if (!IsSignedIn)
            {
                return new List<DateGroup<OhYeahPost>>();
            }

            var today = DateTime.Now.Date;
            var days = today.GetPreviousYears()
                            .Select(day => string.Format(
                                Constants.Api.Facebook.ApiPath, 
                                AuthenticationDetails?.AccessToken, 
                                day.ToString(DateFormat), 
                                day.AddDays(1).ToString(DateFormat)))
                            .Select(path => new FacebookBatchParameter(path))
                            .ToArray();
            dynamic results = await _facebookClient.BatchTaskAsync(days);

            var groupList = new List<DateGroup<OhYeahPost>>();
            foreach (var result in results)
            {
                var item = result.ToString();
                PostResponse dateItem = JsonConvert.DeserializeObject<PostResponse>(item);
                if (!dateItem.Data.IsNullOrEmpty())
                {
                    var grouped = dateItem.Data.Where(x => string.IsNullOrEmpty(x.StatusType) || (!string.IsNullOrEmpty(x.StatusType) && !x.StatusType.Equals("created_note")))
                                               .Select(x => x.ToPost())
                                               .GroupByDate(dateItem.Data[0].CreatedTime.Date);
                    groupList.Add(grouped);
                }
            }

            return groupList;
        }

        public async Task<User> GetUser(CancellationToken cancellationToken = new CancellationToken())
        {
            dynamic result = await _facebookClient.GetTaskAsync("me");
            var fbUser = new GraphUser(result);
            return fbUser.ToUser();
        }

        public Task Authenticate()
        {
            var uri = GetConnectUri();

            return _launcherService.LaunchUriAsync(uri);
        }

        private string GetConnectUri()
        {
            return string.Format(FbConnectUri, Constants.Api.Facebook.AppId, "basic_info,publish_actions,user_posts", "a97700ab0b194661a12aa9a17bd385c1");
        }
    }
}
