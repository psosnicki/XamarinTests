using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public class LinearPage : ContentPage
    {
        public static BindableProperty FromProperty = BindableProperty.Create<LinearPage, Color>(p => p.BackgroundColor, Color.White);
        public Color From
        {
            get { return (Color)GetValue(FromProperty); }
            set { SetValue(FromProperty, value); }
        }

        public static BindableProperty ToProperty = BindableProperty.Create<LinearPage, Color>(p => p.BackgroundColor, Color.White);
        public Color To
        {
            get { return (Color)GetValue(ToProperty); }
            set { SetValue(ToProperty, value); }
        }
    }
}
