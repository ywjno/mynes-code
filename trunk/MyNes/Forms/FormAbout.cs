using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
namespace MyNes
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();
            // Version
            Version ver = Assembly.GetExecutingAssembly().GetName().Version;
            label_version.Text = Program.ResourceManager.GetString("Version")
                + ": " + ver.Major + "." + ver.Minor + " [" + Program.ResourceManager.GetString("Build") + " " + ver.Build +
                "] [" + Program.ResourceManager.GetString("Revision") + " " + ver.Revision + "]";

            Assembly asm = Assembly.LoadFile
                (System.IO.Path.Combine(Application.StartupPath,
                    "Core.dll"));

            ver = asm.GetName().Version;

            label_coreVersion.Text = Program.ResourceManager.GetString("CoreVersion") + ": " + ver.Major + "." + ver.Minor +
                " [" + Program.ResourceManager.GetString("Build") + " " + ver.Build + "] [" +
                Program.ResourceManager.GetString("Revision") + " " + ver.Revision + "]";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
