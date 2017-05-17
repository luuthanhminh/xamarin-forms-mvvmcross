using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FitStyle.iOS;
using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.iOS.Views.Presenters;
using MvvmCross.Platform.Platform;
using UIKit;
using Xamarin.Forms;

namespace App1.iOS
{
    public class Setup : MvxIosSetup
    {
        public Setup(MvxApplicationDelegate applicationDelegate, UIWindow window)
            : base(applicationDelegate, window)
        {
        }

        protected override IMvxApplication CreateApp()
        {
          

            return new App();
        }

        //protected override IMvxTrace CreateDebugTrace()
        //{
        //    return new DebugTrace();
        //}

        protected override IMvxIosViewPresenter CreatePresenter()
        {
            Forms.Init();
           // KeyboardOverlapRenderer.Init();

            var appStyle = new MyApp();

            //GestureRecognizerExtensions.Factory = new NativeGestureRecognizerFactory();

            return new MvxiOSCustomPresenter(Window, appStyle);
        }
    }
}