using System.Collections.Generic;
using Newtonsoft.Json;

namespace OhYeah.Core.Social.Facebook
{
    public class PostResponse
    {
        [JsonProperty("data")]
        public List<PostData> Data { get; set; }
    }
}
