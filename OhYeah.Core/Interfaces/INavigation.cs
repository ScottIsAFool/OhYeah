using Cimbalino.Toolkit.Services;

namespace OhYeah.Core.Interfaces
{
    public interface INavigation : INavigationService
    {
        bool NavigateToAccountsView();
        bool NavigateToSettingsView();
        bool NavigateToShareView(object parameter = null);
    }
}