using System;
using System.Collections.Generic;
using OhYeah.Core.Model;
using OhYeah.Core.Social;

namespace OhYeah.Core.Extensions
{
    public static class PostExtensions
    {
        public static OhYeahPost ToPost(this Social.Facebook.PostData data)
        {
            return new OhYeahPost
            {
                CreatedDate = data.CreatedTime,
                Message = data.Message,
                PostType = data.Type,
                ImageUrl = data.ImageUrl,
                Provider = Provider.Facebook
            };
        }

        public static OhYeahPost ToPost(this Social.Instagram.PostData data)
        {
            return new OhYeahPost
            {
                CreatedDate = data.CreatedTime.FromEpoch(),
                Message = data.Caption?.Text,
                PostType = PostType.Photo,
                ImageUrl = data.Images?.StandardResolution?.Url,
                Provider = Provider.Instagram
            };
        }

        public static DateGroup<OhYeahPost> GroupByDate(this IEnumerable<OhYeahPost> items, DateTime today)
        {
            var postGroup = new DateGroup<OhYeahPost>(items) { Date = today };
            return postGroup;
        }
    }
}
