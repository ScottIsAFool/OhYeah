using Facebook.Client;
using OhYeah.Core.Social.Instagram;
using User = OhYeah.Core.Social.User;

namespace OhYeah.Core.Extensions
{
    public static class UserExtensions
    {
        public static User ToUser(this InstagramUser item)
        {
            return new User
            {
                Id = item.Id,
                Name = item.FullName,
                ProfilePicture = item.ProfilePicture
            };
        }

        public static User ToUser(this GraphUser item)
        {
            return new User
            {
                Id = item.Id,
                Name = item.Name,
                Username = item.UserName,
                ProfilePicture = $"http://graph.facebook.com/{item.Id}/picture?height=300"
            };
        }
    }
}