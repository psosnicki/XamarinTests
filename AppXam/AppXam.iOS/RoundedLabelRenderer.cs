using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using CoreGraphics;
using Xamarin.Forms;
using AppXam.iOS;
using AppXam;
using System.Drawing;

[assembly: ExportRenderer(typeof(RoundedLabel), typeof(RoundedLabelRenderer))]
namespace AppXam.iOS
{
    public class RoundedLabelRenderer :LabelRenderer
    {
    //    protected override void Draw(RectangleF rect)
    //    {
    //        using (var context = UIGraphics.GetCurrentContext())
    //        {
    //            ClearCanvas(context, rect);
    //            FillRoundedRect(context, rect);
    //        }
    //    }

        static void ClearCanvas(CGContext context, RectangleF rect)
        {
            context.SetFillColor(Color.White.ToCGColor());
            context.FillRect(rect);
        }

        void FillRoundedRect(CGContext context, RectangleF rect)
        {
            var label = Element as RoundedLabel;
            var radius = (float)label.CornerRadius;
            var width = (float)label.BorderWidth;
            context.SetLineWidth(width);
            context.SetStrokeColor(label.BorderColor.ToCGColor());
            context.SetFillColor(label.BackgroundColor.ToCGColor());
            //context.AddPath(CGPath.FromRoundedRect(rect.Inset(width, width), radius, radius));
            context.DrawPath(CGPathDrawingMode.FillStroke);
        }
    }
}