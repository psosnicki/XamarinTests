using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Android.Graphics;
using Xamarin.Forms;


namespace AppXam.Droid
{
    class RoundedLabelRenderer :LabelRenderer
    {
        public RoundedLabelRenderer()
        {
            SetWillNotDraw(false);
        }
        public override void Draw(Canvas canvas)
        {
            var label = Element as RoundedLabel;
            var width = (int)label.BorderWidth * Resources.DisplayMetrics.Density;
            var radius = (float)label.CornerRadius * Resources.DisplayMetrics.Density;
            var rect = new RectF(canvas.ClipBounds);
            rect.Inset(width, width);
            FillRect(canvas, rect, radius);
            DrawStroke(canvas, rect, radius, width);
            DrawText(canvas, rect, label.Text);
        }

        void FillRect(Canvas canvas, RectF rect, float radius)
        {
            var paint = new Paint
            {
                Color = Element.BackgroundColor.ToAndroid(),
                AntiAlias = true,
            };
            canvas.DrawRoundRect(rect, radius, radius, paint);
        }

        void DrawStroke(Canvas canvas, RectF rect, float radius, float width)
        {
            var paint = new Paint
            {
                Color = (Element as RoundedLabel).BorderColor.ToAndroid(),
                StrokeWidth = width,
                AntiAlias = true,
            };
            paint.SetStyle(Paint.Style.Stroke);
            canvas.DrawRoundRect(rect, radius, radius, paint);
        }

        void DrawText(Canvas canvas, RectF rect, string text)
        {
            var paint = new Paint
            {
                TextSize = (float)Element.FontSize * Resources.DisplayMetrics.Density,
            };
            var position = CenterText(paint, rect, text);
            canvas.DrawText(text, position.X, position.Y, paint);
        }

        static PointF CenterText(Paint paint, RectF rect, string text)
        {
            var bounds = new Rect();
            paint.GetTextBounds(text, 0, text.Length, bounds);
            return new PointF(
            rect.CenterX() - bounds.Width() / 2,
            rect.CenterY() + bounds.Height() / 2);
        }
    }
}