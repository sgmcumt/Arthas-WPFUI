using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroMenuTabControl : TabControl
    {
        static MetroMenuTabControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroMenuTabControl), new FrameworkPropertyMetadata(typeof(MetroMenuTabControl)));
        }

        public static readonly DependencyProperty TabPanelVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(TabPanelVerticalAlignment), typeof(VerticalAlignment), typeof(MetroMenuTabControl));

        public VerticalAlignment TabPanelVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(TabPanelVerticalAlignmentProperty);
            set => SetValue(TabPanelVerticalAlignmentProperty, value);
        }

        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register(nameof(Offset), typeof(Thickness), typeof(MetroMenuTabControl));

        public Thickness Offset
        {
            get => (Thickness)GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }

        public static readonly DependencyProperty IconModeProperty =
            DependencyProperty.Register(nameof(IconMode), typeof(bool), typeof(MetroMenuTabControl), new FrameworkPropertyMetadata(false, OnIconModeChanged));

        public bool IconMode
        {
            get => (bool)GetValue(IconModeProperty);
            set => SetValue(IconModeProperty, value);
        }

        static void OnIconModeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MetroMenuTabControl)d).OnIconModeChanged();
        }

        void OnIconModeChanged()
        {
            GoToState();
        }

        void GoToState()
        {
            VisualStateManager.GoToState(this, IconMode ? "EnterIconMode" : "ExitIconMode", false);
        }

        void SelectionState()
        {
            if (IconMode)
            {
                VisualStateManager.GoToState(this, "SelectionStartIconMode", false);
                VisualStateManager.GoToState(this, "SelectionEndIconMode", false);
            }
            else
            {
                VisualStateManager.GoToState(this, "SelectionStart", false);
                VisualStateManager.GoToState(this, "SelectionEnd", false);
            }
        }

        MetroFocusButton PART_Button;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Button = GetTemplateChild(nameof(PART_Button)) as MetroFocusButton;
            if (PART_Button != null)
                PART_Button.Click += delegate
                {
                    IconMode = !IconMode;
                    GoToState();
                };
        }

        public MetroMenuTabControl()
        {
            Loaded += delegate
            {
                GoToState();
                VisualStateManager.GoToState(this, IconMode ? "SelectionLoadedIconMode" : "SelectionLoaded", false);
            };
            SelectionChanged += delegate(object sender, SelectionChangedEventArgs e)
            {
                if (e.Source is MetroMenuTabControl)
                    SelectionState();
            };
        }
    }
}