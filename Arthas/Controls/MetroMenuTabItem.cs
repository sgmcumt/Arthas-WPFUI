using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroMenuTabItem : TabItem
    {
        static MetroMenuTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroMenuTabItem), new FrameworkPropertyMetadata(typeof(MetroMenuTabItem)));
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(MetroMenuTabItem));

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty IconMoveProperty =
            DependencyProperty.Register(nameof(IconMove), typeof(ImageSource), typeof(MetroMenuTabItem));

        public ImageSource IconMove
        {
            get => (ImageSource)GetValue(IconMoveProperty);
            set => SetValue(IconMoveProperty, value);
        }

        public static readonly DependencyProperty TextHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(TextHorizontalAlignment), typeof(HorizontalAlignment), typeof(MetroMenuTabItem), new FrameworkPropertyMetadata(HorizontalAlignment.Right));

        public HorizontalAlignment TextHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
            set => SetValue(TextHorizontalAlignmentProperty, value);
        }
    }
}