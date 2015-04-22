using Newtonsoft.Json;

namespace OhYeah.Core.Social.Facebook
{
    public class FacebookUser
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
