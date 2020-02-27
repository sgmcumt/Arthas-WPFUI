using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroTitleMenuItem : MenuItem
    {
        static MetroTitleMenuItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTitleMenuItem), new FrameworkPropertyMetadata(typeof(MetroTitleMenuItem)));
        }

        public new static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(MetroTitleMenuItem));

        public new ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}