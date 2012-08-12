using System;
using System.IO;
using System.Windows.Forms;

namespace myNES
{
    public partial class FormFilesList : Form
    {
        public string SelectedRom { get { return listBox.SelectedItem.ToString(); } }

        public FormFilesList(string[] files)
        {
            InitializeComponent();

            for (int i = 0; i < files.Length; i++)
            {
                if (Path.GetExtension(files[i]).ToLower() == ".nes")
                {
                    listBox.Items.Add(files[i]);
                }
            }

            listBox.SelectedIndex = (listBox.Items.Count > 0) ? 0 : -1;
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedIndex < 0)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        private void listBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listBox.SelectedIndex < 0)
                return;

            DialogResult = DialogResult.OK;
            Close();
        }
        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAccept.Enabled = listBox.SelectedIndex >= 0;
        }
    }
}