using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroExpander : ContentControl
    {
        static MetroExpander()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroExpander), new FrameworkPropertyMetadata(typeof(MetroExpander)));
        }

        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register(nameof(IsExpanded), typeof(bool), typeof(MetroExpander), new FrameworkPropertyMetadata(false, OnIsExpandedChanged));

        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        static void OnIsExpandedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MetroExpander)d).OnIsExpandedChanged();
        }

        void OnIsExpandedChanged()
        {
            VisualStateManager.GoToState(this, IsExpanded ? "Expand" : "Normal", false);
        }

        public static readonly DependencyProperty CanHideProperty =
            DependencyProperty.Register(nameof(CanHide), typeof(bool), typeof(MetroExpander));

        public bool CanHide
        {
            get => (bool)GetValue(CanHideProperty);
            set => SetValue(CanHideProperty, value);
        }

        public static readonly DependencyProperty HeaderProperty =
            DependencyProperty.Register(nameof(Header), typeof(string), typeof(MetroExpander));

        public string Header
        {
            get => (string)GetValue(HeaderProperty);
            set => SetValue(HeaderProperty, value);
        }

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.Register(nameof(Hint), typeof(string), typeof(MetroExpander));

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public static readonly DependencyProperty HintBackgroundProperty =
            DependencyProperty.Register(nameof(HintBackground), typeof(Brush), typeof(MetroExpander));

        public Brush HintBackground
        {
            get => (Brush)GetValue(HintBackgroundProperty);
            set => SetValue(HintBackgroundProperty, value);
        }

        public static readonly DependencyProperty HintForegroundProperty =
            DependencyProperty.Register(nameof(HintForeground), typeof(Brush), typeof(MetroExpander));

        public Brush HintForeground
        {
            get => (Brush)GetValue(HintForegroundProperty);
            set => SetValue(HintForegroundProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(MetroExpander));

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        MetroFocusButton PART_Button;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Button = GetTemplateChild(nameof(PART_Button)) as MetroFocusButton;
            if (PART_Button != null)
                PART_Button.Click += delegate
                {
                    if (CanHide && Content != null)
                        IsExpanded = !IsExpanded;
                    Click?.Invoke(this, EventArgs.Empty);
                };
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
                VisualStateManager.GoToState(this, IsExpanded ? "StartExpand" : "StartNormal", false);
            };
        }

        public void Clear()
        {
            Content = new StackPanel();
        }

        public UIElementCollection Children
        {
            get
            {
                return Content switch
                {
                    StackPanel _ => (Content as StackPanel)?.Children,
                    Grid _       => (Content as Grid)?.Children,
                    _            => null
                };
            }
        }

        public void Add(FrameworkElement element)
        {
            if (!(Content is StackPanel))
                Content = new StackPanel();
            (Content as StackPanel)?.Children.Add(element);
        }
    }
}