using System;
using System.Runtime.InteropServices;

namespace DomainApp1.Tools
{
    //
    // https://stackoverflow.com/questions/35263590/programmatically-set-console-window-size-and-position?rq=1
    //
    class ConsoleWindowHelper
    {
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetConsoleWindow();

        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        public static void SetPosition(int x, int y,int width,int height)
        {
            var ptr = GetConsoleWindow();
            MoveWindow(ptr, x, y, width, height, true);
        }
    }
}
