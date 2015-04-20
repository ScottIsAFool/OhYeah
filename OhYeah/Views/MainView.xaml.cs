using Cimbalino.Toolkit.Services;
using OhYeah.ViewModel;

namespace OhYeah.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainView
    {
        public MainView()
        {
            InitializeComponent();
        }

        public override INavigationService NavigationService
        {
            get { return ViewModelLocator.NavigationService; }
        }
    }
}
