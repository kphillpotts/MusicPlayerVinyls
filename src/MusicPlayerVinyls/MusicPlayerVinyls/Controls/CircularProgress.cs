using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace MusicPlayerVinyls.Controls
{
    public class CircularProgress : SKCanvasView
    {
        SKPaint CirclePaint;
        SKPaint ArcPaint;

        public CircularProgress()
        {

            CirclePaint = new SKPaint()
            {
                StrokeWidth = StrokeWidth,
                Color = Color.FromHex("#F6F6F6").ToSKColor(),
                IsStroke = true,
                IsAntialias = true
            };

            ArcPaint = new SKPaint()
            {
                StrokeWidth = StrokeWidth,
                Color = Color.FromHex("#CCC4AC").ToSKColor(),
                IsStroke = true,
                IsAntialias = true
            };

            this.PaintSurface += CircularProgress_PaintSurface;
        }


        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                                        propertyName: nameof(Value),
                                        returnType: typeof(float),
                                        declaringType: typeof(View),
                                        defaultValue: 0f,
                                        defaultBindingMode: BindingMode.TwoWay,
                                        propertyChanged: ValuePropertyChanged,
                    propertyChanging: null);

        private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var me = bindable as CircularProgress;
            me.InvalidateSurface();
        }

        public float Value
        {
            get { return (float)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        public static readonly BindableProperty StrokeWidthProperty = BindableProperty.Create(
                                        propertyName: nameof(StrokeWidth),
                                        returnType: typeof(float),
                                        declaringType: typeof(View),
                                        defaultValue: 30f,
                                        defaultBindingMode: BindingMode.TwoWay,
                                        propertyChanged: null,
                    propertyChanging: null);

        public float StrokeWidth
        {
            get { return (float)GetValue(StrokeWidthProperty); }
            set { SetValue(StrokeWidthProperty, value); }
        }




        private void CircularProgress_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;

            canvas.Clear();

            // calculate our radius
            var radius = Math.Min(e.Info.Rect.Width, e.Info.Rect.Height) / 2;
            radius -= (int)(StrokeWidth / 2);

            // draw the circle
            SKPoint mid = new SKPoint(e.Info.Rect.MidX, e.Info.Rect.MidY);
            canvas.DrawCircle(mid, radius, CirclePaint);

            // draw the arc
            using (SKPath arcPath = new SKPath())
            {
                var rect = e.Info.Rect;
                rect.Inflate((int)-(StrokeWidth / 2), (int)-(StrokeWidth / 2));
                var angle = Value * 3.6f;
                arcPath.AddArc(rect, 270, angle);
                canvas.DrawPath(arcPath, ArcPaint);
            }
        }
    }
}
