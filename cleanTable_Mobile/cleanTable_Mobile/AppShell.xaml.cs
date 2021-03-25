using System;
using System.Collections.Generic;
using cleanTable_Mobile.ViewModels;
using cleanTable_Mobile.Views;
using Xamarin.Forms;

namespace cleanTable_Mobile
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(Homepage), typeof(Homepage));
            Routing.RegisterRoute(nameof(VenuePage), typeof(VenuePage));
            Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
            Shell.SetTabBarIsVisible(this, false);
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));



        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
         
        }
    }
}
