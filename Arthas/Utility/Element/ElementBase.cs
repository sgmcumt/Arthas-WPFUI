using System.Windows;
using System.Windows.Input;

namespace Arthas.Utility.Element
{
    public static class ElementBase
    {
        public static DependencyProperty Property<T, TProperty>(string name, TProperty defaultValue)
        {
            return DependencyProperty.Register(name.Replace("Property", ""), typeof(TProperty), typeof(T), new PropertyMetadata(defaultValue));
        }

        public static DependencyProperty Property<T, TProperty>(string name)
        {
            return DependencyProperty.Register(name.Replace("Property", ""), typeof(TProperty), typeof(T));
        }

        public static void DefaultStyle<T>(DependencyProperty dp)
        {
            dp.OverrideMetadata(typeof(T), new FrameworkPropertyMetadata(typeof(T)));
        }

        public static RoutedUICommand Command<T>(string name)
        {
            return new RoutedUICommand(name, name, typeof(T));
        }

        public static string GoToState(FrameworkElement element, string state)
        {
            VisualStateManager.GoToState(element, state, false);
            return state;
        }
    }
}