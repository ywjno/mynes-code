using System;
using System.Windows.Forms;
using myNES.Properties;
using myNES.Forms;

namespace myNES
{
    static class Program
    {
        public static Settings Settings { get; private set; }

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Settings = new Settings();
            Settings.Reload();

            Application.Run(new FormMain(args));
            //Application.Run(new FormConsole());
        }
    }
}