using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public class DataTemplateSelector
    {
        public virtual DataTemplate SelectTemplate(object item, BindableObject container)
        {
            return null;
        }
    }
}
