using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OhYeah.Core.Empty;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Services;
using OhYeah.Extensions;
using OhYeah.Services;
using OhYeah.ViewModels;

namespace OhYeah.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        static ViewModelLocator()
        {
            LoadEverything();
        }

        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            LoadEverything();
        }

        private static void LoadEverything()
        {
            if (ServiceLocator.IsLocationProviderSet)
            {
                return;
            }

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.RegisterIf<ILauncherService, EmptyLauncherService>();
                SimpleIoc.Default.RegisterIf<IApplicationSettingsService, EmptyApplicationSettingsService>();
                SimpleIoc.Default.RegisterIf<INavigation, EmptyNavigationService>();
                SimpleIoc.Default.RegisterIf<ISocialProviderManager, EmptySocialProviderManager>();
            }
            else
            {
                SimpleIoc.Default.RegisterIf<ILauncherService, LauncherService>();
                SimpleIoc.Default.RegisterIf<IApplicationSettingsService, ApplicationSettingsService>();
                SimpleIoc.Default.RegisterIf<INavigation, Navigation>();
                SimpleIoc.Default.RegisterIf<ISocialProviderManager, SocialProviderManager>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<AccountsViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public AccountsViewModel Accounts => ServiceLocator.Current.GetInstance<AccountsViewModel>();

        public static INavigation NavigationService => ServiceLocator.Current.GetInstance<INavigation>();

        public static ISocialProviderManager SocialProviderManager => ServiceLocator.Current.GetInstance<ISocialProviderManager>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}