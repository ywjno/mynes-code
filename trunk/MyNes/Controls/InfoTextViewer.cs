using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNes
{
    public partial class InfoTextViewer : UserControl
    {
        public InfoTextViewer()
        {
            InitializeComponent();
        }

        public event EventHandler RequestAddFile;
        public event EventHandler RequestRemoveFile;
        public event EventHandler RequestEditList;
        public event EventHandler RequestPreviuosFile;
        public event EventHandler RequestNextFile;
        public event EventHandler RequestEditFile;

        public void ClearAll()
        {
            richTextBox1.Text = "";
            StripLabel.Text = "0/0";
        }
        public void ClearText()
        {
            richTextBox1.Text = "";
        }
        public void ViewText(string text)
        {
            this.richTextBox1.Text = text;
        }
        public void UpdateStatus(string status)
        { StripLabel.Text = status; }
        private void AddFile(object sender, EventArgs e)
        {
            if (RequestAddFile != null)
                RequestAddFile(this, new EventArgs());
        }
        private void RemoveFile(object sender, EventArgs e)
        {
            if (RequestRemoveFile != null)
                RequestRemoveFile(this, new EventArgs());
        }
        private void EditList(object sender, EventArgs e)
        {
            if (RequestEditList != null)
                RequestEditList(this, new EventArgs());
        }
        private void PreviousFile(object sender, EventArgs e)
        {
            if (RequestPreviuosFile != null)
                RequestPreviuosFile(this, new EventArgs());
        }
        private void NextFile(object sender, EventArgs e)
        {
            if (RequestNextFile != null)
                RequestNextFile(this, new EventArgs());
        }
        private void EditFile(object sender, EventArgs e)
        {
            if (RequestEditFile != null)
                RequestEditFile(this, new EventArgs());
        }
    }
}
