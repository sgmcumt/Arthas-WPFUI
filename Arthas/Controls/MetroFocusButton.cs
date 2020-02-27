using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroFocusButton : Button
    {
        static MetroFocusButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroFocusButton), new FrameworkPropertyMetadata(typeof(MetroFocusButton)));
        }

        public static readonly DependencyProperty MouseMoveForegroundProperty =
            DependencyProperty.Register(nameof(MouseMoveForeground), typeof(Brush), typeof(MetroFocusButton));

        public Brush MouseMoveForeground
        {
            get => (Brush)GetValue(MouseMoveForegroundProperty);
            set => SetValue(MouseMoveForegroundProperty, value);
        }

        public static readonly DependencyProperty MouseMoveBorderBrushProperty =
            DependencyProperty.Register(nameof(MouseMoveBorderBrush), typeof(Brush), typeof(MetroFocusButton));

        public Brush MouseMoveBorderBrush
        {
            get => (Brush)GetValue(MouseMoveBorderBrushProperty);
            set => SetValue(MouseMoveBorderBrushProperty, value);
        }

        public new static readonly DependencyProperty BorderThicknessProperty =
            DependencyProperty.Register(nameof(BorderThickness), typeof(double), typeof(MetroFocusButton));

        public new double BorderThickness
        {
            get => (double)GetValue(BorderThicknessProperty);
            set => SetValue(BorderThicknessProperty, value);
        }

        public static readonly DependencyProperty MouseMoveBorderThicknessProperty =
            DependencyProperty.Register(nameof(MouseMoveBorderThickness), typeof(double), typeof(MetroFocusButton));

        public double MouseMoveBorderThickness
        {
            get => (double)GetValue(MouseMoveBorderThicknessProperty);
            set => SetValue(MouseMoveBorderThicknessProperty, value);
        }

        public static readonly DependencyProperty StrokeDashArrayProperty =
            DependencyProperty.Register(nameof(StrokeDashArray), typeof(DoubleCollection), typeof(MetroFocusButton));

        public DoubleCollection StrokeDashArray
        {
            get => (DoubleCollection)GetValue(StrokeDashArrayProperty);
            set => SetValue(StrokeDashArrayProperty, value);
        }

        public static readonly DependencyProperty MouseMoveStrokeDashArrayProperty =
            DependencyProperty.Register(nameof(MouseMoveStrokeDashArray), typeof(DoubleCollection), typeof(MetroFocusButton));

        public DoubleCollection MouseMoveStrokeDashArray
        {
            get => (DoubleCollection)GetValue(MouseMoveStrokeDashArrayProperty);
            set => SetValue(MouseMoveStrokeDashArrayProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(MetroFocusButton));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
    }
}