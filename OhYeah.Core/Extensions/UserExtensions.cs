using Facebook.Client;
using OhYeah.Core.Social;
//using OhYeah.Core.Social.Instagram;

namespace OhYeah.Core.Extensions
{
    public static class UserExtensions
    {
        //public static User ToUser(this InstagramUser item)
        //{
        //    return new User
        //    {
        //        Id = item.Id,
        //        Name = item.FullName,
        //        ProfilePicture = item.ProfilePicture
        //    };
        //}

        public static User ToUser(this GraphUser item)
        {
            return new User
            {
                Id = item.Id,
                Name = item.Name,
                ProfilePicture = string.Format("http://graph.facebook.com/{0}/picture?height=300", item.Id)
            };
        }
    }
}