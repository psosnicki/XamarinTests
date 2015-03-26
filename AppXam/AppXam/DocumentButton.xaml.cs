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

        const string STAR_CHECKED = "star.png";
        const string STAR_UNCHECKED = "star_unchecked.png";

        protected void OnFavoriteTapped(object sender, EventArgs args)
        {
            var src = sender as Image;
            if (src != null)
            {
                var doc = src.BindingContext as Document;
                if (doc != null)
                {
           
                    doc.IsFavorite = !doc.IsFavorite;
                    var imgName = doc.IsFavorite ? STAR_CHECKED : STAR_UNCHECKED;
                    imgFavorite.Source = ImageCache.GetImageFromFileName(imgName);
                }
            }
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var ctx = this.BindingContext as Document;
            imgFavorite.Source = ImageCache.GetImageFromFileName(STAR_UNCHECKED);

            imgDoc.Source = (ctx is IHierarchicalStructure) ? ImageCache.GetImageFromFileName(ctx.ImgSource) :
                                                              ImageCache.GetImageFromFileName(ctx.Extension+".png");

            //if (imgDoc.Source == null) throw new Exception("null source");
            //imgFavorite.Source = 
            //imgDoc.Source = ImageCache.GetImageFromFileName("document.png");
            //
        }
    }
}
