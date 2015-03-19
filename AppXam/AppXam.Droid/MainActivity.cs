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


[assembly: ExportRenderer(typeof(LinearPage), typeof(LinearPageRenderer))]
namespace AppXam.Droid
{

    [Activity(Label = "AppXam", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity //XFormsApplicationDroid //
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            ImageCircleRenderer.Init();
            LoadApplication(new App());
        }
    }
}

