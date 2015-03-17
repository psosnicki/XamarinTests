using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppXam
{
    public partial class DocumentButton : ContentView
    {
        public DocumentButton()
        {
            InitializeComponent();
        }

        protected void OnFavoriteTapped(object sender, EventArgs args)
        {
            var src = sender as Image;
            if (src != null)
            {
                var doc = src.BindingContext as Document;
                if (doc != null)
                {
                    doc.IsFavorite = !doc.IsFavorite;
                }
            }
        }
    }
}
