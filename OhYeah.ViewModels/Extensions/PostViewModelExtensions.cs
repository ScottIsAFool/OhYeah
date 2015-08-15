using System.Collections.Generic;
using System.Linq;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Model;
using OhYeah.ViewModels.Entities;

namespace OhYeah.ViewModels.Extensions
{
    public static class PostViewModelExtensions
    {
        public static List<DateGroup<PostViewModel>> ToViewModelList(this List<DateGroup<OhYeahPost>> list, INavigation navigationService)
        {
            return list.Select(item => new DateGroup<PostViewModel>(item.Select(x => new PostViewModel(navigationService, x))) {Date = item.Date}).ToList();
        }
    }
}