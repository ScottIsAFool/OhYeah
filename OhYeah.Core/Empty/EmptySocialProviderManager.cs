using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;

namespace OhYeah.Core.Empty
{
    public class EmptySocialProviderManager : ISocialProviderManager
    {
        public ISocialProvider Facebook { get; }
        public ISocialProvider Instagram { get; }
        public List<ISocialProvider> Providers { get; }

        public Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(new List<DateGroup<OhYeahPost>>());
        }
    }
}