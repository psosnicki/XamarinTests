using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XLabs.Ioc;
using XLabs.Platform.Device;

namespace AppXam
{
    public partial class DocumentDetailsView : TabbedPage
    {
        public DocumentDetailsView()
        {
            InitializeComponent();
            var device = Resolver.Resolve<IDevice>();
//            device.Display.

            var s = new byte[200];
            for (int i = 0; i < s.Length; i++)
            {
                s[i] = 100;
            }
            int width = device.Display.Width;
            string url = @"http://10.132.6.103:8888/SimpleRest/rest/docc/103366/";

            var img = String.Format("data:image;base64,{0}", Convert.ToBase64String(s));
            string data = "<html><head><title>Example</title><meta name=\"viewport\"\"content=\"width=" + width + ", initial-scale=0.65 \" /></head>";
            data = data + "<body><center><img width=\"" + width + "\" src=\"" + img + "\" /></center></body></html>";
        
            var bs = System.Convert.ToBase64String(s);
            imgView.Source = new HtmlWebViewSource
            {
                Html = data,//"<html><body><img src=\"http://10.132.6.103:8888/SimpleRest/rest/docc/103366/\"/></body></html>",
                BaseUrl = App.BaseUrl
            };
            imgView.SizeChanged+=imgView_SizeChanged;
            
        }

        private void imgView_SizeChanged(object sender, EventArgs e)
        {
         //   var device = Resolver.Resolve<IDevice>();
         //   if (imgView.Width > device.Display.Width)
         //       imgView.RotateXTo(90);
        }        
    }
}
