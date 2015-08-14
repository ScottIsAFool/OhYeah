using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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
        private const string DateFormat = "yyyy-MM-dd";
        private FacebookClient _facebookClient;
        public override string Name => "Facebook";
        public override string AppId => Constants.Api.Facebook.AppId;

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
                    var grouped = dateItem.Data.Select(x => x.ToPost()).GroupByDate(dateItem.Data[0].CreatedTime.Date);
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
    }
}
