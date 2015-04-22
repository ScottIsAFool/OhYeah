using OhYeah.Core.Model;
using OhYeah.Core.Social.Facebook;

namespace OhYeah.Core.Extensions
{
    public static class PostExtensions
    {
        public static OhYeahPost ToPost(this PostData data)
        {
            return new OhYeahPost();
        }
    }
}
