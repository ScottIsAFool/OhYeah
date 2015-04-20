using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
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

            SimpleIoc.Default.Register<MainViewModel>();
        }

        public MainViewModel Main
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainViewModel>();
            }
        }

        public static INavigationService NavigationService
        {
            get { return ServiceLocator.Current.GetInstance<INavigationService>(); }
        }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}