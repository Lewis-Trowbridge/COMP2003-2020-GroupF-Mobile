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
            //Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Shell.SetTabBarIsVisible(this, false);
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
