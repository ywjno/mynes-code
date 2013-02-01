/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2013
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNes
{
    /// <summary>
    /// A picture box with Ratio Stretch ability
    /// </summary>
    public partial class ImageViewer : Control
    {
        public ImageViewer()
        {
            InitializeComponent();
            ControlStyles flag = ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint;
            this.SetStyle(flag, true);
        }
        private Bitmap imageToView;
        private Bitmap defaultImage;
        private int viewImageWidth = 0;
        private int viewImageHeight = 0;
        private int drawX = 0;
        private int drawY = 0;
        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
            if (imageToView == null)
            {
                //draw default image if not null
                if (defaultImage != null)
                {
                    CalculateStretchedDefaultImageValues();
                    CenterImage();
                    pe.Graphics.DrawImage(defaultImage, new Rectangle(drawX, drawY, viewImageWidth, viewImageHeight));
                }
                else
                { pe.Graphics.Clear(Color.White); }
                return;
            }
            pe.Graphics.DrawImage(imageToView, new Rectangle(drawX, drawY, viewImageWidth, viewImageHeight));
        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (imageToView != null)
            {
                CalculateStretchedImageValues();
                CenterImage();
            }
            Invalidate();
        }
        void CalculateStretchedImageValues()
        {
            if (imageToView == null)
                return;
            float pRatio = (float)this.Width / this.Height;
            float imRatio = (float)imageToView.Width / imageToView.Height;

            if (this.Width >= imageToView.Width && this.Height >= imageToView.Height)
            {
                viewImageWidth = imageToView.Width;
                viewImageHeight = imageToView.Height;
            }
            else if (this.Width > imageToView.Width && this.Height < imageToView.Height)
            {
                viewImageHeight = this.Height;
                viewImageWidth = (int)(this.Height * imRatio);
            }
            else if (this.Width < imageToView.Width && this.Height > imageToView.Height)
            {
                viewImageWidth = this.Width;
                viewImageHeight = (int)(this.Width / imRatio);
            }
            else if (this.Width < imageToView.Width && this.Height < imageToView.Height)
            {
                if (this.Width >= this.Height)
                {
                    //width image
                    if (imageToView.Width >= imageToView.Height && imRatio >= pRatio)
                    {
                        viewImageWidth = this.Width;
                        viewImageHeight = (int)(this.Width / imRatio);
                    }
                    else
                    {
                        viewImageHeight = this.Height;
                        viewImageWidth = (int)(this.Height * imRatio);
                    }
                }
                else
                {
                    if (imageToView.Width < imageToView.Height && imRatio < pRatio)
                    {
                        viewImageHeight = this.Height;
                        viewImageWidth = (int)(this.Height * imRatio);
                    }
                    else
                    {
                        viewImageWidth = this.Width;
                        viewImageHeight = (int)(this.Width / imRatio);
                    }
                }
            }

        }
        void CalculateStretchedDefaultImageValues()
        {
            float pRatio = (float)this.Width / this.Height;
            float imRatio = (float)defaultImage.Width / defaultImage.Height;

            if (this.Width >= defaultImage.Width && this.Height >= defaultImage.Height)
            {
                viewImageWidth = defaultImage.Width;
                viewImageHeight = defaultImage.Height;
            }
            else if (this.Width > defaultImage.Width && this.Height < defaultImage.Height)
            {
                viewImageHeight = this.Height;
                viewImageWidth = (int)(this.Height * imRatio);
            }
            else if (this.Width < defaultImage.Width && this.Height > defaultImage.Height)
            {
                viewImageWidth = this.Width;
                viewImageHeight = (int)(this.Width / imRatio);
            }
            else if (this.Width < defaultImage.Width && this.Height < defaultImage.Height)
            {
                if (this.Width >= this.Height)
                {
                    //width image
                    if (defaultImage.Width >= defaultImage.Height && imRatio >= pRatio)
                    {
                        viewImageWidth = this.Width;
                        viewImageHeight = (int)(this.Width / imRatio);
                    }
                    else
                    {
                        viewImageHeight = this.Height;
                        viewImageWidth = (int)(this.Height * imRatio);
                    }
                }
                else
                {
                    if (defaultImage.Width < defaultImage.Height && imRatio < pRatio)
                    {
                        viewImageHeight = this.Height;
                        viewImageWidth = (int)(this.Height * imRatio);
                    }
                    else
                    {
                        viewImageWidth = this.Width;
                        viewImageHeight = (int)(this.Width / imRatio);
                    }
                }
            }

        }
        void CenterImage()
        {
            int y = (int)((this.Height - viewImageHeight) / 2.0);
            int x = (int)((this.Width - viewImageWidth) / 2.0);
            drawY = y;
            drawX = x;
        }
        public Bitmap ImageToView
        {
            get { return imageToView; }
            set
            {
                imageToView = value;
                CalculateStretchedImageValues();
                CenterImage();
                Invalidate();
            }
        }
        public Bitmap DefaultImage
        {
            get { return defaultImage; }
            set { defaultImage = value; }
        }
    }
}
