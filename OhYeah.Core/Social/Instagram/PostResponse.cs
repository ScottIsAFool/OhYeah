using Newtonsoft.Json;

namespace OhYeah.Core.Social.Instagram
{
    public class Caption
    {
        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("text")]
        public string Text { get; set; }

        [JsonProperty("from")]
        public User From { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class User
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("profile_picture")]
        public string ProfilePicture { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }

    public class Image
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }
    }

    public class Images
    {
        [JsonProperty("low_resolution")]
        public Image LowResolution { get; set; }

        [JsonProperty("thumbnail")]
        public Image Thumbnail { get; set; }

        [JsonProperty("standard_resolution")]
        public Image StandardResolution { get; set; }
    }

    public class Location
    {
        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("street_address")]
        public string StreetAddress { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class Videos
    {
        [JsonProperty("low_resolution")]
        public Image LowResolution { get; set; }

        [JsonProperty("standard_resolution")]
        public Image StandardResolution { get; set; }

        [JsonProperty("caption")]
        public Caption Caption { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("users_in_photo")]
        public User[] UsersInPhoto { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("tags")]
        public object[] Tags { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }
    }

    public class PostData
    {
        [JsonProperty("caption")]
        public Caption Caption { get; set; }

        [JsonProperty("link")]
        public string Link { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("created_time")]
        public string CreatedTime { get; set; }

        [JsonProperty("images")]
        public Images Images { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("users_in_photo")]
        public User[] UsersInPhoto { get; set; }

        [JsonProperty("filter")]
        public string Filter { get; set; }

        [JsonProperty("tags")]
        public string[] Tags { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("location")]
        public Location Location { get; set; }

        [JsonProperty("videos")]
        public Videos Videos { get; set; }
    }

    public class PostResponse
    {
        [JsonProperty("data")]
        public PostData[] Data { get; set; }
    }

}
