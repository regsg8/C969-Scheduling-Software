using System;
using System.Collections.Generic;
using WGUMobileAppRegGarrett.ViewModels;
using WGUMobileAppRegGarrett.Views;
using Xamarin.Forms;

namespace WGUMobileAppRegGarrett
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            this.GoToAsync("//LoginPage");
        }

    }
}
