using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cleanTable_Mobile.Services;
using cleanTable_Mobile.Views;

namespace cleanTable_Mobile
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
