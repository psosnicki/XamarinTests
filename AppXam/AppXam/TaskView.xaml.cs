using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppXam
{
    public partial class TaskView : ContentView
    {
        public TaskView()
        {
            InitializeComponent();
        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            var ctx = this.BindingContext as EcmTask;
            string imgTask = null;
            if (ctx.EndDate < DateTime.Now)
                imgTask = "flame32.png";
            else if (ctx.EndDate > DateTime.Now && ctx.EndDate < DateTime.Now.AddDays(2))
                imgTask = "overdue32.png";
            else if (ctx.EndDate > DateTime.Now)
                imgTask = "tasknormal32.png";

            imgTaskTimeStatus.Source =  ImageCache.GetImageFromFileName(imgTask);
        }
    }
}
