using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Xamarin.Forms;
using AppXam;
using AppXam.Droid;
using XLabs.Forms;
using ImageCircle.Forms.Plugin.Droid;
using XLabs.Platform.Device;
using XLabs.Platform.Services;
using XLabs.Ioc;
using Toasts.Forms.Plugin.Droid;
using Refractored.Xam.TTS;
using AppXam.Repositories;


[assembly: ExportRenderer(typeof(LinearPage), typeof(LinearPageRenderer))]
[assembly: ExportRenderer(typeof(WebView), typeof(ZoomableWebViewRenderer))]
[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]
namespace AppXam.Droid
{

    [Activity(Label = "AppXam", Theme = "@android:style/Theme.Holo.Light", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity //XFormsApplicationDroid //
    {
        protected override void OnCreate(Bundle bundle)
        {

            
            var container = new SimpleContainer();
            container.Register<MainMenuViewModel>(r => new MainMenuViewModel(r.Resolve<ITaskRepository>()));
            container.Register<MainMasterViewModel>(r => new MainMasterViewModel(r.Resolve<ITaskRepository>()));
            container.Register<RepositoryViewModel>(r => new RepositoryViewModel(r.Resolve<IArchiveRepository>()));
            container.Register<AddBasicDocumentInfoViewModel>(r => new AddBasicDocumentInfoViewModel(r.Resolve<IArchiveRepository>()));
            container.Register<AddBasicDocumentInfoView>(r => new AddBasicDocumentInfoView());
            container.Register<CapturePreviewViewModel>(r=> new CapturePreviewViewModel());
            container.Register<CapturePreview>(r => new CapturePreview());
            container.Register<IndexesViewModel>(r => new IndexesViewModel(r.Resolve<IArchiveRepository>()));
            container.Register<IndexesView>(r => new IndexesView());
            container.RegisterSingle<ITaskRepository, TaskRepository>();
            container.RegisterSingle<IArchiveRepository, ArchiveRepository>();
            container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
            container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
            Resolver.SetResolver(container.GetResolver());


       

            App.BaseUrl = @"file:///android_asset/";
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ToastNotificatorImplementation.Init();
           // CrossTextToSpeech.Current.Init();
            ImageCircleRenderer.Init();
            LoadApplication(new App());
        }
    }
}

