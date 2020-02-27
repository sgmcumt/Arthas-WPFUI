using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroTabItem : TabItem
    {
        static MetroTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTabItem), new FrameworkPropertyMetadata(typeof(MetroTabItem)));
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(MetroTabItem));

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }
    }
}