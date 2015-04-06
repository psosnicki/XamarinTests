using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppXam
{
    public partial class StructureView : ContentView
    {
        public StructureView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            var ctx = BindingContext as BaseStructure;
            if(!String.IsNullOrEmpty(ctx.ImgSource))
                img.Source = (ctx is IHierarchicalStructure) ? ImageCache.GetImageFromFileName(ctx.ImgSource) :
                                                               ImageCache.GetImageFromFileName(ctx.Extension + ".png");
        }
    }
}
