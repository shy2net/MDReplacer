using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using InputManager;
using System.Windows.Forms;

namespace MDReplacer
{
    /// <summary>
    /// A small util class responsible for managing the logic to move between desktops.
    /// </summary>
    public static class DeskReplaceUtil
    {
        public static void LeftDesktop()
        {
            InputManager.VirtualKeyboard.ShortcutKeys(new Keys[] { Keys.LControlKey, Keys.LWin, Keys.Left });
        }

        public static void RightDesktop()
        {
            InputManager.VirtualKeyboard.ShortcutKeys(new Keys[] { Keys.LControlKey, Keys.LWin, Keys.Right });
        }
    }
}
