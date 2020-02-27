using System;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace Arthas.Controls
{
    public class MetroThumb : Thumb
    {
        public double OldX { get; set; }
        public double OldY { get; set; }
        public double OffsetX { get; set; } = 0.0;
        public double OffsetY { get; set; } = 0.0;

        public static readonly DependencyProperty XProperty =
            DependencyProperty.Register(nameof(X), typeof(double), typeof(MetroThumb), new FrameworkPropertyMetadata(-1, OnXChanged));

        public double X
        {
            get => (double)GetValue(XProperty);
            set => SetValue(XProperty, value);
        }

        static void OnXChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MetroThumb)d).OnChange();
        }

        public static readonly DependencyProperty YProperty =
            DependencyProperty.Register(nameof(Y), typeof(double), typeof(MetroThumb), new FrameworkPropertyMetadata(-1, OnYChanged));

        public double Y
        {
            get => (double)GetValue(YProperty);
            set => SetValue(YProperty, value);
        }

        static void OnYChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MetroThumb)d).OnChange();
        }

        public event EventHandler ValueChange;

        public MetroThumb()
        {
            Focusable = true;
            FocusVisualStyle = null;

            Loaded += delegate
            {
                X = Math.Max(X, 0);
                Y = Math.Max(Y, 0);
            };
            DragStarted += delegate(object sender, DragStartedEventArgs e)
            {
                Focus();

                OldX = e.HorizontalOffset;
                OldY = e.VerticalOffset;

                X = OldX;
                Y = OldY;
            };
            DragDelta += delegate(object sender, DragDeltaEventArgs e)
            {
                var x = OldX + e.HorizontalChange;
                var y = OldY + e.VerticalChange;

                if (x < 0)
                    X = 0;
                else if (x > ActualWidth)
                    X = ActualWidth;
                else
                    X = x;

                if (y < 0)
                    Y = 0;
                else if (y > ActualHeight)
                    Y = ActualHeight;
                else
                    Y = y;
            };
        }

        public double XPercent
        {
            get => X / ActualWidth;
            set => X = ActualWidth * value;
        }

        public double YPercent
        {
            get => Y / ActualHeight;
            set => Y = ActualHeight * value;
        }

        void OnChange()
        {
            ValueChange?.Invoke(this, null);
        }
    }
}