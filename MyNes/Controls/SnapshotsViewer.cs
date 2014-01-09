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
    public partial class SnapshotsViewer : UserControl
    {
        public SnapshotsViewer()
        {
            InitializeComponent();
        }

        public event EventHandler RequestAddImage;
        public event EventHandler RequestRemoveImage;
        public event EventHandler RequestEditList;
        public event EventHandler RequestPreviuosImage;
        public event EventHandler RequestNextImage;

        public void UpdateStatus(string status)
        { StripLabel.Text = status; }
        public void ViewImage(Bitmap image)
        {
            imageViewer1.ImageToView = image;
        }
        public void ClearImage()
        {
            imageViewer1.ImageToView = null;
        }
        public void ClearAll()
        {
            imageViewer1.ImageToView = null;
            StripLabel.Text = "0/0";
        }

        private void AddImage(object sender, EventArgs e)
        {
            if (RequestAddImage != null)
                RequestAddImage(this, new EventArgs());
        }

        private void DeleteImage(object sender, EventArgs e)
        {
            if (RequestRemoveImage != null)
                RequestRemoveImage(this, new EventArgs());
        }

        private void EditList(object sender, EventArgs e)
        {
            if (RequestEditList != null)
                RequestEditList(this, new EventArgs());
        }

        private void PreviousImage(object sender, EventArgs e)
        {
            if (RequestPreviuosImage != null)
                RequestPreviuosImage(this, new EventArgs());
        }

        private void NextImage(object sender, EventArgs e)
        {
            if (RequestNextImage != null)
                RequestNextImage(this, new EventArgs());
        }

        private void imageViewer1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            OnMouseDoubleClick(e);
        }
    }
}
