using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroGroupBox : GroupBox
    {
        static MetroGroupBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroGroupBox), new FrameworkPropertyMetadata(typeof(MetroGroupBox)));
        }
    }
}