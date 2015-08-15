using OhYeah.Core.Model;

namespace OhYeah.Core.Extensions
{
    public static class ProviderExtensions
    {
        public static string GetLogo(this Provider provider) => $"ms-appx:///Assets/Providers/{provider}/Logo.png";
    }
}
