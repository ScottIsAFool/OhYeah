//using PropertyChanged;

namespace OhYeah.Core.Social
{
    //[ImplementPropertyChanged]
    public abstract class BaseSocialProvider
    {
        public User User { get; private set; }
        public bool IsSignedIn { get; private set; }


        public void SetUser(User user)
        {
            User = user;
        }
    }
}
