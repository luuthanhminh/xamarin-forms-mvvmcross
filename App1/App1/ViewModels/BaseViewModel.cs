using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App1.Presenter;
using MvvmCross.Core.ViewModels;

namespace App1.ViewModels
{
    public class BaseViewModel : MvxViewModel
    {
        #region Life circle

        public bool IsLoaded { get; set; }


        public virtual void ViewAppearring()
        {
            if (!IsLoaded)
            {
                Loaded();
                Debug.WriteLine("Loaded + ViewAppearring " + this.GetType().FullName);
            }
            else
            {
                Debug.WriteLine("ViewAppearring " + this.GetType().FullName);
            }

        }

        protected virtual void Loaded()
        {
            IsLoaded = true;
            Debug.WriteLine("Loaded " + this.GetType().FullName);
        }

    public virtual void ViewDisappearing()
        {
            Debug.WriteLine("ViewDisappearing " + this.GetType().FullName);
        }

        public virtual void Detroy()
        {
            IsLoaded = false;
            Debug.WriteLine("Detroy " + this.GetType().FullName);
        }

        protected void ClearStackAndShowViewModel<TViewModel>(Type type,object parameter = null) where TViewModel : BaseViewModel
        {
            var presentationBundle = new MvxBundle(new Dictionary<string, string> { { PresentationConstantValue.CLEAR_STACK_AND_SHOW, type.FullName } });

            ShowViewModel<TViewModel>(parameter, presentationBundle: presentationBundle);
        }

        #endregion

    }
}
