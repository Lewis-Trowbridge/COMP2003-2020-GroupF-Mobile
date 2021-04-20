using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using cleanTable_Mobile.ViewModels;

namespace cleanTable_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        HomepageViewModel data = new HomepageViewModel();
        public Homepage()
        {
            InitializeComponent();
        }
        async void ButtonClicked(object sender, EventArgs e)
        {
           // await Shell.Current.GoToAsync($"{nameof(VenuePage)}");
            await ((Shell)Application.Current.MainPage).GoToAsync($"//Homepage/VenuePage");

        }
        async void DeleteClicked(object sender, EventArgs e)
        {
            await ((Shell)Application.Current.MainPage).GoToAsync($"//Homepage/CustomerDelete");
        }

        private void AddButton(object sender, EventArgs e)
        {
            Button venueName = new Button();
            
            
        }
    }
}