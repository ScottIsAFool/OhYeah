using Cimbalino.Toolkit.Services;

namespace OhYeah.Core.Services
{
    public class AuthenticationService
    {
        private readonly IApplicationSettingsService _settingsService;
        public static AuthenticationService Current { get; private set; }

        public AuthenticationService(IApplicationSettingsService settingsService)
        {
            _settingsService = settingsService;
        }
    }
}
