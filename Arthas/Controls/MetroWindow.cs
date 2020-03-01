using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using Arthas.Interop;
using ControlzEx.Behaviors;

namespace Arthas.Controls
{
    public class MetroWindow : Window
    {
        static MetroWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroWindow), new FrameworkPropertyMetadata(typeof(MetroWindow)));
        }

        public static readonly DependencyProperty CaptionContentProperty =
            DependencyProperty.Register(nameof(CaptionContent), typeof(object), typeof(MetroWindow));

        public object CaptionContent
        {
            get => GetValue(CaptionContentProperty);
            set => SetValue(CaptionContentProperty, value);
        }

        public static readonly DependencyProperty CaptionBackgroundProperty =
            DependencyProperty.Register(nameof(CaptionBackground), typeof(Brush), typeof(MetroWindow));

        public Brush CaptionBackground
        {
            get => (Brush)GetValue(CaptionBackgroundProperty);
            set => SetValue(CaptionBackgroundProperty, value);
        }

        public static readonly DependencyProperty CaptionForegroundProperty =
            DependencyProperty.Register(nameof(CaptionForeground), typeof(Brush), typeof(MetroWindow));

        public Brush CaptionForeground
        {
            get => (Brush)GetValue(CaptionForegroundProperty);
            set => SetValue(CaptionForegroundProperty, value);
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

        Border PART_Caption;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            PART_Caption = GetTemplateChild(nameof(PART_Caption)) as Border;
            SetCaption(PART_Caption);
        }

        public void SetCaption(FrameworkElement element)
        {
            if (element == null)
                return;

            element.MouseLeftButtonDown += delegate(object sender, MouseButtonEventArgs e)
            {
                var handle = new WindowInteropHelper(this).Handle;
                if (handle == IntPtr.Zero)
                    return;

                if (e.ClickCount == 2)
                    switch (ResizeMode)
                    {
                        case ResizeMode.CanResize:
                        case ResizeMode.CanResizeWithGrip:

                            switch (WindowState)
                            {
                                case WindowState.Normal:
                                    SystemCommands.MaximizeWindow(this);
                                    break;

                                case WindowState.Maximized:
                                    SystemCommands.RestoreWindow(this);
                                    break;
                            }

                            break;
                    }
                else
                    NativeMethods.SendMessage(handle, WindowsMessages.NCLBUTTONDOWN, (IntPtr)HitTest.CAPTION, IntPtr.Zero);
            };
        }
    }
}