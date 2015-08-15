using System.Collections.Generic;
using System.Linq;
using Cimbalino.Toolkit.Services;
using OhYeah.Core.Interfaces;
using OhYeah.ViewModels.Entities;

namespace OhYeah.ViewModels
{
    public class AccountsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public AccountsViewModel(INavigationService navigationService, ISocialProviderManager socialProviderManager)
        {
            _navigationService = navigationService;

            Providers = socialProviderManager.Providers.Select(x => new SocialProviderViewModel(x)).ToList();
        }

        public List<SocialProviderViewModel> Providers { get; }
    }
}
