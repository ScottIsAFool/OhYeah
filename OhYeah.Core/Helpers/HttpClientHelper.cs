
using Windows.Web.Http;
using Windows.Web.Http.Filters;

namespace OhYeah.Core.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient Client()
        {
            return new HttpClient(new HttpBaseProtocolFilter { AutomaticDecompression = true });
        }
    }
}
