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
                public const string ApiCall = "https://graph.facebook.com/v2.4/me/feed?access_token={0}&since={1}&until={2}&fields=icon,message,full_picture,type,status_type";
            }

            public static class Instagram
            {
                public const string ApiCall = "https://api.instagram.com/v1/users/self/media/recent/?access_token={0}&MIN_TIMESTAMP={1}&MAX_TIMESTAMP={2}";
                public const string AuthUrl = "https://api.instagram.com/oauth/authorize/?client_id={0}&redirect_uri={1}&response_type=code";//&scope=relationships";
                public const string TokenUrl = "https://api.instagram.com/oauth/access_token";
                public const string UserUrl = "https://api.instagram.com/v1/users/{0}/?access_token={1}";
                public const string RedirectUrl = "http://ferretlabs.com/ohyeah/instagram/";
#if BETA
                public const string AppId = "5425fd9760ba4863ac707c9e9e44c791";
                public const string Secret = "53b5b9fc3d3340e4be71041507d0b11f";
#else
                public const string AppId = "dbd10c0193ec47369276624bd6f74ca8";
                public const string Secret = "8bba8d4689b340adb66533247de68c34";
#endif
            }
        }

        public static class Settings
        {
            
        }
    }
}
