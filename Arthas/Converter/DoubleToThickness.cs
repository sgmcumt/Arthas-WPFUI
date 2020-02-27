using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Arthas.Converter
{
    public class DoubleToThickness : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return new Thickness(0);
            if (parameter == null)
                return new Thickness(System.Convert.ToDouble(value));
            return parameter.ToString() switch
            {
                "Left"        => new Thickness(System.Convert.ToDouble(value), 0, 0, 0),
                "Top"         => new Thickness(0, System.Convert.ToDouble(value), 0, 0),
                "Right"       => new Thickness(0, 0, System.Convert.ToDouble(value), 0),
                "Bottom"      => new Thickness(0, 0, 0, System.Convert.ToDouble(value)),
                "LeftTop"     => new Thickness(System.Convert.ToDouble(value), System.Convert.ToDouble(value), 0, 0),
                "LeftBottom"  => new Thickness(System.Convert.ToDouble(value), 0, 0, System.Convert.ToDouble(value)),
                "RightTop"    => new Thickness(0, System.Convert.ToDouble(value), System.Convert.ToDouble(value), 0),
                "RightBottom" => new Thickness(0, 0, System.Convert.ToDouble(value), System.Convert.ToDouble(value)),
                "LeftRight"   => new Thickness(System.Convert.ToDouble(value), 0, System.Convert.ToDouble(value), 0),
                "TopBottom"   => new Thickness(0, System.Convert.ToDouble(value), 0, System.Convert.ToDouble(value)),
                _             => new Thickness(System.Convert.ToDouble(value))
            };
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return 0.0;
            if (parameter == null)
                return ((Thickness)value).Left;
            switch (parameter.ToString())
            {
                case "Left":
                    return ((Thickness)value).Left;

                case "Top":
                    return ((Thickness)value).Top;

                case "Right":
                    return ((Thickness)value).Right;

                case "Bottom":
                    return ((Thickness)value).Bottom;

                default:
                    return ((Thickness)value).Left;
            }
        }
    }
}