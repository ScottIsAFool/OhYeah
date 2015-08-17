using Newtonsoft.Json;
using PropertyChanged;

namespace OhYeah.Core.Social.Instagram
{
    [ImplementPropertyChanged]
    public class InstagramTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
        [JsonProperty("user")]
        public InstagramUser User { get; set; }
    }
}
