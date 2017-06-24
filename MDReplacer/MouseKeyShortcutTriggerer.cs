using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WinputManager;

namespace MDReplacer
{
    public class MouseKeyShortcutTriggerer
    {
        public delegate void OnTriggerHandler(int triggerId);
        public event OnTriggerHandler OnTrigger;

        private List<MouseKeyShortcutTrigger> triggers = new List<MouseKeyShortcutTrigger>();
        private List<int> keysHeld = new List<int>();
        private List<int> mouseKeysHeld = new List<int>();
        KeyboardHook keyboardHook = new KeyboardHook();
        MouseHook mouseHook = new MouseHook();

        public MouseKeyShortcutTriggerer()
        {
            /* Start listening to all of the events */
            keyboardHook.OnKeyboardEvent += KeyboardHook_OnKeyboardEvent;
            mouseHook.OnMouseEvent += MouseHook_OnMouseEvent;
            mouseHook.OnMouseWheelEvent += MouseHook_OnMouseWheelEvent;
        }

        /// <summary>
        /// Starts hooking up to listen to mouse and keyboard inputs globally.
        /// </summary>
        public void Install()
        {
            keyboardHook.Install();
            mouseHook.Install();
        }

        /// <summary>
        /// Stops hooking up to mouse and keyboard inputs.
        /// </summary>
        public void Uninstall()
        {
            keyboardHook.Uninstall();
            mouseHook.Uninstall();
        }

        #region Hook code
        private bool MouseHook_OnMouseWheelEvent(int wheelValue)
        {
            return CheckForTriggers(wheelValue);
        }

        private bool MouseHook_OnMouseEvent(int mouseEvent)
        {
            // Key down events can't be divided by 2
            if (mouseEvent % 2 > 0)
            {
                mouseKeysHeld.Add(mouseEvent);
                return CheckForTriggers();
            }
            else
            {
                var keyUp = mouseEvent - 1; // Get the associated key up event by reducing one

                // If this key exists in the held array, remove it
                if (mouseKeysHeld.Contains((int)keyUp))
                    mouseKeysHeld.Remove((int)keyUp);
            }

            return false;
        }

        private bool KeyboardHook_OnKeyboardEvent(uint key, BaseHook.KeyState keyState)
        {
            if (keyState == BaseHook.KeyState.Keydown)
            {
                // If this key does not exist, add it to the array of held keys
                if (!keysHeld.Contains((int) key))
                    keysHeld.Add((int) key);

                return CheckForTriggers();

            } // If this key was released
            else if (keysHeld.Contains((int) key))
                    keysHeld.Remove((int) key);

            return false;

        }
        #endregion
        #region Trigger Code
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
        /// Checks if any triggers should be occuring according to this shortcut, returns true if a trigger was activated.
        /// </summary>
        private bool CheckForTriggers(int wheelEvent = -1)
        {
            // Go through all of the triggers, and detect if any trigger should be triggered
            foreach (MouseKeyShortcutTrigger trigger in triggers) {
                if (trigger.Keys == null || IsTriggersDown(trigger.Keys, keysHeld))
                {
                    if (trigger.MouseKeys == null || IsTriggersDown(trigger.MouseKeys, mouseKeysHeld))
                    {
                        if (wheelEvent == trigger.WheelEvent)
                        {
                            OnTrigger(trigger.TriggerId);
                            return true;
                        }
                    }
                }
            }

            return false;
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

        public struct MouseKeyShortcutTrigger
        {
            public int TriggerId;
            public int[] Keys;
            public int[] MouseKeys;
            public int WheelEvent;

            public MouseKeyShortcutTrigger(int triggerId, int[] keys, int[] mouseKeys, int wheelEvent = -1)
            {
                TriggerId = triggerId;
                Keys = keys;
                MouseKeys = mouseKeys;
                WheelEvent = wheelEvent;
            }
        }
        #endregion
    }
}
