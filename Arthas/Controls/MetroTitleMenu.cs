using System.Windows;
using System.Windows.Controls;

namespace Arthas.Controls
{
    public class MetroTitleMenu : Menu
    {
        static MetroTitleMenu()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MetroTitleMenu), new FrameworkPropertyMetadata(typeof(MetroTitleMenu)));
        }
    }
}