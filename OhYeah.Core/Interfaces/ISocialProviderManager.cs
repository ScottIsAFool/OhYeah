using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Model;

namespace OhYeah.Core.Interfaces
{
    public interface ISocialProviderManager
    {
        ISocialProvider Facebook { get; }

        ISocialProvider Instagram { get; }

        List<ISocialProvider> Providers { get; }

        Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken));
    }
}
