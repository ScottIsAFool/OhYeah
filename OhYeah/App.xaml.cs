using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Security.Authentication.Web;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using GalaSoft.MvvmLight.Ioc;
using OhYeah.Core;
using OhYeah.Core.Interfaces;
using OhYeah.Core.Social;
using OhYeah.ViewModel;
using OhYeah.Views;
using ScottIsAFool.Windows.Core.Extensions;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace OhYeah
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    public sealed partial class App
    {
        private TransitionCollection transitions;

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            InitializeComponent();
            Suspending += OnSuspending;
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs e)
        {
#if DEBUG
            if (Debugger.IsAttached)
            {
                DebugSettings.EnableFrameRateCounter = true;
            }
#endif

            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // TODO: change this value to a cache size that is appropriate for your application
                rootFrame.CacheSize = 1;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // TODO: Load state from previously suspended application
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // Removes the turnstile navigation for startup.
                if (rootFrame.ContentTransitions != null)
                {
                    transitions = new TransitionCollection();
                    foreach (var c in rootFrame.ContentTransitions)
                    {
                        transitions.Add(c);
                    }
                }

                rootFrame.ContentTransitions = null;
                rootFrame.Navigated += RootFrame_FirstNavigated;

                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainView), e.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }

            // Ensure the current window is active
            Window.Current.Activate();
        }

        protected override async void OnActivated(IActivatedEventArgs args)
        {
            base.OnActivated(args);

            if (args.Kind == ActivationKind.Protocol)
            {
                var eventArgs = args as ProtocolActivatedEventArgs;
                if (eventArgs != null)
                {
                    var uri = eventArgs.Uri;
                    var query = uri.QueryDictionary();

                    if (query.ContainsKey("state") && query["state"] == "facebook")
                    {
                        var accessToken = query["access_token"];
                        var manager = ViewModelLocator.SocialProviderManager;
                        await manager.Facebook.SetAuthenticationDetails(new AuthenticationDetails {AccessToken = accessToken});
                        await manager.Facebook.GetUser();
                    }
                }
            }
            else if (args.Kind == ActivationKind.WebAuthenticationBrokerContinuation)
            {
                var continuationArgs = args as IContinuationActivatedEventArgs;
                var brokerArgs = continuationArgs as IWebAuthenticationBrokerContinuationEventArgs;
                if (brokerArgs?.WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
                {
                    var url = brokerArgs.WebAuthenticationResult.ResponseData;
                    if (url.Contains("instagram"))
                    {
                        var uri = new Uri(url);
                        var query = uri.QueryDictionary();

                        var code = query["code"];

                        var instagramProvider = SimpleIoc.Default.GetInstance<ISocialProviderManager>().Instagram;
                        await instagramProvider.CompleteAuthentication(code);
                    }
                }
            }
        }

        /// <summary>
        /// Restores the content transitions after the app has launched.
        /// </summary>
        /// <param name="sender">The object where the handler is attached.</param>
        /// <param name="e">Details about the navigation event.</param>
        private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
        {
            var rootFrame = sender as Frame;
            rootFrame.ContentTransitions = transitions ?? new TransitionCollection { new NavigationThemeTransition() };
            rootFrame.Navigated -= RootFrame_FirstNavigated;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();

            // TODO: Save application state and stop any background activity
            deferral.Complete();
        }
    }
}