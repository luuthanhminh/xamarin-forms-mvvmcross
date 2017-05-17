using App1.Presenter;
using MvvmCross.Forms.Presenter.Core;
using MvvmCross.iOS.Views.Presenters;
using UIKit;
using Xamarin.Forms;

namespace FitStyle.iOS
{
	public class MvxiOSCustomPresenter : MvxCustomPresenter, IMvxIosViewPresenter
	{
		private readonly UIWindow _window;

		public MvxiOSCustomPresenter(UIWindow window,Xamarin.Forms.Application mvxFormsApp)
            : base(mvxFormsApp)
       		{
			_window = window;
		}

		public virtual bool PresentModalViewController(UIViewController controller, bool animated)
		{
			return false;
		}

		public virtual void NativeModalViewControllerDisappearedOnItsOwn()
		{
		}

		protected override void CustomPlatformInitialization(NavigationPage mainPage)
		{
			_window.RootViewController = mainPage.CreateViewController();
		}

		public override void ChangePresentation(MvvmCross.Core.ViewModels.MvxPresentationHint hint)
		{
			base.ChangePresentation(hint);
		}
	} 
}
