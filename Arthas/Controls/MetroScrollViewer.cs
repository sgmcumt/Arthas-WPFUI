using System.Windows;
using System.Windows.Controls;
using Arthas.Utility.Element;

namespace Arthas.Controls
{
    public class MetroScrollViewer : ScrollViewer
    {
        public static readonly DependencyProperty FloatProperty = ElementBase.Property<MetroScrollViewer, bool>(nameof(FloatProperty));
        public static readonly DependencyProperty AutoLimitMouseProperty = ElementBase.Property<MetroScrollViewer, bool>(nameof(AutoLimitMouseProperty));
        public static readonly DependencyProperty VerticalMarginProperty = ElementBase.Property<MetroScrollViewer, Thickness>(nameof(VerticalMarginProperty));
        public static readonly DependencyProperty HorizontalMarginProperty = ElementBase.Property<MetroScrollViewer, Thickness>(nameof(HorizontalMarginProperty));

        public bool Float
        {
            get => (bool)GetValue(FloatProperty);
            set => SetValue(FloatProperty, value);
        }

        public bool AutoLimitMouse
        {
            get => (bool)GetValue(AutoLimitMouseProperty);
            set => SetValue(AutoLimitMouseProperty, value);
        }

        public Thickness VerticalMargin
        {
            get => (Thickness)GetValue(VerticalMarginProperty);
            set => SetValue(VerticalMarginProperty, value);
        }

        public Thickness HorizontalMargin
        {
            get => (Thickness)GetValue(HorizontalMarginProperty);
            set => SetValue(HorizontalMarginProperty, value);
        }

        static MetroScrollViewer()
        {
            ElementBase.DefaultStyle<MetroScrollViewer>(DefaultStyleKeyProperty);
        }
    }
}