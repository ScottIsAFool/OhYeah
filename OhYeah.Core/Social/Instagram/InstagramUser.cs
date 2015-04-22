using Newtonsoft.Json;
using PropertyChanged;

namespace OhYeah.Core.Social.Instagram
{
    [ImplementPropertyChanged]
    public class InstagramUser
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("username")]
        public string Username { get; set; }
        [JsonProperty("full_name")]
        public string FullName { get; set; }
        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }
    }
}