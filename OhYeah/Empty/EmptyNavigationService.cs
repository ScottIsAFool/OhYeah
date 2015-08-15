using System;
using System.Collections.Generic;
using Cimbalino.Toolkit.Services;
using OhYeah.Core.Interfaces;

namespace OhYeah.Empty
{
    public class EmptyNavigationService : INavigation
    {
        public bool Navigate(string source)
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Uri source)
        {
            throw new NotImplementedException();
        }

        public bool Navigate<T>()
        {
            throw new NotImplementedException();
        }

        public bool Navigate<T>(object parameter)
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type type)
        {
            throw new NotImplementedException();
        }

        public bool Navigate(Type type, object parameter)
        {
            throw new NotImplementedException();
        }

        public void GoBack()
        {
            throw new NotImplementedException();
        }

        public void GoForward()
        {
            throw new NotImplementedException();
        }

        public bool RemoveBackEntry()
        {
            throw new NotImplementedException();
        }

        public Uri CurrentSource { get; }
        public IEnumerable<KeyValuePair<string, string>> QueryString { get; }
        public object CurrentParameter { get; }
        public bool CanGoBack { get; }
        public bool CanGoForward { get; }
        public event EventHandler Navigated;
        public event EventHandler<NavigationServiceBackKeyPressedEventArgs> BackKeyPressed;
        public bool NavigateToAccountsView()
        {
            throw new NotImplementedException();
        }

        public bool NavigateToSettingsView()
        {
            throw new NotImplementedException();
        }

        public bool NavigateToShareView(object parameter = null)
        {
            throw new NotImplementedException();
        }
    }
}
