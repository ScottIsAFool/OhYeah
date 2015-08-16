using System.Collections.Generic;
using System.Linq;
using OhYeah.Core.Empty;
using OhYeah.Core.Interfaces;
using OhYeah.ViewModels.Entities;

namespace OhYeah.ViewModels
{
    public class AccountsViewModel : ViewModelBase
    {
        private readonly INavigation _navigationService;

        public AccountsViewModel(INavigation navigationService, ISocialProviderManager socialProviderManager)
        {
            _navigationService = navigationService;

            if (IsInDesignMode)
            {
                Providers = new List<SocialProviderViewModel>
                {
                    new SocialProviderViewModel(new EmptySocialProvider())
                };
            }
            else
            {
                Providers = socialProviderManager.Providers.Select(x => new SocialProviderViewModel(x)).ToList();
            }
        }

        public List<SocialProviderViewModel> Providers { get; }
    }
}
