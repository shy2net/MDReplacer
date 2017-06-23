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

            // Hide the window if specified (used for startup)
            foreach (var command in Environment.GetCommandLineArgs())
                if (command == "--hide") Hide();
        }

        private void Hide(bool showInTaskbar = false)
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                Visible = false;

                if (showInTaskbar)
                    ShowNotifyIcon();
            }));
        }
        
        private void ShowNotifyIcon()
        {
            notifyIcon.Visible = true;
        }

        private void Triggerer_OnTrigger(int triggerId)
        {
            if (triggerId == TRIGGER_DESKTOP_LEFT)
                DeskReplaceUtil.LeftDesktop();
            else if (triggerId == TRIGGER_DESKTOP_RIGHT)
                DeskReplaceUtil.RightDesktop();
        }

        /// <summary>
        /// When resizing the window we want to hide the application (either in the tray or away from the user)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState == FormWindowState.Minimized)
                Hide(true);
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            triggerer.Uninstall();
            notifyIcon.Visible = false;
        }

        /// <summary>
        /// Register all of the triggers so we will know then use is trying to move between desktops.
        /// </summary>
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

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Tag.ToString());
        }
    }
}
