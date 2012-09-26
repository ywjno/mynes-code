using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX;
using SlimDX.Direct3D9;
namespace MyNes
{
    public partial class FormVideoSettings : Form
    {
        public FormVideoSettings()
        {
            Direct3D d3d = new Direct3D();
            InitializeComponent();
            //renderers
            string[] rndrs = Enum.GetNames(typeof(SupportedRenderers));
            foreach (string name in rndrs)
                comboBox_currentRenderer.Items.Add(name);
            comboBox_currentRenderer.SelectedItem = Program.Settings.CurrentRenderer.ToString();
            //adpaters
            foreach (AdapterInformation adp in d3d.Adapters)
                comboBox_adapter.Items.Add(adp.Details.Description);

            comboBox_adapter.SelectedIndex = Program.Settings.VideoAdapterIndex;
            //res
            for (int i = 0; i < d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8).Count; i++)
            {
                comboBox_fullscreenRes.Items.Add(d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].Width + " x " +
                    d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].Height + " " +
                    d3d.Adapters[0].GetDisplayModes(SlimDX.Direct3D9.Format.X8R8G8B8)[i].RefreshRate + " Hz");
            }
            comboBox_fullscreenRes.SelectedIndex = Program.Settings.VideoResIndex;
            checkBox_hideLines.Checked = Program.Settings.VideoHideLines;
            checkBox_imMode.Checked = Program.Settings.VideoImmediateMode;
            checkBox_fullscreen.Checked = Program.Settings.VideoFullscreen;
            //stretch
            numericUpDown1.Value = Program.Settings.VideoStretchMultiply;
            //snapshot image format
            switch (Program.Settings.SnapshotFormat.ToLower())
            {
                case ".jpg": radioButton_jpg.Checked = true; break;
                case ".bmp": radioButton_bmp.Checked = true; break;
                case ".png": radioButton_png.Checked = true; break;
                case ".gif": radioButton_gif.Checked = true; break;
                case ".tiff": radioButton_tiff.Checked = true; break;
                case ".emf": radioButton_emf.Checked = true; break;
                case ".wmf": radioButton_wmf.Checked = true; break;
                case ".exif": radioButton_exif.Checked = true; break;
            }
        }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.CurrentRenderer = (SupportedRenderers)Enum.Parse(typeof(SupportedRenderers),
                comboBox_currentRenderer.SelectedItem.ToString());
            Program.Settings.VideoAdapterIndex = comboBox_adapter.SelectedIndex;
            Program.Settings.VideoResIndex = comboBox_fullscreenRes.SelectedIndex;
            Program.Settings.VideoHideLines = checkBox_hideLines.Checked;
            Program.Settings.VideoImmediateMode = checkBox_imMode.Checked;
            Program.Settings.VideoFullscreen = checkBox_fullscreen.Checked;
            Program.Settings.VideoStretchMultiply = (int)numericUpDown1.Value;
            //snapshot image format
            if (radioButton_jpg.Checked)
                Program.Settings.SnapshotFormat = ".jpg";
            else if (radioButton_bmp.Checked)
                Program.Settings.SnapshotFormat = ".bmp";
            else if (radioButton_png.Checked)
                Program.Settings.SnapshotFormat = ".png";
            else if (radioButton_gif.Checked)
                Program.Settings.SnapshotFormat = ".gif";
            else if (radioButton_tiff.Checked)
                Program.Settings.SnapshotFormat = ".tiff";
            else if (radioButton_emf.Checked)
                Program.Settings.SnapshotFormat = ".emf";
            else if (radioButton_wmf.Checked)
                Program.Settings.SnapshotFormat = ".wmf";
            else if (radioButton_exif.Checked)
                Program.Settings.SnapshotFormat = ".exif";
            Program.Settings.Save();
            Close();
        }
        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        //defaults
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox_adapter.SelectedIndex = comboBox_currentRenderer.SelectedIndex = comboBox_fullscreenRes.SelectedIndex = 0;
            numericUpDown1.Value = 2;
            checkBox_hideLines.Checked = true;
            checkBox_imMode.Checked = true;
            checkBox_fullscreen.Checked = false;
        }
    }
}
