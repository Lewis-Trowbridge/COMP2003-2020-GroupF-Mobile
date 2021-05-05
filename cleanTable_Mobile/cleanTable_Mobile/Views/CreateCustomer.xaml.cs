using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cleanTable_Mobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateCustomer : ContentPage
    {
        public CreateCustomer()
        {
            InitializeComponent();
        }
        async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}