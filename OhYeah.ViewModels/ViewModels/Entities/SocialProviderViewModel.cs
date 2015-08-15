using GalaSoft.MvvmLight.Command;
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
    }
}
