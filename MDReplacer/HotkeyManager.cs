using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MDReplacer
{
    public class HotkeyManager
    {
        public static int WM_HOTKEY = 0x0312;

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vk);

        public delegate void HotkeyPressedHandler(int shortcutTag);
        public event HotkeyPressedHandler OnHotkeyPressed;

        public enum Modifiers
        {
            ALT = 0x0001,
            CONTROL = 0x0002,
            SHIFT = 0x0004,
            WIN = 0x0008
        }

        private IntPtr windowHandle;

        public HotkeyManager(IntPtr windowHandle)
        {
            this.windowHandle = windowHandle;
        }

        public void Register(int shortcutTag, Modifiers modifiers, Keys keys)
        {
            RegisterHotKey(windowHandle, shortcutTag, (int) modifiers, (int) keys);
        }
    }
}
