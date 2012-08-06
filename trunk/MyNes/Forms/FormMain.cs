using System;
using System.IO;
using System.Windows.Forms;
using MyNes.Forms;

namespace MyNes
{
    public partial class FormMain : Form
    {
        private FormConsole consoleForm;
        private FormDisassembler disassemblerForm;
        private FormGame gameForm;

        public FormMain()
        {
            InitializeComponent();
        }

        private TreeNode SearchFolders(DirectoryInfo path)
        {
            var node = new TreeNode(path.Name, 0, 0);

            foreach (var directory in path.GetDirectories())
            {
                var child = SearchFolders(directory);

                if (child == null)
                    continue;

                child.Tag = directory;

                node.Nodes.Add(child);
            }

            foreach (var file in path.GetFiles("*.nes"))
            {
                var child = new TreeNode(file.Name, 1, 1);
                child.Tag = file;

                node.Nodes.Add(child);
            }

            if (node.Nodes.Count == 0)
                return null;

            return node;
        }

        private void buttonCreateFolder_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                var node = SearchFolders(new DirectoryInfo(folderBrowserDialog.SelectedPath));

                if (node == null)
                {
                    MessageBox.Show("No ROMs found in '" + folderBrowserDialog.SelectedPath + "'");
                    return;
                }

                treeView.Nodes.Add(node);
            }
        }
        private void buttonModifyFolder_Click(object sender, EventArgs e) { }
        private void buttonDeleteFolder_Click(object sender, EventArgs e) { }

        private void buttonPlay_Click(object sender, EventArgs e) { }
        private void buttonHalt_Click(object sender, EventArgs e) { }
        private void buttonStop_Click(object sender, EventArgs e) { }

        private void buttonConsole_Click(object sender, EventArgs e) { }
        private void buttonPalette_Click(object sender, EventArgs e) { }

        private void buttonCpu_Click(object sender, EventArgs e) { }
        private void buttonPpu_Click(object sender, EventArgs e) { }
        private void buttonApu_Click(object sender, EventArgs e) { }
        private void buttonPad_Click(object sender, EventArgs e) { }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Tag is FileInfo)
            {
                buttonPlay.Enabled = true;
            }

            if (e.Node.Tag is DirectoryInfo)
            {
                buttonPlay.Enabled = false;
            }
        }
    }
}