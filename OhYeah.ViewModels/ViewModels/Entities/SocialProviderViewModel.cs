using GalaSoft.MvvmLight.Command;
using OhYeah.Core.Extensions;
using OhYeah.Core.Interfaces;

namespace OhYeah.ViewModels.Entities
{
    public class SocialProviderViewModel : ViewModelBase
    {
        public SocialProviderViewModel(ISocialProvider socialProvider)
        {
            SocialProvider = socialProvider;
        }

        public ISocialProvider SocialProvider { get; }

        public bool IsSignedIn => SocialProvider.IsSignedIn;

        public string DisplayName => string.IsNullOrEmpty(SocialProvider.User?.Name) ? SocialProvider.User?.Username : SocialProvider.User.Name;

        public string ProviderLogo => SocialProvider?.Provider.GetLogo();

        public RelayCommand AuthenticateCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await SocialProvider.Authenticate();
                });
            }
        }

        public RelayCommand SignOutCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    await SocialProvider.SignOut();
                    RaisePropertyChanged(() => IsSignedIn);
                });
            }
        }
    }
}
