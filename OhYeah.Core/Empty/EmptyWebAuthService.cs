using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using OhYeah.Core.Interfaces;

namespace OhYeah.Core.Empty
{
    public class EmptyWebAuthService : IWebAuthService
    {
        public Task<WebAuthenticationResult> Authenticate(Uri uri, Uri callbackUri = null)
        {
            return Task.FromResult<WebAuthenticationResult>(null);
        }
    }
}