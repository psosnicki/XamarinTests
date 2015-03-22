using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXam
{
    public class RoundedLabel :Label
    {
        public Color BorderColor { get; set; }
        public double BorderWidth { get; set; }
        public double CornerRadius { get; set; }
    }
}
