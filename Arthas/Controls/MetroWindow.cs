using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Arthas.Utility.Element;
using ControlzEx.Behaviors;

namespace Arthas.Controls
{
    public class MetroWindow : Window
    {
        static MetroWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(typeof(MetroWindow)));
        }

        public static readonly DependencyProperty IsSubWindowShowProperty = ElementBase.Property<MetroWindow, bool>(nameof(IsSubWindowShowProperty), false);
        public static readonly DependencyProperty MenuProperty = ElementBase.Property<MetroWindow, object>(nameof(MenuProperty), null);
        public new static readonly DependencyProperty BorderBrushProperty = ElementBase.Property<MetroWindow, Brush>(nameof(BorderBrushProperty));
        public static readonly DependencyProperty TitleForegroundProperty = ElementBase.Property<MetroWindow, Brush>(nameof(TitleForegroundProperty));

        public bool IsSubWindowShow
        {
            get => (bool)GetValue(IsSubWindowShowProperty);
            set
            {
                SetValue(IsSubWindowShowProperty, value);
                GoToState();
            }
        }

        public object Menu
        {
            get => GetValue(MenuProperty);
            set => SetValue(MenuProperty, value);
        }

        public new Brush BorderBrush
        {
            get => (Brush)GetValue(BorderBrushProperty);
            set => SetValue(BorderBrushProperty, value);
        }

        public Brush TitleForeground
        {
            get => (Brush)GetValue(TitleForegroundProperty);
            set => SetValue(TitleForegroundProperty, value);
        }

        void GoToState()
        {
            ElementBase.GoToState(this, IsSubWindowShow ? "Enabled" : "Disable");
        }

        public object ReturnValue { get; set; } = null;
        public bool EscClose { get; set; } = false;

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