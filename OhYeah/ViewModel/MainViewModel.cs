using Cimbalino.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using OhYeah.Core.Interfaces;

namespace OhYeah.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly ISocialProviderManager _socialProviderManager;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigationService navigationService, ISocialProviderManager socialProviderManager)
        {
            _navigationService = navigationService;
            _socialProviderManager = socialProviderManager;
        }

        public RelayCommand PageLoadedCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var posts = await _socialProviderManager.GetPosts();
                    if (posts != null)
                    {
                        
                    }
                });
            }
        }
    }
}