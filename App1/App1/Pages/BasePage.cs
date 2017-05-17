using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using Xamarin.Forms;

namespace App1.Pages
{
    public class BasePage : ContentPage
    {

        public BaseViewModel ViewModel
        {
            get
            {
                return this.BindingContext as BaseViewModel;
            }
            set { this.BindingContext = value; }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.ViewAppearring();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            ViewModel.ViewDisappearing();
        }

        protected override void OnParentSet()
        {
            base.OnParentSet();
            if (this.Parent == null)
            {
                ViewModel.Detroy();
            }
        }

        public string ViewModelType()
        {
            return this.GetType().FullName;
        }
    }
}
