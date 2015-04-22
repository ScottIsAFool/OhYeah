namespace OhYeah.Core
{
    public static class Constants
    {
        public static class Api
        {
            public static class Facebook
            {
#if BETA
                public const string AppId = "764174377036247";
#else
                public const string AppId = "764173857036299";
#endif
                public const string ApiCall = "https://graph.facebook.com/v2.3/me/feed?since={0}&until={1}";
            }

            public static class Instagram
            {
                public const string ApiCall = "https://api.instagram.com/v1/users/{0}/media/recent/?access_token={1}&MIN_TIMESTAMP={2}&MAX_TIMESTAMP={3}";
            }
        }

        public static class Settings
        {
            
        }
    }
}
