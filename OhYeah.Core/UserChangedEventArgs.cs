using System;
using OhYeah.Core.Model;
using OhYeah.Core.Social;

namespace OhYeah.Core
{
    public class UserChangedEventArgs : EventArgs
    {
        public User User { get; private set; }
        public Provider Provider { get; private set; }

        internal UserChangedEventArgs(User user, Provider provider)
        {
            User = user;
            Provider = provider;
        }
    }
}