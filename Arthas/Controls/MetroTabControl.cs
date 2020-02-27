using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroTabControl : TabControl
    {
        static MetroTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTabControl), new FrameworkPropertyMetadata(typeof(MetroTabControl)));
        }

        void SelectionState()
        {
            VisualStateManager.GoToState(this, "SelectionStart", false);
            VisualStateManager.GoToState(this, "SelectionEnd", false);
        }

        public MetroTabControl()
        {
            Loaded += delegate
            {
                VisualStateManager.GoToState(this, "SelectionLoaded", false);
            };
            SelectionChanged += delegate(object sender, SelectionChangedEventArgs e)
            {
                if (e.Source is MetroTabControl)
                    SelectionState();
            };
        }
    }
}