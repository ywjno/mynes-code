using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyNes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="Args"></param>
        [STAThread]
        static void Main(string[] Args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            settings.Reload();
            //Application.Run(new Frm_Main());
            Application.Run(new FormConsole());
        }

        static Properties.Settings settings = new Properties.Settings();

        public static Properties.Settings Settings
        { get { return settings; } }
    }
}
