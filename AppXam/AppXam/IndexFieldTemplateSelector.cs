using AppXam.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Forms.Controls;

namespace AppXam
{
    public class IndexFieldTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DateTimeFieldTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, BindableObject container)
        {
            var idx = item as IndexField;

            var mp = new StackLayout { Orientation = StackOrientation.Vertical , Padding = new Thickness(5) };
            mp.Children.Add(new Label { TextColor = Color.Black, Text = idx.DisplayName, Font = Font.SystemFontOfSize(NamedSize.Medium) });

            var hp = new StackLayout { Orientation = StackOrientation.Horizontal};


            View ctrl = CreateIndexControl(idx);
            ctrl.HorizontalOptions = LayoutOptions.FillAndExpand;

            //var entry = new Entry { HorizontalOptions =  LayoutOptions.FillAndExpand };


            hp.Children.Add(ctrl);

            var errorMsg = new Label { TextColor = Color.Red, Font = Font.SystemFontOfSize(NamedSize.Small) };
           

            var img = new Image { Source = "valid.png", BackgroundColor = Color.Transparent, HorizontalOptions = LayoutOptions.End };
            var frame = new Frame {  BackgroundColor = Color.White , Padding = new Thickness(4)};
            frame.Content = hp;
       
            var dt = new DataTemplate(() => { return mp; });
          
            if(idx!=null)
            {


                if (idx.Type == IndexType.INTEGER)
                {
                    var nb = new NumericEntryBehavior();
                    errorMsg.SetBinding(Label.IsVisibleProperty, new Binding("IsValid", BindingMode.TwoWay, new InvertBoolConverter(), null, null, nb));
                    errorMsg.Text = "This field must be numeric";
                    ctrl.Behaviors.Add(nb);
                    img.SetBinding(Image.SourceProperty, new Binding("IsValid", BindingMode.TwoWay, new ValidImgConverter(), null, null, nb));
                }

                if (idx.Required && idx.Type != IndexType.DATETIME)
                {
                    var rb = new RequiredEntryBehavior();
                    errorMsg.SetBinding(Label.IsVisibleProperty,new Binding("IsValid", BindingMode.TwoWay, new InvertBoolConverter() , null, null, rb));
                    errorMsg.Text = "This field is required!";
                    ctrl.Behaviors.Add(rb);

                    img.SetBinding(Image.SourceProperty, new Binding("IsValid", BindingMode.TwoWay, new ValidImgConverter(), null, null, rb));
                }

                
            }
    
            hp.Children.Add(img);
            mp.Children.Add(frame);
            mp.Children.Add(errorMsg);

            return dt;
        }

        private View CreateIndexControl(IndexField idx)
        {
            if (idx.Type == IndexType.DATETIME)
                return new DatePicker();
   
            return new Entry { };
        }
    }

    public class InvertBoolConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !((bool)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class ValidImgConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)(value) ? "valid.png" : "notvalid.png";
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
