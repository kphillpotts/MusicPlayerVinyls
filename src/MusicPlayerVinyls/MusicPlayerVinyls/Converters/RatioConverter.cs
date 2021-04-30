using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace MusicPlayerVinyls.Converters
{

    public class RatioConverter : IValueConverter
    {
        public double Default { get; set; }

        public bool UseAbsolute { get; set; }
        public double Min { get; set; }
        public double Max { get; set; }
        public double Ratio { get; set; }
        public bool Inverted { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double initialValue;
            if (double.TryParse(value.ToString(), out initialValue))
            {
                if (UseAbsolute)
                    initialValue = Math.Abs(initialValue);

                if (Inverted)
                    initialValue = Default - (initialValue * Ratio);
                else
                    initialValue = Default +  (initialValue * Ratio);


                if (initialValue > Max)
                    initialValue = Max;

                if (initialValue < Min)
                    initialValue = Min;

                return initialValue;
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
