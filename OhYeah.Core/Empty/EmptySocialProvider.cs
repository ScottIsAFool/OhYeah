using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using OhYeah.Core.Social;

namespace OhYeah.Core.Empty
{
    public class EmptySocialProvider : ISocialProvider
    {
        public string Name { get; } = "Design time";
        public string AppId { get; }
        public Provider Provider { get; } = Provider.Facebook;
        public Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUser(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public void SaveAuthDetails()
        {
            throw new NotImplementedException();
        }

        public void LoadAuthDetails()
        {
            throw new NotImplementedException();
        }

        public void ClearAuthDetails()
        {
            throw new NotImplementedException();
        }

        public bool IsSignedIn { get; }
        public User User { get; }
    }
}
