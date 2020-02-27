using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroScrollViewer : ScrollViewer
    {
        static MetroScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroScrollViewer), new FrameworkPropertyMetadata(typeof(MetroScrollViewer)));
        }

        public static readonly DependencyProperty FloatProperty =
            DependencyProperty.Register(nameof(Float), typeof(bool), typeof(MetroScrollViewer));

        public bool Float
        {
            get => (bool)GetValue(FloatProperty);
            set => SetValue(FloatProperty, value);
        }

        public static readonly DependencyProperty AutoLimitMouseProperty =
            DependencyProperty.Register(nameof(AutoLimitMouse), typeof(bool), typeof(MetroScrollViewer));

        public bool AutoLimitMouse
        {
            get => (bool)GetValue(AutoLimitMouseProperty);
            set => SetValue(AutoLimitMouseProperty, value);
        }

        public static readonly DependencyProperty VerticalMarginProperty =
            DependencyProperty.Register(nameof(VerticalMargin), typeof(Thickness), typeof(MetroScrollViewer));

        public Thickness VerticalMargin
        {
            get => (Thickness)GetValue(VerticalMarginProperty);
            set => SetValue(VerticalMarginProperty, value);
        }

        public static readonly DependencyProperty HorizontalMarginProperty =
            DependencyProperty.Register(nameof(HorizontalMargin), typeof(Thickness), typeof(MetroScrollViewer));

        public Thickness HorizontalMargin
        {
            get => (Thickness)GetValue(HorizontalMarginProperty);
            set => SetValue(HorizontalMarginProperty, value);
        }
    }
}