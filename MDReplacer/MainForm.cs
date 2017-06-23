using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace MDReplacer
{
    public partial class MainForm : Form
    {
        const int TRIGGER_DESKTOP_LEFT = 0;
        const int TRIGGER_DESKTOP_RIGHT = 1;

        private MouseKeyShortcutTriggerer triggerer = new MouseKeyShortcutTriggerer();
        private int shortcutKey = (int) Keys.LShiftKey;
        private Properties.Settings defaultSettings = Properties.Settings.Default;

        public MainForm()
        {
            InitializeComponent();
            LoadSettings();
        }

        #region AppSettings
        /// <summary>
        /// Loads the application settings stored.
        /// </summary>
        private void LoadSettings()
        {
            HideFromTrayCheckBox.Checked = defaultSettings.HideFromTray;
            ignoreLoadWithWindowsCheckboxChange = true;
            LoadWithWindowsCheckBox.Checked = IsLoadingWithWindows();
            ignoreLoadWithWindowsCheckboxChange = false;
        }

        private void HideFromTrayCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the application was not loaded yet, don't prompt the dialog box
            if (!Visible) return;

            defaultSettings.HideFromTray = HideFromTrayCheckBox.Checked;
            defaultSettings.Save();

            if (HideFromTrayCheckBox.Checked)
            {
                if (MessageBox.Show("Are you sure you want to hide the application from the tray? If so - if you want to close this app manually using the Task Manager", 
                    "Are you sure?", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    HideFromTrayCheckBox.Checked = false;
                }
            }
        }

        private bool ignoreLoadWithWindowsCheckboxChange = false;

        private void LoadWithWindowsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the application was not loaded yet, don't prompt the dialog box
            if (!Visible) return;

            // Sometimes we change the settings using code, and we don't want to prompt anything
            if (ignoreLoadWithWindowsCheckboxChange) return;

            // If we don't have admin permissions, we are not allowed to touch the registry
            if (!UAC.IsAdministrator())
            {
                if (MessageBox.Show("To allow the application to load with Windows you must allow it to run as administartor, click OK to continue",
                "Run as administrator", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                {
                    ignoreLoadWithWindowsCheckboxChange = true;
                    LoadWithWindowsCheckBox.Checked = !LoadWithWindowsCheckBox.Checked;
                    ignoreLoadWithWindowsCheckboxChange = false;
                    return;
                }

                UAC.RunAsAdministrator();
                return;
            }

            var runKey = GetRunRegistryKey(true);

            // Add the application to load with windows
            if (LoadWithWindowsCheckBox.Checked)
                runKey.SetValue("MDReplacer", String.Format("\"{0}\" --hide", Application.ExecutablePath));
            else
                runKey.DeleteValue("MDReplacer");
        }

        private RegistryKey GetRunRegistryKey(bool writeable)
        {
            return Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", writeable);
        }

        private bool IsLoadingWithWindows()
        {
            var key = GetRunRegistryKey(false);
            var exists = key.GetValue("MDReplacer") != null;
            key.Close();
            return exists;
        }
        #endregion

        #region NotifyIcon
        private void ShowNotifyIcon()
        {
            notifyIcon.Visible = true;
        }

        /// <summary>
        /// Show up the application when clicking on the notify icon in the taskbar.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void openMenuItem_Click(object sender, EventArgs e)
        {
            Show();
        }
        #endregion

        #region Window Methods
        /// <summary>
        /// Register all triggers and hide window if requested in command line.
        /// </summary>
        /// <param name="e"></param>
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

        /// <summary>
        /// Hide the window and show it in the taskbar or not according to the configurations.
        /// </summary>
        /// <param name="showInTaskbar"></param>
        private new void Hide()
        {
            BeginInvoke(new MethodInvoker(() =>
            {
                Visible = false;

                if (!defaultSettings.HideFromTray)
                    ShowNotifyIcon();
            }));
        }

        /// <summary>
        /// Shows the window and hides the tray icon.
        /// </summary>
        private new void Show()
        {
            base.Show();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        /// <summary>
        /// When resizing the window we want to hide the application (either in the tray or away from the user)
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (WindowState == FormWindowState.Minimized)
                Hide();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            triggerer.Uninstall();
            notifyIcon.Visible = false;
        }
        #endregion

        #region Detect Triggers And Move Desktops
        private void Triggerer_OnTrigger(int triggerId)
        {
            if (triggerId == TRIGGER_DESKTOP_LEFT)
                DeskReplaceUtil.LeftDesktop();
            else if (triggerId == TRIGGER_DESKTOP_RIGHT)
                DeskReplaceUtil.RightDesktop();
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
        #endregion

        /// <summary>
        /// Open up links clicked on.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(((LinkLabel)sender).Tag.ToString());
        }
    }
}
