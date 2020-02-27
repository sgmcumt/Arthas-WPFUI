using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Arthas.Controls
{
    public class MetroTextBox : TextBox
    {
        static MetroTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTextBox), new FrameworkPropertyMetadata(typeof(MetroTextBox)));
        }

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(nameof(Title), typeof(string), typeof(MetroTextBox));

        public string Title
        {
            get => (string)GetValue(TitleProperty);
            set => SetValue(TitleProperty, value);
        }

        public static readonly DependencyProperty TitleMinWidthProperty =
            DependencyProperty.Register(nameof(TitleMinWidth), typeof(double), typeof(MetroTextBox));

        public double TitleMinWidth
        {
            get => (double)GetValue(TitleMinWidthProperty);
            set => SetValue(TitleMinWidthProperty, value);
        }

        public static readonly DependencyProperty TitleForegroundProperty =
            DependencyProperty.Register(nameof(TitleForeground), typeof(Brush), typeof(MetroTextBox));

        public Brush TitleForeground
        {
            get => (Brush)GetValue(TitleForegroundProperty);
            set => SetValue(TitleForegroundProperty, value);
        }

        public static readonly DependencyProperty MouseMoveBackgroundProperty =
            DependencyProperty.Register(nameof(MouseMoveBackground), typeof(Brush), typeof(MetroTextBox));

        public Brush MouseMoveBackground
        {
            get => (Brush)GetValue(MouseMoveBackgroundProperty);
            set => SetValue(MouseMoveBackgroundProperty, value);
        }

        public static readonly DependencyProperty InputHintProperty =
            DependencyProperty.Register(nameof(InputHint), typeof(string), typeof(MetroTextBox));

        public string InputHint
        {
            get => (string)GetValue(InputHintProperty);
            set => SetValue(InputHintProperty, value);
        }

        public static readonly DependencyProperty PopupHintProperty =
            DependencyProperty.Register(nameof(PopupHint), typeof(string), typeof(MetroTextBox));

        public string PopupHint
        {
            get => (string)GetValue(PopupHintProperty);
            set => SetValue(PopupHintProperty, value);
        }

        public static readonly DependencyProperty ButtonTitleProperty =
            DependencyProperty.Register(nameof(ButtonTitle), typeof(string), typeof(MetroTextBox));

        public string ButtonTitle
        {
            get => (string)GetValue(ButtonTitleProperty);
            set => SetValue(ButtonTitleProperty, value);
        }

        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register(nameof(Icon), typeof(ImageSource), typeof(MetroTextBox));

        public ImageSource Icon
        {
            get => (ImageSource)GetValue(IconProperty);
            set => SetValue(IconProperty, value);
        }

        public static readonly DependencyProperty StateProperty =
            DependencyProperty.Register(nameof(State), typeof(string), typeof(MetroTextBox));

        public string State
        {
            get => (string)GetValue(StateProperty);
            set => SetValue(StateProperty, value);
        }

        public static readonly DependencyProperty MultipleLineProperty =
            DependencyProperty.Register(nameof(MultipleLine), typeof(bool), typeof(MetroTextBox));

        public bool MultipleLine
        {
            get => (bool)GetValue(MultipleLineProperty);
            set => SetValue(MultipleLineProperty, value);
        }

        public static readonly DependencyProperty IsPassWordBoxProperty =
            DependencyProperty.Register(nameof(IsPassWordBox), typeof(bool), typeof(MetroTextBox));

        public bool IsPassWordBox
        {
            get => (bool)GetValue(IsPassWordBoxProperty);
            set => SetValue(IsPassWordBoxProperty, value);
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register(nameof(CornerRadius), typeof(CornerRadius), typeof(MetroTextBox));

        public CornerRadius CornerRadius
        {
            get => (CornerRadius)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }

        public Func<string, bool> ErrorCheckAction { get; set; }

        public event EventHandler ButtonClick;

        Button PART_Button;

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            PART_Button = GetTemplateChild(nameof(PART_Button)) as Button;
            if (PART_Button != null)
                PART_Button.Click += delegate
                {
                    ButtonClick?.Invoke(this, EventArgs.Empty);
                };
        }

        public MetroTextBox()
        {
            ContextMenu = null;
            Loaded += delegate
            {
                ErrorCheck();
            };
            TextChanged += delegate
            {
                ErrorCheck();
            };
        }

        void ErrorCheck()
        {
            // if (PopupHint == null || PopupHint == "") { PopupHint = InputHint; }
            if (ErrorCheckAction != null)
                State = ErrorCheckAction(Text) ? "true" : "false";
        }
    }
}