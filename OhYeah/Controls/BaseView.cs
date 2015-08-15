using Cimbalino.Toolkit.Services;
using OhYeah.ViewModel;
using ScottIsAFool.Windows.Controls;

namespace OhYeah.Controls
{
    public class BaseView : BasePage
    {
        public override INavigationService NavigationService { get; } = ViewModelLocator.NavigationService;
    }
}
