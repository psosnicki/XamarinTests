using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public class MenuItemTemplateSelector :DataTemplateSelector
    {
        public DataTemplate TasksItem { get; set; }
        public DataTemplate NormalItem { get; set; }

        public override DataTemplate SelectTemplate(object item, BindableObject container)
        {
            if (item is TasksMenuItem)
                return TasksItem;
            if (item is MenuItem)
                return NormalItem;

            return NormalItem;

        }
    }
}
