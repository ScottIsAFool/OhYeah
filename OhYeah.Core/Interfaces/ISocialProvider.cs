using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Model;
using OhYeah.Core.Social;

namespace OhYeah.Core.Interfaces
{
    public interface ISocialProvider
    {
        event EventHandler<UserChangedEventArgs> UserChanged;
        string Name { get; }
        string AppId { get; }
        Provider Provider { get; }
        Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = default(CancellationToken));
        Task<User> GetUser(CancellationToken cancellationToken = default(CancellationToken));
        Task SetAuthenticationDetails(AuthenticationDetails authentication);
        Task Authenticate();
        Task CompleteAuthentication(string code);
        Task SignOut();
        bool IsSignedIn { get; }
        User User { get; }
    }
}
