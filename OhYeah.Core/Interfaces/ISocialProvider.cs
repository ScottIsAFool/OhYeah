using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Model;

namespace OhYeah.Core.Interfaces
{
    public interface ISocialProvider
    {
        string Name { get; }
        string AppId { get; }
        Task Authenticate();
        Task<List<OhYeahPost>> GetPosts(CancellationToken cancellationToken = default(CancellationToken));
    }
}
