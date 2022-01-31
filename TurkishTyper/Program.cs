using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUtils;

namespace TurkishTyper
{

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var hook = new DirectKeyboardHook(
                new HookHandler(new Key[] { Key.VK_LMENU, Key.VK_LSHIFT }, new Key[] { Key.VK_LMENU, Key.VK_LCONTROL }, new Dictionary<Key, CharPair>()
            {
                    {Key.VK_A , new CharPair('â','Â')},
                    {Key.VK_C , new CharPair('ç','Ç') },
                    {Key.VK_G , new CharPair('ğ','Ğ') },
                    {Key.VK_I , new CharPair('ı','İ') },
                    {Key.VK_O , new CharPair('ö','Ö') },
                    {Key.VK_S, new CharPair('ş', 'Ş')},
                    {Key.VK_U, new CharPair('ü', 'Ü')},
            }));

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSettings());
        }
    }
}
