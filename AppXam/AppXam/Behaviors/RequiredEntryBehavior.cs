using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace AppXam.Behaviors
{
    public class RequiredEntryBehavior : Behavior<Entry>
    {
        public static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(RequiredEntryBehavior), false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            protected set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(BindableObject bindable)
        {
            ((Entry)bindable).TextChanged += Input_TextChanged;   
        }

        private void Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = !String.IsNullOrEmpty(((Entry)sender).Text);
        }

        protected override void OnDetachingFrom(BindableObject bindable)
        {
            if(bindable is Entry)
                ((Entry)bindable).TextChanged -= Input_TextChanged;

        }
    }
}
