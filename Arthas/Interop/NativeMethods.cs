using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Arthas.Interop
{
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    public static partial class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, WindowsMessages msg, IntPtr wParam, IntPtr lParam);

        [DllImport("User32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);
    }
}