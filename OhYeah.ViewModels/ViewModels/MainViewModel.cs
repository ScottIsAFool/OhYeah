using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using OhYeah.Core.Social;
using OhYeah.Core.Social.Facebook;
using OhYeah.ViewModels.Entities;
using OhYeah.ViewModels.Extensions;

namespace OhYeah.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigation _navigationService;
        private readonly ISocialProviderManager _socialProviderManager;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(INavigation navigationService, ISocialProviderManager socialProviderManager)
        {
            _navigationService = navigationService;
            _socialProviderManager = socialProviderManager;

            if (IsInDesignMode)
            {
                Posts = new DateGroup<DateGroup<PostViewModel>>
                {
                    new DateGroup<PostViewModel>(new List<PostViewModel>
                    {
                        new PostViewModel(navigationService, new OhYeahPost
                        {
                            Message = "This is just some sample text that I hope will run over into the next line. Phew.",
                            CreatedDate = DateTime.Now.Date,
                            ImageUrl = "http://kopy-right.com/wp-content/uploads/2015/02/deadpool-logo-1-940x949.jpg",
                            PostType = PostType.Photo,
                            Provider = Provider.Facebook
                        })
                    })
                    {
                        Date = DateTime.Now.AddYears(-1)
                    }
                };
            }
        }

        public List<DateGroup<PostViewModel>> Posts { get; set; }

        public RelayCommand PageLoadedCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    var posts = await _socialProviderManager.GetPosts();
                    if (posts != null)
                    {
                        Posts = posts.ToViewModelList(_navigationService);
                    }
                });
            }
        }

        public RelayCommand NavigateToAccountsViewCommand
        {
            get
            {
                return new RelayCommand(() => _navigationService.NavigateToAccountsView());
            }
        }

        public RelayCommand NavigateToSettingsViewCommand
        {
            get
            {
                return new RelayCommand(() =>_navigationService.NavigateToSettingsView());
            }
        }
    }
}