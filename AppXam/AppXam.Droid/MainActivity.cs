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


[assembly: ExportRenderer(typeof(LinearPage), typeof(LinearPageRenderer))]
[assembly: ExportRenderer(typeof(WebView), typeof(ZoomableWebViewRenderer))]
[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]
namespace AppXam.Droid
{

    [Activity(Label = "AppXam", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity //XFormsApplicationDroid //
    {
        protected override void OnCreate(Bundle bundle)
        {

            
            var container = new SimpleContainer();
            container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
            container.Register<IDisplay>(t => t.Resolve<IDevice>().Display);
            container.Register<INetwork>(t => t.Resolve<IDevice>().Network);
            Resolver.SetResolver(container.GetResolver());


       

            App.BaseUrl = @"file:///android_asset/";
            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());
        }
    }
}

