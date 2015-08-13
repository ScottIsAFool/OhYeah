﻿using Cimbalino.Toolkit.Services;
using Newtonsoft.Json;

namespace OhYeah.Core.Social
{
    public abstract class BaseSocialProvider
    {
        protected static readonly IApplicationSettingsServiceHandler Settings = new ApplicationSettingsService().Roaming;
        public virtual string Name { get; } = string.Empty;
        public virtual string AppId { get; } = string.Empty;
        public User User { get; private set; }
        public bool IsSignedIn => User != null || !string.IsNullOrEmpty(AuthenticationDetails?.AccessToken);
        public AuthenticationDetails AuthenticationDetails { get; private set; }

        protected BaseSocialProvider()
        {
            LoadAuthDetails();
            LoadUser();
        }

        #region Save/Load/Clear user
        public void SetUser(User user)
        {
            User = user;
            SaveUser();
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
        public void SaveAuthDetails()
        {
            Save(AuthenticationDetails, AuthKey);
        }

        public void LoadAuthDetails()
        {
#if DEBUG
            AuthenticationDetails = new AuthenticationDetails {AccessToken = "CAAK3AxdLmAsBAH6RxlS6wxvZA6NCnTG2igSeQKNC2zAlRYsreKsm3oyJv0aWPyVbFtlx35jWZALy3ezLI8pAxD5qMxX4FFUhmyKJ2t2xvUcZCRYOO8brc94bLCNu01EaOjE3lNcw5LvbMvAVS5TwAVeTseShfKxU9FrL3EYHCE7ZBj5oeJrrsBx8V9Lj0UYbtC3WwvhU3AZDZD"};
#else
            AuthenticationDetails = Load<AuthenticationDetails>(AuthKey);
#endif
        }

        public void ClearAuthDetails()
        {
            Clear(AuthKey);
        }
#endregion

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