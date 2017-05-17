using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace App1.ViewModels
{

    public class FirstViewModel : BaseViewModel
    {


        #region Constructor

        public FirstViewModel() : base()
        {

        }

        #endregion

        #region Fields


        #endregion

        #region Properties

        #endregion

        #region Init

        public void Init()
        {
            Debug.WriteLine("Init " + this.GetType().Name);
        }

        #endregion

        #region Commands


        private MvxCommand mNextCommand;

        public MvxCommand NextCommand
        {
            get
            {
                if (mNextCommand == null)
                {
                    mNextCommand = new MvxCommand(this.Next);
                }
                return mNextCommand;
            }
        }

        private async void Next()
        {
            ShowViewModel<SecondViewModel>();
        }

        #endregion
    }

}
