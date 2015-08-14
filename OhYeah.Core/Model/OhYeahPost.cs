using System;
using OhYeah.Core.Social.Facebook;

namespace OhYeah.Core.Model
{
    public class OhYeahPost 
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string ImageUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public PostType PostType { get; set; }
    }
}