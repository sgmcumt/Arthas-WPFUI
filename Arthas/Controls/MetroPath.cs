using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroPath : ContentControl
    {
        static MetroPath()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroPath), new FrameworkPropertyMetadata(typeof(MetroPath)));
        }

        public static readonly DependencyProperty DataProperty =
            DependencyProperty.Register(nameof(Data), typeof(Geometry), typeof(MetroPath));

        public Geometry Data
        {
            get => (Geometry)GetValue(DataProperty);
            set => SetValue(DataProperty, value);
        }
    }
}