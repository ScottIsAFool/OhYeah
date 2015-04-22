using Newtonsoft.Json;

namespace OhYeah.Core.Social.Facebook
{
    public class Author
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}