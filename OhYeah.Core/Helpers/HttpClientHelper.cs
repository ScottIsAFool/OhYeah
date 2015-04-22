using System.Net;
using System.Net.Http;

namespace OhYeah.Core.Helpers
{
    public static class HttpClientHelper
    {
        public static HttpClient Client()
        {
            return new HttpClient(new HttpClientHandler { AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip });
        }
    }
}
