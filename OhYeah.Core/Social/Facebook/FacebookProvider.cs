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

        public async Task<List<OhYeahPost>> GetPosts(CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var client = HttpClientHelper.Client())
            {
                var today = DateTime.Now.Date;
                var tomorrow = today.AddDays(1);

                var url = string.Format(Constants.Api.Facebook.ApiCall, today.ToString(DateFormat), tomorrow.ToString(DateFormat));
                var response = await client.GetAsync(url, cancellationToken);

                if (!response.IsSuccessStatusCode)
                {
                    return new List<OhYeahPost>();
                }

                var postResponse = await response.DeserialiseResponse<PostResponse>();

                return postResponse != null && postResponse.Data.IsNullOrEmpty()
                    ? postResponse.Data.Select(x => x.ToPost()).ToList() 
                    : new List<OhYeahPost>();
            }
        }
    }
}
