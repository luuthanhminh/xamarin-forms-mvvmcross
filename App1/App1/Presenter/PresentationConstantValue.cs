using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;

namespace App1.Presenter
{
    public class PresentationConstantValue
    {
        public const string CLEAR_STACK_AND_SHOW = "_ClearStack_";

        public const string CLOSE_CURRENT_AND_SHOW = "_CloseCurrentAndShow_";

        public const string SHOW_BACK = "_ShowBack_";

        public const string CLOSE_WITHOUT_ANIMATE = "_CloseWithoutAnimate_";

        public const string SHOW_WITHOUT_ANIMATE = "_ShowWithOutAnimate_";

        public const string INSERT_PAGE = "_InsertPage_";

    }
    public class CloseWithoutAnimateHint : MvxPresentationHint
    {

    }

    public class CloseToViewModel : MvxPresentationHint
    {
        public Type ViewModelType { get; set; }

        public CloseToViewModel(Type type)
        {
            this.ViewModelType = type;
        }
    }
}
