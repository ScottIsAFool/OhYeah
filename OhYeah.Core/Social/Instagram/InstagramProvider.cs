using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;

namespace OhYeah.Core.Social.Instagram
{
    public class InstagramProvider : ISocialProvider
    {
        public string Name { get { return "Instagram"; } }
        public string AppId { get; private set; }
        public Task Authenticate()
        {
            throw new NotImplementedException();
        }

        public Task<List<OhYeahPost>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}
