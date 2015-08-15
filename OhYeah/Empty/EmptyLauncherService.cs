using System;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;

namespace OhYeah.Empty
{
    public class EmptyLauncherService : ILauncherService
    {
        public Task LaunchUriAsync(Uri uri)
        {
            throw new NotImplementedException();
        }

        public Task LaunchUriAsync(string url)
        {
            throw new NotImplementedException();
        }

        public Task LaunchFileAsync(string file)
        {
            throw new NotImplementedException();
        }
    }
}