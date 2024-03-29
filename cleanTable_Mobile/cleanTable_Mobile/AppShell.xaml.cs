﻿using System;
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
            Routing.RegisterRoute(nameof(VenueView), typeof(VenueView));
            Routing.RegisterRoute(nameof(BookingPage), typeof(BookingPage));
            Routing.RegisterRoute(nameof(BookingView), typeof(BookingView));
            Routing.RegisterRoute(nameof(CustomerView), typeof(CustomerView));
            Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
            Routing.RegisterRoute(nameof(CreateCustomer), typeof(CreateCustomer));
            Routing.RegisterRoute(nameof(CustomerDelete), typeof(CustomerDelete));
            Routing.RegisterRoute(nameof(BookingDelete), typeof(BookingDelete));
            Shell.SetTabBarIsVisible(this, false);
        }

    }
}
