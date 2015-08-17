using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using OhYeah.Core.Interfaces;

namespace OhYeah.Services
{
    public class WebAuthService : IWebAuthService
    {
        private readonly IWebAuthenticationBrokerService _webAuthenticationBroker = new WebAuthenticationBrokerService();

        public Task<WebAuthenticationResult> Authenticate(Uri uri, Uri callbackUri = null)
        {
            _webAuthenticationBroker.AuthenticateAndContinue(uri, callbackUri);

            return Task.FromResult<WebAuthenticationResult>(null);
        }
    }
}
