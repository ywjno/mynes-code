using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyNes.Core;
using MyNes.Core.PPU;
using System.IO;
namespace MyNes
{
    public partial class FormPaletteSettings : Form
    {
        public FormPaletteSettings()
        {
            InitializeComponent();
            //load
            NTSCPaletteGenerator.brightness = Program.Settings.PaletteSettings.NTSC_brightness;
            NTSCPaletteGenerator.contrast = Program.Settings.PaletteSettings.NTSC_contrast;
            NTSCPaletteGenerator.gamma = Program.Settings.PaletteSettings.NTSC_gamma;
            NTSCPaletteGenerator.hue_tweak = Program.Settings.PaletteSettings.NTSC_hue_tweak;
            NTSCPaletteGenerator.saturation = Program.Settings.PaletteSettings.NTSC_saturation;

            PALBPaletteGenerator.brightness = Program.Settings.PaletteSettings.PALB_brightness;
            PALBPaletteGenerator.contrast = Program.Settings.PaletteSettings.PALB_contrast;
            PALBPaletteGenerator.gamma = Program.Settings.PaletteSettings.PALB_gamma;
            PALBPaletteGenerator.hue_tweak = Program.Settings.PaletteSettings.PALB_hue_tweak;
            PALBPaletteGenerator.saturation = Program.Settings.PaletteSettings.PALB_saturation;

            hScrollBar_brightness.Value = (int)(Program.Settings.PaletteSettings.NTSC_brightness * 1000);
            hScrollBar_contrast.Value = (int)(Program.Settings.PaletteSettings.NTSC_contrast * 1000);
            hScrollBar_gamma.Value = (int)(Program.Settings.PaletteSettings.NTSC_gamma * 1000);
            hScrollBar_hue_tweak.Value = (int)(Program.Settings.PaletteSettings.NTSC_hue_tweak * 1000);
            hScrollBar_saturation.Value = (int)(Program.Settings.PaletteSettings.NTSC_saturation * 1000);

            label_bright.Text = Program.Settings.PaletteSettings.NTSC_brightness.ToString("F3");
            label_const.Text = Program.Settings.PaletteSettings.NTSC_contrast.ToString("F3");
            label_gamma.Text = Program.Settings.PaletteSettings.NTSC_gamma.ToString("F3");
            label_hue.Text = Program.Settings.PaletteSettings.NTSC_hue_tweak.ToString("F3");
            label_satur.Text = Program.Settings.PaletteSettings.NTSC_saturation.ToString("F3");
        }
        unsafe void ShowPalette(int[] PaletteFormat)
        {
            Graphics GR = panel1.CreateGraphics();
            GR.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            int y = 0;
            int x = 0;
            int w = 16;
            int H = 10;
            for (int j = 0; j < PaletteFormat.Length; j++)
            {
                y = (j / 16) * H;
                x = (j % w) * w;
                Bitmap bmp = new Bitmap(w, H);
                BitmapData bmpData = bmp.LockBits(new Rectangle(0, 0, w, H),
                    ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
                int* numPtr = (int*)bmpData.Scan0;
                for (int i = 0; i < w * H; i++)
                {
                    numPtr[i] = PaletteFormat[j];
                }
                bmp.UnlockBits(bmpData);
                GR.DrawImage(bmp, x, y, w, H);
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (radioButton_ntsc.Checked)
                ShowPalette(NTSCPaletteGenerator.GeneratePalette());
            else
                ShowPalette(PALBPaletteGenerator.GeneratePalette());
        }

        private void hScrollBar_saturation_Scroll(object sender, ScrollEventArgs e)
        {
            float v = hScrollBar_saturation.Value;
            if (radioButton_ntsc.Checked)
            {
                NTSCPaletteGenerator.saturation = (v / 1000);
                label_satur.Text = NTSCPaletteGenerator.saturation.ToString("F3");
                int[] palette = NTSCPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
            else
            {
                PALBPaletteGenerator.saturation = (v / 1000);
                label_satur.Text = PALBPaletteGenerator.saturation.ToString("F3");
                int[] palette = PALBPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);

            }
        }
        private void hScrollBar_hue_tweak_Scroll(object sender, ScrollEventArgs e)
        {
            float v = hScrollBar_hue_tweak.Value;
            if (radioButton_ntsc.Checked)
            {
                NTSCPaletteGenerator.hue_tweak = (v / 1000);
                label_hue.Text = NTSCPaletteGenerator.hue_tweak.ToString("F3");
                int[] palette = NTSCPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
            else
            {
                PALBPaletteGenerator.hue_tweak = (v / 1000);
                label_hue.Text = PALBPaletteGenerator.hue_tweak.ToString("F3");
                int[] palette = PALBPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);

            }
        }
        private void hScrollBar_contrast_Scroll(object sender, ScrollEventArgs e)
        {
            float v = hScrollBar_contrast.Value;
            if (radioButton_ntsc.Checked)
            {
                NTSCPaletteGenerator.contrast = (v / 1000);
                label_const.Text = NTSCPaletteGenerator.contrast.ToString("F3");
                int[] palette = NTSCPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
            else
            {
                PALBPaletteGenerator.contrast = (v / 1000);
                label_const.Text = PALBPaletteGenerator.contrast.ToString("F3");
                int[] palette = PALBPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
        }
        private void hScrollBar_brightness_Scroll(object sender, ScrollEventArgs e)
        {
            float v = hScrollBar_brightness.Value;
            if (radioButton_ntsc.Checked)
            {
                NTSCPaletteGenerator.brightness = (v / 1000);
                label_bright.Text = NTSCPaletteGenerator.brightness.ToString("F3");
                int[] palette = NTSCPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
            else
            {
                PALBPaletteGenerator.brightness = (v / 1000);
                label_bright.Text = PALBPaletteGenerator.brightness.ToString("F3");
                int[] palette = PALBPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
        }
        private void hScrollBar_gamma_Scroll(object sender, ScrollEventArgs e)
        {
            float v = hScrollBar_gamma.Value;
            if (radioButton_ntsc.Checked)
            {
                NTSCPaletteGenerator.gamma = (v / 1000);
                label_gamma.Text = NTSCPaletteGenerator.gamma.ToString("F3");
                int[] palette = NTSCPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
            else
            {
                PALBPaletteGenerator.gamma = (v / 1000);
                label_gamma.Text = PALBPaletteGenerator.gamma.ToString("F3");
                int[] palette = PALBPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
        }
        //load
        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "My Nes Palette Present (*.mnpp)|*.mnpp";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(op.FileName);
                if (radioButton_ntsc.Checked)
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] pars = lines[i].Split(new char[] { '=' });
                        switch (pars[0])
                        {
                            case "Brightness":
                                NTSCPaletteGenerator.brightness = float.Parse(pars[1]);
                                hScrollBar_brightness.Value = (int)(NTSCPaletteGenerator.brightness * 1000);
                                break;
                            case "Contrast":
                                NTSCPaletteGenerator.contrast = float.Parse(pars[1]);
                                hScrollBar_contrast.Value = (int)(NTSCPaletteGenerator.contrast * 1000);
                                break;
                            case "Gamma":
                                NTSCPaletteGenerator.gamma = float.Parse(pars[1]);
                                hScrollBar_gamma.Value = (int)(NTSCPaletteGenerator.gamma * 1000);
                                break;
                            case "Hue":
                                NTSCPaletteGenerator.hue_tweak = float.Parse(pars[1]);
                                hScrollBar_hue_tweak.Value = (int)(NTSCPaletteGenerator.hue_tweak * 1000);
                                break;
                            case "Saturation":
                                NTSCPaletteGenerator.saturation = float.Parse(pars[1]);
                                hScrollBar_saturation.Value = (int)(NTSCPaletteGenerator.saturation * 1000);
                                break;
                        }
                    }
                    label_bright.Text = NTSCPaletteGenerator.brightness.ToString("F3");
                    label_const.Text = NTSCPaletteGenerator.contrast.ToString("F3");
                    label_gamma.Text = NTSCPaletteGenerator.gamma.ToString("F3");
                    label_hue.Text = NTSCPaletteGenerator.hue_tweak.ToString("F3");
                    label_satur.Text = NTSCPaletteGenerator.saturation.ToString("F3");

                    int[] palette = NTSCPaletteGenerator.GeneratePalette();
                    ShowPalette(palette);
                    if (Nes.ON)
                        Nes.Ppu.SetupPalette(palette);
                }
                else
                {
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string[] pars = lines[i].Split(new char[] { '=' });
                        switch (pars[0])
                        {
                            case "Brightness":
                                PALBPaletteGenerator.brightness = float.Parse(pars[1]);
                                hScrollBar_brightness.Value = (int)(PALBPaletteGenerator.brightness * 1000);
                                break;
                            case "Contrast":
                                PALBPaletteGenerator.contrast = float.Parse(pars[1]);
                                hScrollBar_contrast.Value = (int)(PALBPaletteGenerator.contrast * 1000);
                                break;
                            case "Gamma":
                                PALBPaletteGenerator.gamma = float.Parse(pars[1]);
                                hScrollBar_gamma.Value = (int)(PALBPaletteGenerator.gamma * 1000);
                                break;
                            case "Hue":
                                PALBPaletteGenerator.hue_tweak = float.Parse(pars[1]);
                                hScrollBar_hue_tweak.Value = (int)(PALBPaletteGenerator.hue_tweak * 1000);
                                break;
                            case "Saturation":
                                PALBPaletteGenerator.saturation = float.Parse(pars[1]);
                                hScrollBar_saturation.Value = (int)(PALBPaletteGenerator.saturation * 1000);
                                break;
                        }
                    }
                    label_bright.Text = PALBPaletteGenerator.brightness.ToString("F3");
                    label_const.Text = PALBPaletteGenerator.contrast.ToString("F3");
                    label_gamma.Text = PALBPaletteGenerator.gamma.ToString("F3");
                    label_hue.Text = PALBPaletteGenerator.hue_tweak.ToString("F3");
                    label_satur.Text = PALBPaletteGenerator.saturation.ToString("F3");
                    int[] palette = PALBPaletteGenerator.GeneratePalette();
                    ShowPalette(palette);
                    if (Nes.ON)
                        Nes.Ppu.SetupPalette(palette);
                }
            }
        }
        //save
        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "My Nes Palette Present (*.mnpp)|*.mnpp";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                List<string> lines = new List<string>();
                lines.Add("Brightness=" + NTSCPaletteGenerator.brightness);
                lines.Add("Contrast=" + NTSCPaletteGenerator.contrast);
                lines.Add("Gamma=" + NTSCPaletteGenerator.gamma);
                lines.Add("Hue=" + NTSCPaletteGenerator.hue_tweak);
                lines.Add("Saturation=" + NTSCPaletteGenerator.saturation);
                File.WriteAllLines(sav.FileName, lines.ToArray());
            }
        }
        //flat
        private void button6_Click(object sender, EventArgs e)
        {
            if (radioButton_ntsc.Checked)
            {
                NTSCPaletteGenerator.saturation = 1.0f;
                hScrollBar_saturation.Value = 1000;
                NTSCPaletteGenerator.hue_tweak = 0.0f;
                hScrollBar_hue_tweak.Value = 0;
                NTSCPaletteGenerator.contrast = 1.0f;
                hScrollBar_contrast.Value = 1000;
                NTSCPaletteGenerator.brightness = 1.0f;
                hScrollBar_brightness.Value = 1000;
                NTSCPaletteGenerator.gamma = 1.8f;
                hScrollBar_gamma.Value = 1800;

                label_satur.Text = NTSCPaletteGenerator.saturation.ToString("F3");
                label_hue.Text = NTSCPaletteGenerator.hue_tweak.ToString("F3");
                label_const.Text = NTSCPaletteGenerator.contrast.ToString("F3");
                label_bright.Text = NTSCPaletteGenerator.brightness.ToString("F3");
                label_gamma.Text = NTSCPaletteGenerator.gamma.ToString("F3");

                int[] palette = NTSCPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
            else
            {
                PALBPaletteGenerator.saturation = 1.0f;
                hScrollBar_saturation.Value = 1000;
                PALBPaletteGenerator.hue_tweak = 0.0f;
                hScrollBar_hue_tweak.Value = 0;
                PALBPaletteGenerator.contrast = 1.0f;
                hScrollBar_contrast.Value = 1000;
                PALBPaletteGenerator.brightness = 1.0f;
                hScrollBar_brightness.Value = 1000;
                PALBPaletteGenerator.gamma = 1.8f;
                hScrollBar_gamma.Value = 1800;

                label_satur.Text = PALBPaletteGenerator.saturation.ToString("F3");
                label_hue.Text = PALBPaletteGenerator.hue_tweak.ToString("F3");
                label_const.Text = PALBPaletteGenerator.contrast.ToString("F3");
                label_bright.Text = PALBPaletteGenerator.brightness.ToString("F3");
                label_gamma.Text = PALBPaletteGenerator.gamma.ToString("F3");

                int[] palette = PALBPaletteGenerator.GeneratePalette();
                ShowPalette(palette);
                if (Nes.ON)
                    Nes.Ppu.SetupPalette(palette);
            }
        }
        //save as .pal
        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "Palette file '64 indexes' (*.pal)|*.pal|Palette file '512 indexes' (*.pal)|*.pal";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                //get pallete
                List<byte> palette = new List<byte>();
                int[] NesPalette = radioButton_ntsc.Checked ? NTSCPaletteGenerator.GeneratePalette() :
                    PALBPaletteGenerator.GeneratePalette();

                for (int i = 0; i < ((sav.FilterIndex == 1) ? 64 : 512); i++)
                {
                    int color = NesPalette[i];
                    palette.Add((byte)((color >> 16) & 0xFF));//Red
                    palette.Add((byte)((color >> 8) & 0xFF));//Green
                    palette.Add((byte)((color >> 0) & 0xFF));//Blue
                }

                Stream str = new FileStream(sav.FileName, FileMode.Create, FileAccess.Write);
                str.Write(palette.ToArray(), 0, palette.Count);
                str.Close();
            }
        }
        //cancel
        private void button2_Click(object sender, EventArgs e)
        {
            //reset and close
            NTSCPaletteGenerator.brightness = Program.Settings.PaletteSettings.NTSC_brightness;
            NTSCPaletteGenerator.contrast = Program.Settings.PaletteSettings.NTSC_contrast;
            NTSCPaletteGenerator.gamma = Program.Settings.PaletteSettings.NTSC_gamma;
            NTSCPaletteGenerator.hue_tweak = Program.Settings.PaletteSettings.NTSC_hue_tweak;
            NTSCPaletteGenerator.saturation = Program.Settings.PaletteSettings.NTSC_saturation;

            PALBPaletteGenerator.brightness = Program.Settings.PaletteSettings.PALB_brightness;
            PALBPaletteGenerator.contrast = Program.Settings.PaletteSettings.PALB_contrast;
            PALBPaletteGenerator.gamma = Program.Settings.PaletteSettings.PALB_gamma;
            PALBPaletteGenerator.hue_tweak = Program.Settings.PaletteSettings.PALB_hue_tweak;
            PALBPaletteGenerator.saturation = Program.Settings.PaletteSettings.PALB_saturation;

            int[] palette = radioButton_ntsc.Checked ? NTSCPaletteGenerator.GeneratePalette() : PALBPaletteGenerator.GeneratePalette();
            ShowPalette(palette);
            if (Nes.ON)
                Nes.Ppu.SetupPalette(palette);

            Close();
        }
        //ok
        private void button1_Click(object sender, EventArgs e)
        {
            Program.Settings.PaletteSettings.NTSC_brightness = NTSCPaletteGenerator.brightness;
            Program.Settings.PaletteSettings.NTSC_contrast = NTSCPaletteGenerator.contrast;
            Program.Settings.PaletteSettings.NTSC_gamma = NTSCPaletteGenerator.gamma;
            Program.Settings.PaletteSettings.NTSC_hue_tweak = NTSCPaletteGenerator.hue_tweak;
            Program.Settings.PaletteSettings.NTSC_saturation = NTSCPaletteGenerator.saturation;

            Program.Settings.PaletteSettings.PALB_brightness = PALBPaletteGenerator.brightness;
            Program.Settings.PaletteSettings.PALB_contrast = PALBPaletteGenerator.contrast;
            Program.Settings.PaletteSettings.PALB_gamma = PALBPaletteGenerator.gamma;
            Program.Settings.PaletteSettings.PALB_hue_tweak = PALBPaletteGenerator.hue_tweak;
            Program.Settings.PaletteSettings.PALB_saturation = PALBPaletteGenerator.saturation;

            int[] palette = radioButton_ntsc.Checked ? NTSCPaletteGenerator.GeneratePalette() : PALBPaletteGenerator.GeneratePalette();
            ShowPalette(palette);
            if (Nes.ON)
                Nes.Ppu.SetupPalette(palette);

            Program.Settings.Save();
            Close();
        }
    }
}
