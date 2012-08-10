using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using myNES.Core;

namespace myNES.Forms
{
    public partial class FormMain : Form
    {
        private FormConsole consoleForm;
        private FormSpeed speedForm;
        private FormDisassembler disassemblerForm;
        private Thread gameThread;

        public FormMain(string[] args)
        {
            InitializeComponent();
        }
        private void PlaySelectedRom()
        {
            if (treeView.SelectedNode == null)
                return;
            if (treeView.SelectedNode.Tag == null)
                return;
            if (treeView.SelectedNode.Tag.GetType() != typeof(FileInfo))
                return;

            FileInfo inf = ((FileInfo)treeView.SelectedNode.Tag);

            string path = inf.DirectoryName + "\\" + inf.Name;

            if (File.Exists(path))
                OpenRom(path);
        }
        public void OpenRom(string FileName)
        {
            Nes.Shutdown();
            #region Check if archive
            SevenZip.SevenZipExtractor EXTRACTOR;
            if (Path.GetExtension(FileName).ToLower() != ".nes")
            {
                try
                {
                    EXTRACTOR = new SevenZip.SevenZipExtractor(FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                if (EXTRACTOR.ArchiveFileData.Count == 1)
                {
                    if (EXTRACTOR.ArchiveFileData[0].FileName.Substring(EXTRACTOR.ArchiveFileData[0].FileName.Length - 4, 4).ToLower() == ".nes")
                    {
                        EXTRACTOR.ExtractArchive(Path.GetTempPath());
                        FileName = Path.GetTempPath() + EXTRACTOR.ArchiveFileData[0].FileName;
                    }
                }
                else
                {
                    List<string> filenames = new List<string>();
                    foreach (SevenZip.ArchiveFileInfo file in EXTRACTOR.ArchiveFileData)
                    {
                        filenames.Add(file.FileName);
                    }
                    FormFilesList ar = new FormFilesList(filenames.ToArray());
                    if (ar.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        string[] fil = { ar.SelectedRom };
                        EXTRACTOR.ExtractFiles(Path.GetTempPath(), fil);
                        FileName = Path.GetTempPath() + ar.SelectedRom;
                    }
                    else
                    { return; }
                }
            }
            #endregion
            try
            {
                Nes.CreateNew(FileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" + ex.ToString());
                return;
            }
            //the renderer (or the host) will setup input and output
            switch (Program.Settings.CurrentRenderer)
            {
                case SupportedRenderers.SlimDX:
                    RendererFormSlimDX frm = new RendererFormSlimDX();
                    frm.Show();
                    break;
            }
            //turn on
            Nes.TurnOn();
            //enable control buttons
            EnableDisableControlButtons();
            //launch thread
            gameThread = new Thread(new ThreadStart(Nes.Run));
            gameThread.Start();
        }

        private void EnableDisableControlButtons()
        {
            buttonHalt.Enabled = buttonStop.Enabled = Nes.ON;
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

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Nes.Pause = false;
            EnableDisableControlButtons();
        }
        private void buttonHalt_Click(object sender, EventArgs e)
        {
            Nes.Pause = true;
            EnableDisableControlButtons();
        }
        private void buttonStop_Click(object sender, EventArgs e)
        {
            Nes.Shutdown();
            EnableDisableControlButtons();
        }

        private void buttonConsole_Click(object sender, EventArgs e)
        {
            if (consoleForm != null)
            {
                buttonConsole.Checked = false;
                consoleForm.Close();
                consoleForm = null;
            }
            else
            {
                buttonConsole.Checked = true;
                consoleForm = new FormConsole();
                consoleForm.FormClosed += new FormClosedEventHandler(consoleForm_FormClosed);
                consoleForm.Show();
            }
        }

        void consoleForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            consoleForm = null;
            buttonConsole.Checked = false;
        }
        private void buttonPalette_Click(object sender, EventArgs e) { }

        private void buttonCpu_Click(object sender, EventArgs e) { }
        private void buttonPpu_Click(object sender, EventArgs e) { }
        private void buttonApu_Click(object sender, EventArgs e) { }
        private void buttonPad_Click(object sender, EventArgs e) { }

        private void treeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonPlay.Enabled = (e.Node.Tag is FileInfo);
        }

        private void treeView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            PlaySelectedRom();
        }

        private void consoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buttonConsole_Click(sender, e);
        }

        private void buttonConsole_CheckedChanged(object sender, EventArgs e)
        {
            consoleToolStripMenuItem.Checked = buttonConsole.Checked;
        }

        private void toolStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripToolStripMenuItem.Checked = !toolStripToolStripMenuItem.Checked;
        }

        private void menuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStripToolStripMenuItem.Checked = !menuStripToolStripMenuItem.Checked;
        }

        private void toolStripToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            toolStrip.Visible = toolStripToolStripMenuItem.Checked;
        }
        private void menuStripToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            menuStrip1.Visible = menuStripToolStripMenuItem.Checked;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nes.Shutdown();
            Close();
        }

        private void ShowHelp(object sender, EventArgs e)
        {
            Help.ShowHelp(this, ".\\Help.chm", HelpNavigator.TableOfContents);
        }

        private void openRomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "INES (*.nes)|*.nes;*.NES";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                OpenRom(op.FileName);
            }
        }

        private void aboutMyNesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout frm = new FormAbout(Application.ProductVersion);
            frm.ShowDialog(this);
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Nes.Shutdown();
        }

        private void emulationSpeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (speedForm != null)
            {
                emulationSpeedToolStripMenuItem.Checked = false;
                speedForm.Close();
                speedForm = null;
            }
            else
            {
                emulationSpeedToolStripMenuItem.Checked = true;
                speedForm = new FormSpeed();
                speedForm.FormClosed += new FormClosedEventHandler(speedForm_FormClosed);
                speedForm.Show();
            }
        }

        void speedForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            speedForm = null;
            emulationSpeedToolStripMenuItem.Checked = false;
        }

        private void softResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Nes.SoftReset();
        }
    }
}