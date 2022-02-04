using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsUtils;

namespace TurkishTyper
{

    static class Program
    {
        public static readonly string StartupLinkPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Startup), "TurkishTyper.lnk");

        public static (Key[], Key[]) LoadShortcuts()
        {
            var upperShortcut = Settings.Default.UpperShortcut.Split(',').Select(s => s.Trim().ToKey()).ToArray();
            var lowerShortcut = Settings.Default.LowerShortcut.Split(',').Select(s => s.Trim().ToKey()).ToArray();
            return (lowerShortcut, upperShortcut) ;
        }

        public static void SaveShortcuts(Key[] lowerShortcut, Key[] upperShortcut)
        {
            if(upperShortcut != null)
                Settings.Default.UpperShortcut = string.Join(",", upperShortcut);
            if(lowerShortcut != null)
                Settings.Default.LowerShortcut = string.Join(",", lowerShortcut);
            Settings.Default.Save();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var (lower, upper) = LoadShortcuts();

            var handler = new HookHandler(lower, upper, new Dictionary<Key, CharPair>()
            {
                    {Key.VK_A , new CharPair('â','Â')},
                    {Key.VK_C , new CharPair('ç','Ç') },
                    {Key.VK_G , new CharPair('ğ','Ğ') },
                    {Key.VK_I , new CharPair('ı','İ') },
                    {Key.VK_O , new CharPair('ö','Ö') },
                    {Key.VK_S, new CharPair('ş', 'Ş')},
                    {Key.VK_U, new CharPair('ü', 'Ü')},
            });
            var hook = new DirectKeyboardHook(handler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormSettings(handler));
        }
    }
}
