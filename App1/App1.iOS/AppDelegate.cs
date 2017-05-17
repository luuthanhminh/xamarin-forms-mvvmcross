using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using MvvmCross.Core.ViewModels;
using MvvmCross.iOS.Platform;
using MvvmCross.Platform;
using UIKit;

namespace App1.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : MvxApplicationDelegate
    {
        public UIWindow _window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {

            _window = new UIWindow(UIScreen.MainScreen.Bounds);


            var setup = new Setup(this, _window);
            setup.Initialize();


            var startup = Mvx.Resolve<IMvxAppStart>();
            startup.Start();

            _window.MakeKeyAndVisible();

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);



            return true;
        }

        public override void OnActivated(UIApplication application)
        {
           // AppEvents.ActivateApp();
        }

        //public override bool OpenUrl(UIApplication application, NSUrl url, string sourceApplication, NSObject annotation)
        //{
        //    // We need to handle URLs by passing them to their own OpenUrl in order to make the SSO authentication works.
        //    return ApplicationDelegate.SharedInstance.OpenUrl(application, url, sourceApplication, annotation);
        //}
    }
}
