using System;
using System.Runtime.InteropServices;
using System.Diagnostics;


namespace RefplusWebtools
{

    class FocusApplication
    {
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);

        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("User32.dll", EntryPoint = "ShowWindowAsync")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        private const int WsShownormal = 1;

        public static void FocusNow()
        {
            IntPtr window = Process.GetCurrentProcess().MainWindowHandle;

            SystemParametersInfo(0x2001, 0, 0, 0x0002 | 0x0001);
            ShowWindowAsync(window, WsShownormal);
            SetForegroundWindow(window);
            SystemParametersInfo(0x2001, 200000, 200000, 0x0002 | 0x0001);
        }
    }
}
