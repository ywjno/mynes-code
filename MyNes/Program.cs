using System;
using System.Windows.Forms;
using MyNes.Properties;

namespace MyNes
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

            // Application.Run(new FormMain());
            Application.Run(new FormConsole());
        }
    }
}