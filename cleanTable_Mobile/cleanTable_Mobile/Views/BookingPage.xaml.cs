using cleanTable_Mobile.ViewModels;
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
    public partial class BookingPage : ContentPage
    {
        public BookingPage()
        {
            TimePicker TimePicker = new TimePicker();
            TimePicker.Time = DateTime.Now.TimeOfDay;

            var TableList = new List<string>();
            TableList.Add("Table 1 - Sits 2");
            TableList.Add("Table 2 - Sits 4");
            TableList.Add("Table 3 - Sits 4");
            TableList.Add("Table 4 - Sits 6");
            TableList.Add("Table 5 - Sits 6");


            var picker = new Picker { Title = "Select a Table", TitleColor = Color.Red };
            picker.ItemsSource = TableList;

            InitializeComponent();
            
        }

        void OnSliderValueChanged(object sender, ValueChangedEventArgs args)
        {
            double value = args.NewValue;
            value = Convert.ToInt32(value);
            displayLabel.Text = String.Format("Party Size: {0}", value);
        }

        void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            var picker = (Picker)sender;
            int selectedIndex = picker.SelectedIndex;
            var lblTableNumb = new Label();

            if (selectedIndex != -1)
            {
                lblTableNumb.Text = (string)picker.ItemsSource[selectedIndex];
            }
            
        }

         async void ButtonCancel(object sender, EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }
    }
}