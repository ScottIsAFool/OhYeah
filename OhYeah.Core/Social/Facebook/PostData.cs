using System;
using Newtonsoft.Json;

namespace OhYeah.Core.Social.Facebook
{
    public class PostData
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("from")]
        public Author Author { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("created_time")]
        public DateTime CreatedTime { get; set; }

        [JsonProperty("updated_time")]
        public DateTime? UpdatedTime { get; set; }

        [JsonProperty("is_hidden")]
        public bool IsHidden { get; set; }

        [JsonProperty("subscribed")]
        public bool Subscribed { get; set; }
    }
}