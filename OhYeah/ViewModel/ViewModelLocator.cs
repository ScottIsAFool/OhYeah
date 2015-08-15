using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Services;
using OhYeah.Empty;
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
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (GalaSoft.MvvmLight.ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.RegisterIf<IApplicationSettingsService, EmptyApplicationSettingsService>();
                SimpleIoc.Default.RegisterIf<INavigation, EmptyNavigationService>();
                SimpleIoc.Default.RegisterIf<ISocialProviderManager, EmptySocialProviderManager>();
            }
            else
            {
                SimpleIoc.Default.RegisterIf<IApplicationSettingsService, ApplicationSettingsService>();
                SimpleIoc.Default.RegisterIf<INavigation, Navigation>();
                SimpleIoc.Default.RegisterIf<ISocialProviderManager, SocialProviderManager>();
            }

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FacebookViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public FacebookViewModel Facebook => ServiceLocator.Current.GetInstance<FacebookViewModel>();

        public static INavigation NavigationService => ServiceLocator.Current.GetInstance<INavigation>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}