using System.Net.Http;
using System.Threading.Tasks;

namespace OhYeah.Core.Extensions
{
    public static class HttpExtensions
    {
        public static async Task<TReturnType> DeserialiseResponse<TReturnType>(this HttpResponseMessage message)
        {
            var content = await message.Content.ReadAsStringAsync();

            return await content.DeserialiseAsync<TReturnType>();
        }
    }
}
