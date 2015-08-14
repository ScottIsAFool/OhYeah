using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Services;
using OhYeah.Extensions;

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

            SimpleIoc.Default.RegisterIf<INavigationService, NavigationService>();
            SimpleIoc.Default.RegisterIf<ISocialProviderManager, SocialProviderManager>();

            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<FacebookViewModel>();
        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        public FacebookViewModel Facebook => ServiceLocator.Current.GetInstance<FacebookViewModel>();

        public static INavigationService NavigationService => ServiceLocator.Current.GetInstance<INavigationService>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}