using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FFImageLoading.Forms;
using Xamarin.Forms;
using ImageSourceConverter = FFImageLoading.Forms.ImageSourceConverter;

namespace App1.Controls
{
    public class ButtonImage : CachedImage
    {
        private const int DELAY_TIME = 100;

        #region Bindable Properties

        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create("Command", typeof(ICommand), typeof(ButtonImage), null);

        public static readonly BindableProperty PressStateProperty =
            BindableProperty.Create("PressState", typeof(string), typeof(ButtonImage), null);

        public static readonly BindableProperty NormalStateProperty =
            BindableProperty.Create("NormalState", typeof(string), typeof(ButtonImage), null);


        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string PressState
        {
            get { return (string)GetValue(PressStateProperty); }
            set { SetValue(PressStateProperty, value); }
        }

        public string NormalState
        {
            get { return (string)GetValue(NormalStateProperty); }
            set { SetValue(NormalStateProperty, value); }
        }

        #endregion

        public ButtonImage()
        {
            TapGestureRecognizer tapGestureRecognizer = new TapGestureRecognizer(TappedCallback);
            this.GestureRecognizers.Add(tapGestureRecognizer);
        }

        private async void TappedCallback(View view, object o)
        {
            this.Source = ImageSource.FromFile(PressState);
            this.ReloadImage();
            await Task.Delay(DELAY_TIME);
            this.Source = ImageSource.FromFile(NormalState);
            this.ReloadImage();

            if (Command != null && Command.CanExecute(null))
            {
                Command.Execute(null);
            }
        }
    }
}
