using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroMenuItem : MenuItem
    {
        static MetroMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroMenuItem), new FrameworkPropertyMetadata(typeof(MetroMenuItem)));
        }

        public new static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(MetroMenuItem));

        public new ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}