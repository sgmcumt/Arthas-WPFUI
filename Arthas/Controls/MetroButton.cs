using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public enum ButtonState
    {
        None,
        Red,
        Green
    }

    public class MetroButton : Button
    {
        static MetroButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroButton), new FrameworkPropertyMetadata(typeof(MetroButton)));
        }

        public static readonly DependencyProperty MetroButtonStateProperty =
            DependencyProperty.Register(nameof(MetroButtonState), typeof(ButtonState), typeof(MetroButton));

        public ButtonState MetroButtonState
        {
            get => (ButtonState)GetValue(MetroButtonStateProperty);
            set => SetValue(MetroButtonStateProperty, value);
        }
    }
}