using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using OhYeah.Core;

namespace OhYeah.ViewModel
{
    public class FacebookViewModel : ViewModelBase
    {
        private const string FbConnectUri = "fbconnect://authorize?client_id={0}&scope={1}&redirect_uri=msft-{2}://authorize";

        private readonly INavigationService _navigationService;

        public FacebookViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public RelayCommand AuthenticateCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var uri = GetConnectUri();

                    new LauncherService().LaunchUriAsync(uri);
                });
            }
        }

        private string GetConnectUri()
        {
            return string.Format(FbConnectUri, Constants.Api.Facebook.AppId, "basic_info,publish_actions,user_posts", "a97700ab0b194661a12aa9a17bd385c1");
        }
    }
}
