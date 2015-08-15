using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Model;
using OhYeah.Core.Social;

namespace OhYeah.Core.Interfaces
{
    public interface ISocialProvider
    {
        string Name { get; }
        string AppId { get; }
        Provider Provider { get; }
        Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken));
        Task<User> GetUser(CancellationToken cancellationToken = default(CancellationToken));
        Task Authenticate();
        void SaveAuthDetails();
        void LoadAuthDetails();
        void ClearAuthDetails();
        bool IsSignedIn { get; }
        User User { get; }
    }
}
