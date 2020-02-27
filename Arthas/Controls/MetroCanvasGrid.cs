using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroCanvasGrid : ContentControl
    {
        static MetroCanvasGrid()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroCanvasGrid), new FrameworkPropertyMetadata(typeof(MetroCanvasGrid)));
        }

        public static readonly DependencyProperty ViewportProperty =
            DependencyProperty.Register(nameof(Viewport), typeof(Rect), typeof(MetroCanvasGrid));

        public Rect Viewport
        {
            get => (Rect)GetValue(ViewportProperty);
            set => SetValue(ViewportProperty, value);
        }

        public static readonly DependencyProperty GridOpacityProperty =
            DependencyProperty.Register(nameof(GridOpacity), typeof(double), typeof(MetroCanvasGrid));

        public double GridOpacity
        {
            get => (double)GetValue(GridOpacityProperty);
            set => SetValue(GridOpacityProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(MetroCanvasGrid));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public bool IsApplyTheme { get; set; } = true;
    }
}