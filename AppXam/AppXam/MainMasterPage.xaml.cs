using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppXam
{
    public partial class MainMasterPage : MasterDetailPage
    {
        public MainMasterPage()
        {
            InitializeComponent();
            Title = "Menu";
           // BindingContext = new MainMasterViewModel();
             this.Appearing += (sender, e) =>
            {
                this.IsPresented = true;
            };
            Detail = new NavigationPage(new TasksView{ BindingContext = new TasksViewModel(null)});
            IsPresented = false;
            this.MasterBehavior = Xamarin.Forms.MasterBehavior.Popover;
        }
    }
}
