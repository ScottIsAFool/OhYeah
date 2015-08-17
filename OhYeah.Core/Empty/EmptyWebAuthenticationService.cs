using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;

namespace OhYeah.Core.Empty
{
    public class EmptyWebAuthenticationService : IWebAuthenticationBrokerService
    {
        public Task<WebAuthenticationResult> AuthenticateAsync(WebAuthenticationOptions options, Uri uri, Uri callbackUri = null)
        {
            throw new NotImplementedException();
        }

        public void AuthenticateAndContinue(Uri uri)
        {
            throw new NotImplementedException();
        }

        public void AuthenticateAndContinue(Uri uri, Uri callbackUri)
        {
            throw new NotImplementedException();
        }

        public void AuthenticateAndContinue(Uri uri, Uri callbackUri, Dictionary<string, object> valueSet, WebAuthenticationOptions options)
        {
            throw new NotImplementedException();
        }

        public Task<WebAuthenticationResult> AuthenticateSilentlyAsync(Uri uri, WebAuthenticationOptions? options = null)
        {
            throw new NotImplementedException();
        }

        public Uri GetCurrentApplicationCallbackUri()
        {
            throw new NotImplementedException();
        }
    }
}