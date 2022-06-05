namespace MyDesign
{
    using System;
    using System.Runtime.InteropServices;

    internal static class NativeMethods
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg = 0xA1, int wParam = 0x2, int lParam = 0);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
    }
}
