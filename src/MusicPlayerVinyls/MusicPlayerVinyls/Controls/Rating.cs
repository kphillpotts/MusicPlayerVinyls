using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
namespace MusicPlayerVinyls.Controls
{
    public class Rating : SKCanvasView
    {
        string starPath = "M 0 -100 L 58.8 90.9, -95.1 -30.9, 95.1 -30.9, -58.8 80.9 Z";
        SKPath itemPath;

        SKPaint backgroundPaint;

        SKPaint foregroundPaint;



        public Rating()
        {
            itemPath = SKPath.ParseSvgPathData(starPath);
            backgroundPaint = new SKPaint()
            {
                Color = Color.FromHex("#ECECEC").ToSKColor(),
                IsAntialias = true
            };
            foregroundPaint = new SKPaint()
            {
                Color = Color.FromHex("#CCC4AC").ToSKColor(),
                IsAntialias = true
            };

            this.PaintSurface += Rating_PaintSurface;
        }

        public static readonly BindableProperty MaxProperty = BindableProperty.Create(
                                        propertyName: nameof(Max),
                                        returnType: typeof(int),
                                        declaringType: typeof(View),
                                        defaultValue: 5,
                                        defaultBindingMode: BindingMode.TwoWay,
                                        propertyChanged: MaxPropertyChanged,
                    propertyChanging: null);

        private static void MaxPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var me = bindable as Rating;
            me.InvalidateSurface();
        }

        public int Max
        {
            get { return (int)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }


        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
                                        propertyName: nameof(Value),
                                        returnType: typeof(double),
                                        declaringType: typeof(View),
                                        defaultValue: 0d,
                                        defaultBindingMode: BindingMode.TwoWay,
                                        propertyChanged: ValuePropertyChanged,
                    propertyChanging: null);

        private static void ValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var me = bindable as Rating;
            me.InvalidateSurface();
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }


        public static readonly BindableProperty SpacingProperty = BindableProperty.Create(
                                        propertyName: nameof(Spacing),
                                        returnType: typeof(int),
                                        declaringType: typeof(View),
                                        defaultValue: 10,
                                        defaultBindingMode: BindingMode.TwoWay,
                                        propertyChanged: SpacingPropertyChanged,
                    propertyChanging: null);

        private static void SpacingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var me = bindable as Rating;
            me.InvalidateSurface();
        }

        public int Spacing
        {
            get { return (int)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        private void Rating_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            var canvas = e.Surface.Canvas;
            canvas.Clear();

            // draw stars in background color
            DrawItems(canvas, e.Info, backgroundPaint);

            // create a clipping area based on value
            var itemWidth = e.Info.Width / Max;
            SKRect clipRect = new SKRect(0, 0, (float)(itemWidth * Value), e.Info.Height);
            canvas.ClipRect(clipRect, SKClipOperation.Intersect, true);

            // draw stars in foreground color
            DrawItems(canvas, e.Info, foregroundPaint);
        }

        

        private void DrawItems(SKCanvas canvas, SKImageInfo info, SKPaint paint)
        {
            // calculate the size of an indidual item (considering spacing)
            float calcWidth = (float)((info.Width - ((Max - 1) * Spacing)) / Max);

            for (int i = 0; i < Max; i++)
            {
                // calculate the rect of this item
                SKRect itemRect = new SKRect()
                {
                    Left = 0,
                    Right = calcWidth,
                    Top = 0,
                    Bottom = calcWidth,
                };
                // modify the location based on item index
                float xLocation = (float)((i * calcWidth) + (i * Spacing));
                itemRect.Location = new SKPoint(xLocation, (info.Height / 2) - (calcWidth / 2));

                DrawPathInRect(canvas, itemPath, itemRect, paint);

            }
        }

        private void DrawPathInRect(SKCanvas canvas, SKPath path, SKRect itemRect, SKPaint paint)
        {
            // get the bounds of the path
            SKRect pathBounds;
            path.GetTightBounds(out pathBounds);

            // start at the middle of the rect
            var transX = itemRect.Left + (itemRect.Width / 2);
            var transY = itemRect.Top + (itemRect.Height / 2);
            canvas.Translate(transX, transY);

            // scale the path to fit the rect
            var scaleX = itemRect.Width / pathBounds.Width;
            var scaleY = itemRect.Height / pathBounds.Height;
            canvas.Scale(scaleX, scaleY);

            // center the path in the canvas
            canvas.Translate(-pathBounds.MidX, -pathBounds.MidY);

            // draw the path
            canvas.DrawPath(path, paint);

            // clear the transformations
            canvas.ResetMatrix();
        }
    }
}
