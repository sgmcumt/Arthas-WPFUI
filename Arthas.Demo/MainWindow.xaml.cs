using System;
using System.Windows;
using System.Windows.Threading;
using Arthas.Controls;

namespace Arthas.Demo
{
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            Ts.IsChecked = true;

            Exit.Click += delegate
            {
                Close();
            };

            TreeView.SizeChanged += delegate
            {
                WaterfallFlow.Refresh();
            };

            var timer = new DispatcherTimer();
            timer.Tick += delegate
            {
                Pb1.Value = Pb1.Value + 1 > Pb1.Maximum ? 0 : Pb1.Value + 1;
                Pb2.Value = Pb2.Value + 1 > Pb2.Maximum ? 0 : Pb2.Value + 1;
                Pb2.Title = Pb2.Hint;
                Pb2.Hint = null;
            };
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
            timer.Start();

            foreach (FrameworkElement fe in Lists.Children)
                if (fe is MetroExpander expander)
                    expander.Click += delegate(object sender, EventArgs e)
                    {
                        if (!((MetroExpander)fe).CanHide)
                            return;
                        foreach (FrameworkElement fe1 in Lists.Children)
                            if (fe1 is MetroExpander metroExpander && fe1 != sender)
                                metroExpander.IsExpanded = false;
                    };
        }
    }
}