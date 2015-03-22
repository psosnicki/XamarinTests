using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppXam
{
    public partial class MainMenuView : ContentPage
    {
        public MainMenuView()
        {
            InitializeComponent();
            BackgroundColor = Color.FromRgb(151, 199,201);
            this.ToolbarItems.Add(new ToolbarItem { Icon = "user.png",  Text="psosnicki" ,IsDestructive=true});
        }
    }
}
