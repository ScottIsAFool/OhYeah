using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Extensions;
using OhYeah.Core.Helpers;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using ScottIsAFool.Windows.Core.Extensions;

namespace OhYeah.Core.Social.Facebook
{
    public class FacebookProvider : ISocialProvider
    {
        private const string DateFormat = "yyyy-mm-dd";
        public string Name { get { return "Facebook"; } }
        public string AppId { get { return Constants.Api.Facebook.AppId; } }

        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public async Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken))
        {
            var today = DateTime.Now.Date;
            var tasks = today.GetPreviousYears().Select(x => GetPosts(cancellationToken, x));
            var groups = await Task.WhenAll(tasks);
            return groups != null ? groups.ToList() : new List<DateGroup<OhYeahPost>>();
        }

        private static async Task<DateGroup<OhYeahPost>> GetPosts(CancellationToken cancellationToken, DateTime today)
        {
            var tomorrow = today.AddDays(1);
            using (var client = HttpClientHelper.Client())
            {
                var url = string.Format(Constants.Api.Facebook.ApiCall, today.ToString(DateFormat), tomorrow.ToString(DateFormat));
                var response = await client.GetAsync(url, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    return new DateGroup<OhYeahPost>();
                }

                var postResponse = await response.DeserialiseResponse<PostResponse>();

                if (postResponse != null && postResponse.Data.IsNullOrEmpty())
                {
                    return postResponse.Data.Select(x => x.ToPost()).Group(today);
                }

                return new DateGroup<OhYeahPost>();
            }
        }

        public Task<User> GetUser(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult<User>(null);
        }
    }
}
