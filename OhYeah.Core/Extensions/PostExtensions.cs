using System;
using System.Collections.Generic;
using OhYeah.Core.Model;

namespace OhYeah.Core.Extensions
{
    public static class PostExtensions
    {
        public static OhYeahPost ToPost(this Social.Facebook.PostData data)
        {
            return new OhYeahPost();
        }

        //public static OhYeahPost ToPost(this Social.Instagram.PostData data)
        //{
        //    return new OhYeahPost();
        //}

        public static DateGroup<OhYeahPost> GroupByDate(this IEnumerable<OhYeahPost> items, DateTime today)
        {
            var postGroup = new DateGroup<OhYeahPost>(items) { Date = today };
            return postGroup;
        }
    }
}
