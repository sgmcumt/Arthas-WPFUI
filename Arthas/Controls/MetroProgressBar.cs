using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public enum ProgressBarState
    {
        None,
        Error,
        Wait
    }

    public class MetroProgressBar : ProgressBar
    {
        static MetroProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroProgressBar), new FrameworkPropertyMetadata(typeof(MetroProgressBar)));
        }

        public static readonly DependencyProperty ProgressBarStateProperty =
            DependencyProperty.Register(nameof(ProgressBarState), typeof(ProgressBarState), typeof(MetroProgressBar));

        public ProgressBarState ProgressBarState
        {
            get => (ProgressBarState)GetValue(ProgressBarStateProperty);
            set => SetValue(ProgressBarStateProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(MetroProgressBar));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(MetroProgressBar));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(MetroProgressBar));

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public static readonly DependencyProperty ProgressBarHeightProperty =
            DependencyProperty.Register(nameof(ProgressBarHeight), typeof(double), typeof(MetroProgressBar));

        public double ProgressBarHeight
        {
            get => (double)GetValue(ProgressBarHeightProperty);
            set => SetValue(ProgressBarHeightProperty, value);
        }

        public static readonly DependencyProperty TextHorizontalAlignmentProperty =
            DependencyProperty.Register(nameof(TextHorizontalAlignment), typeof(HorizontalAlignment), typeof(MetroProgressBar));

        public HorizontalAlignment TextHorizontalAlignment
        {
            get => (HorizontalAlignment)GetValue(TextHorizontalAlignmentProperty);
            set => SetValue(TextHorizontalAlignmentProperty, value);
        }

        public MetroProgressBar()
        {
            ValueChanged += delegate
            {
                if (Hint == null || Hint.EndsWith(" %"))
                    Hint = (int)(Value / Maximum * 100) + " %";
            };
        }
    }
}