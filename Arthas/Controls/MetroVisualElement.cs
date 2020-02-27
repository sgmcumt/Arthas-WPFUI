using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroVisualElement : ContentControl
    {
        static MetroVisualElement()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroVisualElement), new FrameworkPropertyMetadata(typeof(MetroVisualElement)));
        }

        public static readonly DependencyProperty VisualProperty =
            DependencyProperty.Register(nameof(Visual), typeof(Visual), typeof(MetroVisualElement));

        public Visual Visual
        {
            get => (Visual)GetValue(VisualProperty);
            set => SetValue(VisualProperty, value);
        }

        public static readonly DependencyProperty VisualOpacityProperty =
            DependencyProperty.Register(nameof(VisualOpacity), typeof(double), typeof(MetroVisualElement));

        public new double VisualOpacity
        {
            get => (double)GetValue(VisualOpacityProperty);
            set => SetValue(VisualOpacityProperty, value);
        }

        public static readonly DependencyProperty VisualBlurRadiusProperty =
            DependencyProperty.Register(nameof(VisualBlurRadius), typeof(double), typeof(MetroVisualElement));

        public double VisualBlurRadius
        {
            get => (double)GetValue(VisualBlurRadiusProperty);
            set => SetValue(VisualBlurRadiusProperty, value);
        }

        public static readonly DependencyProperty LeftProperty =
            DependencyProperty.Register(nameof(Left), typeof(double), typeof(MetroVisualElement));

        public double Left
        {
            get => (double)GetValue(LeftProperty);
            set => SetValue(LeftProperty, value);
        }

        public static readonly DependencyProperty TopProperty =
            DependencyProperty.Register(nameof(Top), typeof(double), typeof(MetroVisualElement));

        public double Top
        {
            get => (double)GetValue(TopProperty);
            set => SetValue(TopProperty, value);
        }
    }
}