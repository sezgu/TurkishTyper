using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUtils;
using Action = WindowsUtils.KeyboardHook.Action;

namespace TurkishTyper
{
    class CharPair
    {
        public char Lower { get; }
        public char Upper { get; }
        public CharPair(char lower, char upper)
        {
            Lower = lower;
            Upper = upper;
        }
    }

    class HookHandler : IKeyboardHookHandler
    {


        private readonly Dictionary<Key, bool> m_UpperCombination = new Dictionary<Key, bool>();
        private readonly Dictionary<Key, bool> m_LowerCombination = new Dictionary<Key, bool>();
        private readonly IReadOnlyDictionary<Key, CharPair> m_CharMap;
        private RecursionGuard m_Guard = new RecursionGuard(false);

        public HookHandler(Key[] upperCombination, Key[] lowerCombination, IReadOnlyDictionary<Key, CharPair> charMap)
        {
            foreach (var key in upperCombination)
                m_UpperCombination[key] = false;
            foreach (var key in lowerCombination)
                m_LowerCombination[key] = false;
            m_CharMap = charMap;
        }

        private IReadOnlyDictionary<Key, bool> CheckCombination(Action action, Key key)
        {
            var press = action == Action.Press;

            foreach (var c in m_UpperCombination)
            {
                if (c.Key.SameAs(key))
                {
                    m_UpperCombination[c.Key] = press;
                    break;
                }
            }

            foreach (var c in m_LowerCombination)
            {
                if (c.Key.SameAs(key))
                {
                    m_LowerCombination[c.Key] = press;
                    break;
                }
            }

            if (m_LowerCombination.All(p => p.Value))
                return m_LowerCombination;
            if (m_UpperCombination.All(p => p.Value))
                return m_UpperCombination;

            return null;
        }



        public bool Handle(Action action, Key vkCode, uint scanCode, uint flags)
        {
            using (var scope = m_Guard.Scope)
            {
                if (!scope.IsValid)
                    return false;

                var combination = CheckCombination(action, vkCode);

                if (action == Action.Release || combination == null)
                {
                    return false;
                }

                var upper = (combination == m_UpperCombination) ^ Control.IsKeyLocked(Keys.CapsLock);

                foreach (var c in m_CharMap)
                {
                    if (vkCode == c.Key)
                    {
                        foreach (var key in combination)
                            KeyboardInput.Send(key.Key, KeyboardInput.Action.Up);
                        SendKeys.SendWait((upper ? c.Value.Upper : c.Value.Lower).ToString());
                        foreach (var key in combination)
                            KeyboardInput.Send(key.Key, KeyboardInput.Action.Down);
                        return true;
                    }
                }
                return false;
            }
        }
    }

}
