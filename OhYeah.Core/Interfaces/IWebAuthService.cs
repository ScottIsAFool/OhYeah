using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;

namespace OhYeah.Core.Interfaces
{
    public interface IWebAuthService
    {
        Task<WebAuthenticationResult> Authenticate(Uri uri, Uri callbackUri = null);
    }
}
