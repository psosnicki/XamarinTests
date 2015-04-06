using Media.Plugin;
using Media.Plugin.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;

namespace AppXam
{
    public static class AddNewFlow
    {
        public static void CreateCapturePreview()
        {
            var v = Resolver.Resolve<CapturePreview>();
            var vm = Resolver.Resolve<CapturePreviewViewModel>();
            v.BindingContext = vm;
            App.Navigation.PushAsync(v, true);
        }

        public static void CreateBasicDocumentMetaView()
        {
            var v = Resolver.Resolve<AddBasicDocumentInfoView>();
            var vm = Resolver.Resolve<AddBasicDocumentInfoViewModel>();
            v.BindingContext = vm;
            App.Navigation.PushAsync(v, true);
        }

        public static void CreateIndexesView()
        {
            var v = Resolver.Resolve<IndexesView>();
            var vm = Resolver.Resolve<IndexesViewModel>();
            v.BindingContext = vm;
            App.Navigation.PushAsync(v, true);
        }
       
    }
}
