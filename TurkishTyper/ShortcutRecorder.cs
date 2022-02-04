using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsUtils;

namespace TurkishTyper
{
    class ShortcutRecorder : IDisposable
    {
        private KeyboardHook m_KeyboardHook = new KeyboardHook() { Blocked = true };
        private List<Key> m_PressedKeys = new List<Key>();
        private List<Key> m_ReleasedKeys = new List<Key>();

        public event Action RecordChanged;

        public IReadOnlyList<Key> RecordedKeys => m_PressedKeys;

        public ShortcutRecorder()
        {
            m_KeyboardHook.OnKeyboardAction += KeyboardHook_OnKeyboardAction;
        }

        public void Dispose()
        {
            m_KeyboardHook.Dispose();
            m_PressedKeys = null;
        }

        private void KeyboardHook_OnKeyboardAction(KeyboardHook.Action action, Key vkCode, uint scanCode, uint flags)
        {
            if (action == KeyboardHook.Action.Press && !IsAlreadyPressed(vkCode))
                AddPress(vkCode);
            else if (action == KeyboardHook.Action.Release)
                AddRelease(vkCode);
            RecordChanged?.Invoke();
        }


        private bool IsAlreadyPressed(Key key)
        {
            return m_PressedKeys.Count(a => a == key) > m_ReleasedKeys.Count(a => a == key);
        }


        private void AddPress(Key key)
        {
            if (!key.IsShortcutKey()) //Not a shortcut key
            {
                Reset();
                return;
            }
            if (m_ReleasedKeys.Any(a => a.IsShortcutKey())) //Shortcut is released
                Reset();
            m_PressedKeys.Add(key);
        }

        private void AddRelease(Key key)
        {
            if (!m_PressedKeys.Contains(key))    //Unknown key
            {
                Reset();
                return;
            }
            m_ReleasedKeys.Add(key);
        }

        private void Reset()
        {
            m_PressedKeys.Clear();
            m_ReleasedKeys.Clear();
        }
    }
}
