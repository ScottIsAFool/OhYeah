using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using OhYeah.Core.Extensions;
using OhYeah.Core.Helpers;
using OhYeah.Core.Model;
using ScottIsAFool.Windows.Core.Extensions;

namespace OhYeah.Core.Social.Instagram
{
    public class InstagramProvider : BaseSocialProvider
    {
        public override string Name => "Instagram";
        public override string AppId => Constants.Api.Instagram.AppId;
        public override Provider Provider { get; } = Provider.Instagram;

        public InstagramProvider(IApplicationSettingsService applicationSettingsService) : base(applicationSettingsService) { }

        public override async Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            var today = DateTime.Now.Date;
            var tasks = today.GetPreviousYears().Select(x => GetPosts(cancellationToken, x));
            var groups = await Task.WhenAll(tasks);
            return groups != null ? groups.ToList() : new List<DateGroup<OhYeahPost>>();
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
                var url = string.Format(Constants.Api.Instagram.ApiCall, "ACCESSTOKEN", today.ToEpoch(), tomorrow.ToEpoch());
                var response = await client.GetAsync(url, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    return new DateGroup<OhYeahPost>();
                }

                var postResponse = await response.DeserialiseResponse<PostResponse>();

                if (postResponse != null && postResponse.Data.IsNullOrEmpty())
                {
                    return postResponse.Data.Select(x => x.ToPost()).GroupByDate(today);
                }

                return new DateGroup<OhYeahPost>();
            }
        }
    }
}
