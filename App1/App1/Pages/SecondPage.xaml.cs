using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.ViewModels;
using MvvmCross.Platform;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SecondPage
    {
        public SecondPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        public SecondViewModel ViewModel
        {
            get { return (SecondViewModel)this.BindingContext; }
            set
            {
                this.BindingContext = value;
            }
        }


        private void Button_OnClicked(object sender, EventArgs e)
        {
          
        }
    }
}
