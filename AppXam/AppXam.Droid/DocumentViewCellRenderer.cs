using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Xamarin.Forms.Platform.Android;

namespace AppXam.Droid
{
    public class DocumentViewCellRenderer :ViewCellRenderer //ViewCellRenderer 
    {
        private Context _context;

        protected override void OnCellPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnCellPropertyChanged(sender, e);
        }
     

        protected override View GetCellCore(Xamarin.Forms.Cell item, View convertView, ViewGroup parent, Context context)
        {
            //if (convertView == null)
            //    convertView = new BaseCellView(_context);

            var cell = base.GetCellCore(item, convertView, parent, context);
          
            return cell;
            //cell.
           // cell.Update

            //var ctrl = new LinearLayout(_context);
            //ctrl.Orientation = Orientation.Horizontal;

            //var imgFile = new ImageView(_context);
            //imgFile.SetImageResource(Resource.Drawable.icon);

            //ctrl.AddView(imgFile);

            //cell.View

            //return base.GetCellCore(item, convertView, parent, context);
        }
    }
}