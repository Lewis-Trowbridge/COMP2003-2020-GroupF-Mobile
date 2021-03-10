using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace cleanTable_Mobile.ViewModels
{
    class HelpViewModel : BaseViewModel
    {
        public HelpViewModel()
        {
            Title = "Help";
        }
        public ICommand OpenWebCommand { get; }
    }

}
