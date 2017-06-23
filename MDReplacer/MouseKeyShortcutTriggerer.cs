using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MDReplacer
{
    public class MouseKeyShortcutTriggerer
    {
        public delegate void OnTriggerHandler(int triggerId);
        public event OnTriggerHandler OnTrigger;

        private List<MouseKeyShortcutTrigger> triggers = new List<MouseKeyShortcutTrigger>();
        private List<int> keysHeld = new List<int>();
        private List<int> mouseKeysHeld = new List<int>();

        public MouseKeyShortcutTriggerer()
        {
            /* Start listening to all of the events */
            InputManager.KeyboardHook.KeyDown += KeyboardHook_KeyDown;
            InputManager.KeyboardHook.KeyUp += KeyboardHook_KeyUp;
            InputManager.MouseHook.MouseEvent += MouseHook_MouseEvent;
            InputManager.MouseHook.WheelEvent += MouseHook_WheelEvent;
        }

        /// <summary>
        /// Starts hooking up to listen to mouse and keyboard inputs globally.
        /// </summary>
        public void Install()
        {
            InputManager.MouseHook.InstallHook();
            InputManager.KeyboardHook.InstallHook();
        }

        /// <summary>
        /// Stops hooking up to mouse and keyboard inputs.
        /// </summary>
        public void Uninstall()
        {
            InputManager.MouseHook.UninstallHook();
            InputManager.KeyboardHook.UninstallHook();
        }

        /// <summary>
        /// Registers a trigger to be executed.
        /// </summary>
        /// <param name="trigger"></param>
        public void RegisterTrigger(MouseKeyShortcutTrigger trigger)
        {
            triggers.Add(trigger);
        }

        /// <summary>
        /// Unregisteres a trigger.
        /// </summary>
        /// <param name="trigger"></param>
        public void UnregisterTrigger(MouseKeyShortcutTrigger trigger)
        {
            triggers.Remove(trigger);
        }

        /// <summary>
        /// Removes all of the triggers.
        /// </summary>
        public void UnregisterAllTriggers()
        {
            triggers.Clear();
        }

        /// <summary>
        /// Checks if any triggers should be occuring according to this shortcut.
        /// </summary>
        private void CheckForTriggers(int wheelEvent = -1)
        {
            // Go through all of the triggers, and detect if any trigger should be triggered
            foreach (MouseKeyShortcutTrigger trigger in triggers) {
                if (trigger.Keys == null || IsTriggersDown(trigger.Keys, keysHeld))
                {
                    if (trigger.MouseKeys == null || IsTriggersDown(trigger.MouseKeys, mouseKeysHeld))
                    {
                        if (wheelEvent == trigger.WheelEvent)
                            OnTrigger(trigger.TriggerId);
                    }
                }
            }
        }

        /// <summary>
        /// Checks if all the trigger keys specified are down.
        /// </summary>
        /// <param name="triggerKeys"></param>
        /// <param name="keysHeld"></param>
        /// <returns></returns>
        private bool IsTriggersDown(int[] triggerKeys, List<int> keysHeld)
        {
            foreach (var triggerKey in triggerKeys)
                if (!keysHeld.Contains(triggerKey))
                    return false;

            return true;
        }

        private void MouseHook_MouseEvent(InputManager.MouseHook.MouseEvents mEvent)
        {
            // Key down events are can't be divided by 2
            if ((int)mEvent % 2 > 0)
            {
                mouseKeysHeld.Add((int) mEvent);
                CheckForTriggers();
            }
            else
            {
                var keyUp = mEvent - 1; // Get the associated key up event by reducing one

                // If this key exists in the held array, remove it
                if (mouseKeysHeld.Contains((int) keyUp))
                    mouseKeysHeld.Remove((int) keyUp);
            }
        }

        private void MouseHook_WheelEvent(InputManager.MouseHook.MouseWheelEvents wEvent)
        {
            CheckForTriggers((int) wEvent);
        }

        private void KeyboardHook_KeyUp(int vkCode)
        {
            if (keysHeld.Contains(vkCode))
                keysHeld.Remove(vkCode);
        }

        private void KeyboardHook_KeyDown(int vkCode)
        {
            if (!keysHeld.Contains(vkCode))
                keysHeld.Add(vkCode);

            CheckForTriggers();
        }


        public struct MouseKeyShortcutTrigger
        {
            public int TriggerId;
            public int[] Keys;
            public int[] MouseKeys;
            public int WheelEvent;

            public MouseKeyShortcutTrigger(int triggerId, int[] keys, int[] mouseKeys, int wheelEvent = -1) {
                TriggerId = triggerId;
                Keys = keys;
                MouseKeys = mouseKeys;
                WheelEvent = wheelEvent;
            }
        }
    }
}
