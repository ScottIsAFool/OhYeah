using Cimbalino.Toolkit.Services;
using OhYeah.Core.Interfaces;
using OhYeah.Views;

namespace OhYeah.Services
{
    public class Navigation : NavigationService, INavigation
    {
        public bool NavigateToAccountsView()
        {
            return Navigate<AccountsView>();
        }

        public bool NavigateToSettingsView()
        {
            return Navigate<SettingsView>();
        }

        public bool NavigateToShareView(object parameter = null)
        {
            return Navigate<ShareView>(parameter);
        }
    }
}
