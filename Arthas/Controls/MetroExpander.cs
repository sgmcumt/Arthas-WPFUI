using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Arthas.Utility.Element;

namespace Arthas.Controls
{
    public class MetroExpander : ContentControl
    {
        static MetroExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroExpander), new FrameworkPropertyMetadata(typeof(MetroExpander)));
        }

        public static readonly DependencyProperty IsExpandedProperty = ElementBase.Property<MetroExpander, bool>(nameof(IsExpandedProperty));
        public static readonly DependencyProperty CanHideProperty = ElementBase.Property<MetroExpander, bool>(nameof(CanHideProperty));
        public static readonly DependencyProperty HeaderProperty = ElementBase.Property<MetroExpander, string>(nameof(HeaderProperty));
        public static readonly DependencyProperty HintProperty = ElementBase.Property<MetroExpander, string>(nameof(HintProperty));
        public static readonly DependencyProperty HintBackgroundProperty = ElementBase.Property<MetroExpander, Brush>(nameof(HintBackgroundProperty));
        public static readonly DependencyProperty HintForegroundProperty = ElementBase.Property<MetroExpander, Brush>(nameof(HintForegroundProperty));
        public static readonly DependencyProperty IconProperty = ElementBase.Property<MetroExpander, ImageSource>(nameof(IconProperty), null);

        public static RoutedUICommand ButtonClickCommand = ElementBase.Command<MetroExpander>(nameof(ButtonClickCommand));

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set
            {
                SetValue(IsExpandedProperty, value);
                ElementBase.GoToState(this, IsExpanded ? "Expand" : "Normal");
            }
        }

        public bool CanHide
        {
            get => (bool)GetValue(CanHideProperty);
            set => SetValue(CanHideProperty, value);
        }

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public Brush HintBackground
        {
            get => (Brush)GetValue(HintBackgroundProperty);
            set => SetValue(HintBackgroundProperty, value);
        }

        public Brush HintForeground
        {
            get => (Brush)GetValue(HintForegroundProperty);
            set => SetValue(HintForegroundProperty, value);
        }

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public event EventHandler Click;

        public MetroExpander()
        {
            Loaded += delegate
            {
                if (Content == null)
                    IsExpanded = false;
                else if (!CanHide)
                    IsExpanded = true;
                ElementBase.GoToState(this, IsExpanded ? "StartExpand" : "StartNormal");
            };

            CommandBindings.Add(new CommandBinding(ButtonClickCommand, delegate
            {
                if (CanHide && Content != null)
                    IsExpanded = !IsExpanded;
                Click?.Invoke(this, null);
            }));
        }

        public void Clear()
        {
            Content = new StackPanel();
        }

        public UIElementCollection Children
        {
            get
            {
                switch (Content)
                {
                    case StackPanel _:
                        return (Content as StackPanel)?.Children;

                    case Grid _:
                        return (Content as Grid)?.Children;

                    default:
                        return null;
                }
            }
        }

        public void Add(FrameworkElement element)
        {
            if (!(Content is StackPanel stackPanel))
                Content = new StackPanel();
            (Content as StackPanel)?.Children.Add(element);
        }
    }
}