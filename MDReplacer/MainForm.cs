using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MDReplacer
{
    public partial class MainForm : Form
    {
        const int TRIGGER_DESKTOP_LEFT = 0;
        const int TRIGGER_DESKTOP_RIGHT = 1;

        private MouseKeyShortcutTriggerer triggerer = new MouseKeyShortcutTriggerer();
        private int shortcutKey = (int) Keys.LShiftKey;

        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            triggerer.OnTrigger += Triggerer_OnTrigger;
            triggerer.Install();
            RegisterTriggers();
        }

        private void Triggerer_OnTrigger(int triggerId)
        {
            if (triggerId == TRIGGER_DESKTOP_LEFT)
                DeskReplaceUtil.LeftDesktop();
            else if (triggerId == TRIGGER_DESKTOP_RIGHT)
                DeskReplaceUtil.RightDesktop();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            triggerer.Uninstall();
        }

        private void RegisterTriggers()
        {
            triggerer.RegisterTrigger(
                new MouseKeyShortcutTriggerer.MouseKeyShortcutTrigger(TRIGGER_DESKTOP_LEFT,
                new int[] { shortcutKey }, null,
                (int) InputManager.MouseHook.MouseWheelEvents.ScrollDown));

            triggerer.RegisterTrigger(
                new MouseKeyShortcutTriggerer.MouseKeyShortcutTrigger(TRIGGER_DESKTOP_RIGHT,
                new int[] { shortcutKey }, null,
                (int)InputManager.MouseHook.MouseWheelEvents.ScrollUp));
        }
    }
}
