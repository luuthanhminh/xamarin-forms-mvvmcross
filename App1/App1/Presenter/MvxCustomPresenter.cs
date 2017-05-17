using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Pages;
using MvvmCross.Core.ViewModels;
using MvvmCross.Forms.Presenter.Core;
using Xamarin.Forms;

namespace App1.Presenter
{
    public class MvxCustomPresenter : MvxFormsPagePresenter
    {
        #region Constructors

        protected MvxCustomPresenter()
        {
        }

        protected MvxCustomPresenter(Application mvxFormsApp)
        {
            MvxFormsApp = mvxFormsApp;
        }

        #endregion

        #region Overrides


        public override void Show(MvxViewModelRequest request)
        {
            var mainPage = this.MvxFormsApp.MainPage as NavigationPage;

            //Ignore View for SplashViewModel 
            //if (request.ViewModelType == typeof(SplashViewModel))
            //{
            //    MvxPresenterHelpers.LoadViewModel(request);
            //    return;
            //}
            if (mainPage != null)
            {
                if (request.PresentationValues != null)
                {
                    if (request.PresentationValues.ContainsKey(PresentationConstantValue.CLEAR_STACK_AND_SHOW))
                    {
                        var page = MvxPresenterHelpers.CreatePage(request);
                        if (page == null)
                            return;

                        var viewModel = MvxPresenterHelpers.LoadViewModel(request);

                        SetupForBinding(page, viewModel, request);


                        mainPage.Navigation.InsertPageBefore(page, mainPage.Navigation.NavigationStack.First());
                        mainPage.Navigation.PopToRootAsync(false);
                        return;
                    }
                    else if (request.PresentationValues.ContainsKey(PresentationConstantValue.CLOSE_CURRENT_AND_SHOW))
                    {
                        var page = MvxPresenterHelpers.CreatePage(request);
                        if (page == null)
                            return;

                        var viewModel = MvxPresenterHelpers.LoadViewModel(request);

                        SetupForBinding(page, viewModel, request);
                        mainPage.Navigation.PopAsync();
                        mainPage.Navigation.PushAsync(page);
                        return;
                    }
                    else if (request.PresentationValues.ContainsKey(PresentationConstantValue.SHOW_WITHOUT_ANIMATE))
                    {
                        var page = MvxPresenterHelpers.CreatePage(request);
                        if (page == null)
                            return;

                        var viewModel = MvxPresenterHelpers.LoadViewModel(request);
                        SetupForBinding(page, viewModel, request);
                        mainPage.Navigation.PushAsync(page, false);
                        return;
                    }
                    else if (request.PresentationValues.ContainsKey(PresentationConstantValue.INSERT_PAGE))
                    {
                        var page = MvxPresenterHelpers.CreatePage(request);

                        if (page == null)
                            return;

                        var viewModel = MvxPresenterHelpers.LoadViewModel(request);
                        SetupForBinding(page, viewModel, request);

                        mainPage.Navigation.InsertPageBefore(page, mainPage.Navigation.NavigationStack.Last());
                        return;
                    }

                }
            }

            base.Show(request);
        }


        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint is CloseWithoutAnimateHint)
            {
                var mainPage = this.MvxFormsApp.MainPage as NavigationPage;
                mainPage.PopAsync(false);
                return;
            }else if (hint is CloseToViewModel)
            {
                var type = (hint as CloseToViewModel).ViewModelType;
                var mainPage = this.MvxFormsApp.MainPage as NavigationPage;
                while (mainPage.Navigation.NavigationStack.Any())
                {
                    BasePage BasePage = (BasePage) mainPage.Navigation.NavigationStack.Last();
                    if (BasePage.ViewModel.GetType() ==  type)
                    {
                       break;
                    }
                    mainPage.Navigation.PopAsync(false);
                }
                return;
            }
            base.ChangePresentation(hint);
        }

        #endregion

        #region Methods

        private void SetupForBinding(Page page, IMvxViewModel viewModel, MvxViewModelRequest request)
        {
            var mvxContentPage = page as IMvxContentPage;
            if (mvxContentPage != null)
            {
                mvxContentPage.Request = request;
                mvxContentPage.ViewModel = viewModel;
            }
            else
            {
                page.BindingContext = viewModel;
            }
        }

        #endregion
    }
}
