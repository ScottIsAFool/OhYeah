using GalaSoft.MvvmLight.Command;
using OhYeah.Core.Extensions;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;

namespace OhYeah.ViewModels.Entities
{
    public class PostViewModel : ViewModelBase
    {
        private readonly INavigation _navigationService;

        public PostViewModel(INavigation navigationService, OhYeahPost post)
        {
            Post = post;
            _navigationService = navigationService;
        }

        public OhYeahPost Post { get; set; }

        public string ProviderLogo => Post?.Provider.GetLogo();

        public RelayCommand ShareCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateToShareView(Post);
                });
            }
        }

        public RelayCommand AndNowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    
                });
            }
        }
    }
}
