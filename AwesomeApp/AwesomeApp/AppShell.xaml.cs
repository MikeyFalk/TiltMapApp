using AwesomeApp.ViewModels;
using AwesomeApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AwesomeApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
            Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        }

    }
}
