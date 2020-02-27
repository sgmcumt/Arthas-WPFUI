using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Arthas.Utility.Element;

namespace Arthas.Controls
{
    public class MetroVisualElement : ContentControl
    {
        public static readonly DependencyProperty VisualProperty = ElementBase.Property<MetroVisualElement, Visual>(nameof(VisualProperty));
        public static readonly DependencyProperty VisualOpacityProperty = ElementBase.Property<MetroVisualElement, double>(nameof(VisualOpacityProperty));
        public static readonly DependencyProperty VisualBlurRadiusProperty = ElementBase.Property<MetroVisualElement, double>(nameof(VisualBlurRadiusProperty));
        public static readonly DependencyProperty LeftProperty = ElementBase.Property<MetroVisualElement, double>(nameof(LeftProperty));
        public static readonly DependencyProperty TopProperty = ElementBase.Property<MetroVisualElement, double>(nameof(TopProperty));

        public Visual Visual
        {
            get => (Visual)GetValue(VisualProperty);
            set => SetValue(VisualProperty, value);
        }

        public new double VisualOpacity
        {
            get => (double)GetValue(VisualOpacityProperty);
            set => SetValue(VisualOpacityProperty, value);
        }

        public double VisualBlurRadius
        {
            get => (double)GetValue(VisualBlurRadiusProperty);
            set => SetValue(VisualBlurRadiusProperty, value);
        }

        public double Left
        {
            get => (double)GetValue(LeftProperty);
            set => SetValue(LeftProperty, value);
        }

        public double Top
        {
            get => (double)GetValue(TopProperty);
            set => SetValue(TopProperty, value);
        }

        static MetroVisualElement()
        {
            ElementBase.DefaultStyle<MetroVisualElement>(DefaultStyleKeyProperty);
        }
    }
}