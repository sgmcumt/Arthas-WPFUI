using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using ControlzEx.Behaviors;

namespace Arthas.Controls
{
    public class MetroWindow : Window
    {
        static MetroWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(typeof(MetroWindow)));
        }

        public static readonly DependencyProperty IsSubWindowShowProperty =
            DependencyProperty.Register(nameof(IsSubWindowShow), typeof(bool), typeof(MetroWindow));

        public bool IsSubWindowShow
        {
            get => (bool)GetValue(IsSubWindowShowProperty);
            set => SetValue(IsSubWindowShowProperty, value);
        }

        public static readonly DependencyProperty MenuProperty =
            DependencyProperty.Register(nameof(Menu), typeof(object), typeof(MetroWindow));

        public object Menu
        {
            get => GetValue(MenuProperty);
            set => SetValue(MenuProperty, value);
        }

        public new static readonly DependencyProperty BorderBrushProperty =
            DependencyProperty.Register(nameof(BorderBrush), typeof(Brush), typeof(MetroWindow));

        public new Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register(nameof(TitleForeground), typeof(Brush), typeof(MetroWindow));

        public Brush TitleForeground
        {
            get => (Brush)GetValue(TitleForegroundProperty);
            set => SetValue(TitleForegroundProperty, value);
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            AllowsTransparency = false;
            if (WindowStyle == WindowStyle.None)
                WindowStyle = WindowStyle.SingleBorderWindow;
        }

        public MetroWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, delegate
            {
                SystemCommands.MinimizeWindow(this);
            }));
            CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, delegate
            {
                SystemCommands.MaximizeWindow(this);
            }));
            CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, delegate
            {
                SystemCommands.RestoreWindow(this);
            }));
            CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, delegate
            {
                SystemCommands.CloseWindow(this);
            }));

            new WindowChromeBehavior
            {
                KeepBorderOnMaximize = true,
                ResizeBorderThickness = new Thickness(2)
            }.Attach(this);
            new GlowWindowBehavior
            {
                ResizeBorderThickness = new Thickness(9),
                GlowBrush = new SolidColorBrush(Color.FromArgb((byte)(32 * 2.55), 0, 0, 0)),
                NonActiveGlowBrush = new SolidColorBrush(Color.FromArgb((byte)(12 * 2.55), 0, 0, 0))
            }.Attach(this);
        }
    }
}