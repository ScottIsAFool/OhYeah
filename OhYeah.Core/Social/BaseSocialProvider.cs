using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cimbalino.Toolkit.Services;
using Newtonsoft.Json;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using PropertyChanged;

namespace OhYeah.Core.Social
{
    [ImplementPropertyChanged]
    public abstract class BaseSocialProvider : ISocialProvider
    {
        protected readonly IApplicationSettingsServiceHandler Settings;

        protected BaseSocialProvider(IApplicationSettingsService applicationSettingsService)
        {
            Settings = applicationSettingsService.Roaming;
            LoadAuthDetails();
            LoadUser();
        }

        public event EventHandler<UserChangedEventArgs> UserChanged;
        public virtual string Name { get; } = string.Empty;
        public virtual string AppId { get; } = string.Empty;
        public virtual Provider Provider { get; }
        public virtual User User { get; protected set; }
        public bool IsSignedIn => User != null || !string.IsNullOrEmpty(AuthenticationDetails?.AccessToken);
        public AuthenticationDetails AuthenticationDetails { get; private set; }

        public virtual Task<List<DateGroup<OhYeahPost>>> GetPosts(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(new List<DateGroup<OhYeahPost>>());
        }

        public virtual Task<User> GetUser(CancellationToken cancellationToken = new CancellationToken())
        {
            return Task.FromResult(new User());
        }

        public virtual async Task Authenticate()
        {
            if (AuthenticationDetails != null)
            {
                await GetUser();
            }
        }

        public virtual Task CompleteAuthentication(string code)
        {
            return Task.FromResult(0);
        }

        public virtual Task SignOut()
        {
            ClearAuthDetails();
            ClearUser();
            return Task.FromResult(0);
        }

        #region Save/Load/Clear user
        public void SetUser(User user)
        {
            User = user;
            SaveUser();

            var eventHandler = UserChanged;
            eventHandler?.Invoke(this, new UserChangedEventArgs(User, Provider));
        }

        public void SaveUser()
        {
            Save(User, UserKey);
        }

        public void LoadUser()
        {
            User = Load<User>(UserKey);
        }

        public void ClearUser()
        {
            Clear(UserKey);
        }
        #endregion

        #region Save/Load/Clear auth

        public async Task SetAuthenticationDetails(AuthenticationDetails authentication)
        {
            AuthenticationDetails = authentication;
            SaveAuthDetails();
            await PostAuthenticationLoaded();
        }

        public void SaveAuthDetails()
        {
            Save(AuthenticationDetails, AuthKey);
        }

        public void LoadAuthDetails()
        {
//#if DEBUG
//            AuthenticationDetails = new AuthenticationDetails {AccessToken = "CAAK3AxdLmAsBAH6RxlS6wxvZA6NCnTG2igSeQKNC2zAlRYsreKsm3oyJv0aWPyVbFtlx35jWZALy3ezLI8pAxD5qMxX4FFUhmyKJ2t2xvUcZCRYOO8brc94bLCNu01EaOjE3lNcw5LvbMvAVS5TwAVeTseShfKxU9FrL3EYHCE7ZBj5oeJrrsBx8V9Lj0UYbtC3WwvhU3AZDZD"};
//#else
            AuthenticationDetails = Load<AuthenticationDetails>(AuthKey);
//#endif

            if (AuthenticationDetails != null)
            {
                PostAuthenticationLoaded();
            }
        }

        public void ClearAuthDetails()
        {
            AuthenticationDetails = null;
            Clear(AuthKey);
        }
#endregion

        protected virtual Task PostAuthenticationLoaded()
        {
            return Task.FromResult(0);
        }

        #region Common save/load/clear methods
        private void Clear(string key)
        {
            if (Settings.Contains(key))
            {
                Settings.Remove(key);
            }
        }

        private void Save<T>(T item, string key)
        {
            if (item == null)
            {
                return;
            }

            var json = JsonConvert.SerializeObject(item);
            Settings.Set(key, json);
        }

        private T Load<T>(string key)
        {
            if (Settings.Contains(key))
            {
                var json = Settings.Get(key, string.Empty);
                if (!string.IsNullOrEmpty(json))
                {
                    var savedItem = JsonConvert.DeserializeObject<T>(json);
                    return savedItem;
                }
            }

            return default(T);
        }
#endregion

        private string AuthKey => $"{Name}AuthenticationKey";
        private string UserKey => $"{Name}UserKey";
    }

    public class AuthenticationDetails
    {
        public string AccessToken { get; set; }
    }
}
