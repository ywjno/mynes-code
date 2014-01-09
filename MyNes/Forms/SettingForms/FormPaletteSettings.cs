/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MyNes.Core;
using MyNes.Core.PPU;
namespace MyNes
{
    public partial class FormPaletteSettings : Form
    {
        public FormPaletteSettings()
        {
            InitializeComponent();
            LoadSettings();
            ApplyToPalette();
        }
        private void LoadSettings() 
        {
            trackBar_ntsc_hue.Value = ToHue(Program.Settings.PaletteNTSCHue);
            trackBar_ntsc_contrast.Value = ToContrast(Program.Settings.PaletteNTSCContrast);
            trackBar_ntsc_gamma.Value = ToGamma(Program.Settings.PaletteNTSCGamma);
            trackBar_ntsc_brightness.Value = ToBrightness(Program.Settings.PaletteNTSCBrightness);
            trackBar_ntsc_saturation.Value = ToSaturation(Program.Settings.PaletteNTSCSaturation);

            trackBar_pal_hue.Value = ToHue(Program.Settings.PalettePALBHue);
            trackBar_pal_contrast.Value = ToContrast(Program.Settings.PalettePALBContrast);
            trackBar_pal_gamma.Value = ToGamma(Program.Settings.PalettePALBGamma);
            trackBar_pal_brightness.Value = ToBrightness(Program.Settings.PalettePALBBrightness);
            trackBar_pal_saturation.Value = ToSaturation(Program.Settings.PalettePALBSaturation);

            trackBar_dendy_hue.Value = ToHue(Program.Settings.PaletteDENDYHue);
            trackBar_dendy_contrast.Value = ToContrast(Program.Settings.PaletteDENDYContrast);
            trackBar_dendy_gamma.Value = ToGamma(Program.Settings.PaletteDENDYGamma);
            trackBar_dendy_brightness.Value = ToBrightness(Program.Settings.PaletteDENDYBrightness);
            trackBar_dendy_saturation.Value = ToSaturation(Program.Settings.PaletteDENDYSaturation);
        }
        private void SaveSettings()
        {
            Program.Settings.PaletteNTSCHue = GetHue(trackBar_ntsc_hue.Value);
            Program.Settings.PaletteNTSCContrast = GetContrast(trackBar_ntsc_contrast.Value);
            Program.Settings.PaletteNTSCGamma = GetGamma(trackBar_ntsc_gamma.Value);
            Program.Settings.PaletteNTSCBrightness = GetBrightness(trackBar_ntsc_brightness.Value);
            Program.Settings.PaletteNTSCSaturation = GetSaturation(trackBar_ntsc_saturation.Value);

            Program.Settings.PalettePALBHue = GetHue(trackBar_pal_hue.Value);
            Program.Settings.PalettePALBContrast = GetContrast(trackBar_pal_contrast.Value);
            Program.Settings.PalettePALBGamma = GetGamma(trackBar_pal_gamma.Value);
            Program.Settings.PalettePALBBrightness = GetBrightness(trackBar_pal_brightness.Value);
            Program.Settings.PalettePALBSaturation = GetSaturation(trackBar_pal_saturation.Value);

            Program.Settings.PaletteDENDYHue = GetHue(trackBar_dendy_hue.Value);
            Program.Settings.PaletteDENDYContrast = GetContrast(trackBar_dendy_contrast.Value);
            Program.Settings.PaletteDENDYGamma = GetGamma(trackBar_dendy_gamma.Value);
            Program.Settings.PaletteDENDYBrightness = GetBrightness(trackBar_dendy_brightness.Value);
            Program.Settings.PaletteDENDYSaturation = GetSaturation(trackBar_dendy_saturation.Value);

            Program.Settings.Save();
        }
        private void ShowPalette(int[] PaletteFormat, Graphics GR)
        {
            int y = 0;
            int x = 0;
            int w = 20;
            int h = 12;
            for (int j = 0; j < PaletteFormat.Length; j++)
            {
                y = (j / 16) * h;
                x = (j % 16) * w;

                GR.FillRectangle(new SolidBrush(Color.FromArgb(PaletteFormat[j])), new Rectangle(x, y, w, h));
            }
        }
        private void ApplyToPalette()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:// NTSC
                    {
                        NTSCPaletteGenerator.hue_tweak = GetHue(trackBar_ntsc_hue.Value);
                        NTSCPaletteGenerator.brightness = GetBrightness(trackBar_ntsc_brightness.Value);
                        NTSCPaletteGenerator.contrast = GetContrast(trackBar_ntsc_contrast.Value);
                        NTSCPaletteGenerator.gamma = GetGamma(trackBar_ntsc_gamma.Value);
                        NTSCPaletteGenerator.saturation = GetSaturation(trackBar_ntsc_saturation.Value); 
                        panel1.Invalidate();
                        break;
                    }
                case 1:// PAL
                    {
                        PALBPaletteGenerator.hue_tweak = GetHue(trackBar_pal_hue.Value);
                        PALBPaletteGenerator.brightness = GetBrightness(trackBar_pal_brightness.Value);
                        PALBPaletteGenerator.contrast = GetContrast(trackBar_pal_contrast.Value);
                        PALBPaletteGenerator.gamma = GetGamma(trackBar_pal_gamma.Value);
                        PALBPaletteGenerator.saturation = GetSaturation(trackBar_pal_saturation.Value);
                        panel1.Invalidate();
                        break;
                    }
                case 2:// DENDY
                    {
                        DENDYPaletteGenerator.hue_tweak = GetHue(trackBar_dendy_hue.Value);
                        DENDYPaletteGenerator.brightness = GetBrightness(trackBar_dendy_brightness.Value);
                        DENDYPaletteGenerator.contrast = GetContrast(trackBar_dendy_contrast.Value);
                        DENDYPaletteGenerator.gamma = GetGamma(trackBar_dendy_gamma.Value);
                        DENDYPaletteGenerator.saturation = GetSaturation(trackBar_dendy_saturation.Value);
                        panel1.Invalidate(); 
                        break;
                    }
            }
        }
        private void ApplyToEmulationCore()
        {
            NTSCPaletteGenerator.hue_tweak = Program.Settings.PaletteNTSCHue;
            NTSCPaletteGenerator.contrast = Program.Settings.PaletteNTSCContrast;
            NTSCPaletteGenerator.gamma = Program.Settings.PaletteNTSCGamma;
            NTSCPaletteGenerator.brightness = Program.Settings.PaletteNTSCBrightness;
            NTSCPaletteGenerator.saturation = Program.Settings.PaletteNTSCSaturation;

            PALBPaletteGenerator.hue_tweak = Program.Settings.PalettePALBHue;
            PALBPaletteGenerator.contrast = Program.Settings.PalettePALBContrast;
            PALBPaletteGenerator.gamma = Program.Settings.PalettePALBGamma;
            PALBPaletteGenerator.brightness = Program.Settings.PalettePALBBrightness;
            PALBPaletteGenerator.saturation = Program.Settings.PalettePALBSaturation;

            DENDYPaletteGenerator.hue_tweak = Program.Settings.PaletteDENDYHue;
            DENDYPaletteGenerator.contrast = Program.Settings.PaletteDENDYContrast;
            DENDYPaletteGenerator.gamma = Program.Settings.PaletteDENDYGamma;
            DENDYPaletteGenerator.brightness = Program.Settings.PaletteDENDYBrightness;
            DENDYPaletteGenerator.saturation = Program.Settings.PaletteDENDYSaturation;

            NesCore.SetupPalette();
        }
        private float GetHue(int v)
        {
            switch (v)
            {
                case 0: return -1F;
                case 1: return -0.081F;
                case 2: return 0F;
                case 3: return +1F;
                default: return 0F;
            }
        }
        private float GetSaturation(int v)
        {
            switch (v)
            {
                case 0: return 0F;
                case 1: return 0.5F;
                case 2: return 1.0F;
                case 3: return 1.2F;
                case 4: return 1.5F;
                case 5: return 1.53F;
                case 6: return 1.54F;
                case 7: return 2.0F;
                case 8: return 3.0F;
                case 9: return 4.0F;
                case 10: return 5.0F;
                default: return 0F;
            }
        }
        private float GetContrast(int v)
        {
            switch (v)
            {
                case 0: return 0.5F;
                case 1: return 0.92F;
                case 2: return 0.94F;
                case 3: return 1.0F;
                case 4: return 1.5F;
                case 5: return 2.0F;
                default: return 0F;
            }
        }
        private float GetBrightness(int v)
        {
            switch (v)
            {
                case 0: return 0.5F;
                case 1: return 1.0F;
                case 2: return 1.07F;
                case 3: return 1.08F;
                case 4: return 1.5F;
                case 5: return 2.0F;
                default: return 0F;
            }
        }
        private float GetGamma(int v)
        {
            switch (v)
            {
                case 0: return 1.0F;
                case 1: return 1.5F;
                case 2: return 1.7F;
                case 3: return 1.8F;
                case 4: return 1.9F;
                case 5: return 1.95F;
                case 6: return 1.99F;
                case 7: return 2.0F;
                case 8: return 2.1F;
                case 9: return 2.2F;
                case 10: return 2.5F;
                default: return 0F;
            }
        }

        private int ToHue(float v)
        {
            if (v == -1F)
                return 0;
            else if (v == -0.081F)
                return 1;
            else if (v == 0F)
                return 2;
            else if (v == +1F)
                return 3;
            return 2;
        }
        private int ToSaturation(float v)
        {
            if (v == 0F)
                return 0;
            else if (v == 0.5F)
                return 1;
            else if (v == 1.0F)
                return 2;
            else if (v == 1.2F)
                return 3;
            else if (v == 1.5F)
                return 4;
            else if (v == 1.53F)
                return 5;
            else if (v == 1.54F)
                return 6;
            else if (v == 2.0F)
                return 7;
            else if (v == 3.0F)
                return 8;
            else if (v == 4.0F)
                return 9;
            else if (v == 5.0F)
                return 10;
            return 2;
        }
        private int ToContrast(float v)
        {
            if (v == 0.5F)
                return 0;
            else if (v == 0.92F)
                return 1;
            else if (v == 0.94F)
                return 2;
            else if (v == 1.0F)
                return 3;
            else if (v == 1.5F)
                return 4;
            else if (v == 2.0F)
                return 5;
            return 3;
        }
        private int ToBrightness(float v)
        {
            if (v == 0.5F)
                return 0;
            else if (v == 1.0F)
                return 1;
            else if (v == 1.07F)
                return 2;
            else if (v == 1.08F)
                return 3;
            else if (v == 1.5F)
                return 4;
            else if (v == 2.0F)
                return 5;
            return 3;
        }
        private int ToGamma(float v)
        {
            if (v == 1.0F)
                return 0;
            else if (v == 1.5F)
                return 1;
            else if (v == 1.7F)
                return 2;
            else if (v == 1.8F)
                return 3;
            else if (v == 1.9F)
                return 4;
            else if (v == 1.95F)
                return 5;
            else if (v == 1.99F)
                return 6;
            else if (v == 2.0F)
                return 7;
            else if (v == 2.1F)
                return 8;
            else if (v == 2.2F)
                return 9;
            else if (v == 2.5F)
                return 10;
            return 3;
        }
        // Save
        private void button5_Click(object sender, EventArgs e)
        {
            SaveSettings();

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }
        // Cancel
        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:// NTSC
                    {
                        ShowPalette(NTSCPaletteGenerator.GeneratePalette(), e.Graphics);
                        break;
                    }
                case 1:// PAL
                    {
                        ShowPalette(PALBPaletteGenerator.GeneratePalette(), e.Graphics);
                        break;
                    }
                case 2:// DENDY
                    {
                        ShowPalette(DENDYPaletteGenerator.GeneratePalette(), e.Graphics);
                        break;
                    }
            }
        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel1.Invalidate();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
        private void NTSCDefaults(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:// NTSC
                    {
                        trackBar_ntsc_hue.Value = ToHue(NTSCPaletteGenerator.default_hue_tweak);
                        trackBar_ntsc_contrast.Value = ToContrast(NTSCPaletteGenerator.default_contrast);
                        trackBar_ntsc_gamma.Value = ToGamma(NTSCPaletteGenerator.default_gamma);
                        trackBar_ntsc_brightness.Value = ToBrightness(NTSCPaletteGenerator.default_brightness);
                        trackBar_ntsc_saturation.Value = ToSaturation(NTSCPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
                case 1:// PAL
                    {
                        trackBar_pal_hue.Value = ToHue(NTSCPaletteGenerator.default_hue_tweak);
                        trackBar_pal_contrast.Value = ToContrast(NTSCPaletteGenerator.default_contrast);
                        trackBar_pal_gamma.Value = ToGamma(NTSCPaletteGenerator.default_gamma);
                        trackBar_pal_brightness.Value = ToBrightness(NTSCPaletteGenerator.default_brightness);
                        trackBar_pal_saturation.Value = ToSaturation(NTSCPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
                case 2:// DENDY
                    {
                        trackBar_dendy_hue.Value = ToHue(NTSCPaletteGenerator.default_hue_tweak);
                        trackBar_dendy_contrast.Value = ToContrast(NTSCPaletteGenerator.default_contrast);
                        trackBar_dendy_gamma.Value = ToGamma(NTSCPaletteGenerator.default_gamma);
                        trackBar_dendy_brightness.Value = ToBrightness(NTSCPaletteGenerator.default_brightness);
                        trackBar_dendy_saturation.Value = ToSaturation(NTSCPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
            }
        }
        private void PALDefaults(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:// NTSC
                    {
                        trackBar_ntsc_hue.Value = ToHue(PALBPaletteGenerator.default_hue_tweak);
                        trackBar_ntsc_contrast.Value = ToContrast(PALBPaletteGenerator.default_contrast);
                        trackBar_ntsc_gamma.Value = ToGamma(PALBPaletteGenerator.default_gamma);
                        trackBar_ntsc_brightness.Value = ToBrightness(PALBPaletteGenerator.default_brightness);
                        trackBar_ntsc_saturation.Value = ToSaturation(PALBPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
                case 1:// PAL
                    {
                        trackBar_pal_hue.Value = ToHue(PALBPaletteGenerator.default_hue_tweak);
                        trackBar_pal_contrast.Value = ToContrast(PALBPaletteGenerator.default_contrast);
                        trackBar_pal_gamma.Value = ToGamma(PALBPaletteGenerator.default_gamma);
                        trackBar_pal_brightness.Value = ToBrightness(PALBPaletteGenerator.default_brightness);
                        trackBar_pal_saturation.Value = ToSaturation(PALBPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
                case 2:// DENDY
                    {
                        trackBar_dendy_hue.Value = ToHue(PALBPaletteGenerator.default_hue_tweak);
                        trackBar_dendy_contrast.Value = ToContrast(PALBPaletteGenerator.default_contrast);
                        trackBar_dendy_gamma.Value = ToGamma(PALBPaletteGenerator.default_gamma);
                        trackBar_dendy_brightness.Value = ToBrightness(PALBPaletteGenerator.default_brightness);
                        trackBar_dendy_saturation.Value = ToSaturation(PALBPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
            }
        }
        private void DENDYDefaults(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:// NTSC
                    {
                        trackBar_ntsc_hue.Value = ToHue(DENDYPaletteGenerator.default_hue_tweak);
                        trackBar_ntsc_contrast.Value = ToContrast(DENDYPaletteGenerator.default_contrast);
                        trackBar_ntsc_gamma.Value = ToGamma(DENDYPaletteGenerator.default_gamma);
                        trackBar_ntsc_brightness.Value = ToBrightness(DENDYPaletteGenerator.default_brightness);
                        trackBar_ntsc_saturation.Value = ToSaturation(DENDYPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
                case 1:// PAL
                    {
                        trackBar_pal_hue.Value = ToHue(DENDYPaletteGenerator.default_hue_tweak);
                        trackBar_pal_contrast.Value = ToContrast(DENDYPaletteGenerator.default_contrast);
                        trackBar_pal_gamma.Value = ToGamma(DENDYPaletteGenerator.default_gamma);
                        trackBar_pal_brightness.Value = ToBrightness(DENDYPaletteGenerator.default_brightness);
                        trackBar_pal_saturation.Value = ToSaturation(DENDYPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
                case 2:// DENDY
                    {
                        trackBar_dendy_hue.Value = ToHue(DENDYPaletteGenerator.default_hue_tweak);
                        trackBar_dendy_contrast.Value = ToContrast(DENDYPaletteGenerator.default_contrast);
                        trackBar_dendy_gamma.Value = ToGamma(DENDYPaletteGenerator.default_gamma);
                        trackBar_dendy_brightness.Value = ToBrightness(DENDYPaletteGenerator.default_brightness);
                        trackBar_dendy_saturation.Value = ToSaturation(DENDYPaletteGenerator.default_saturation);
                        ApplyToPalette();
                        break;
                    }
            }
        }
        private void FLAT(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:// NTSC
                    {
                        trackBar_ntsc_hue.Value = 2;
                        trackBar_ntsc_contrast.Value = 3;
                        trackBar_ntsc_gamma.Value = 3;
                        trackBar_ntsc_brightness.Value = 3;
                        trackBar_ntsc_saturation.Value = 2;
                        ApplyToPalette();
                        break;
                    }
                case 1:// PAL
                    {
                        trackBar_pal_hue.Value = 2;
                        trackBar_pal_contrast.Value = 3;
                        trackBar_pal_gamma.Value = 3;
                        trackBar_pal_brightness.Value = 3;
                        trackBar_pal_saturation.Value = 2;
                        ApplyToPalette();
                        break;
                    }
                case 2:// DENDY
                    {
                        trackBar_dendy_hue.Value = 2;
                        trackBar_dendy_contrast.Value = 3;
                        trackBar_dendy_gamma.Value = 3;
                        trackBar_dendy_brightness.Value = 3;
                        trackBar_dendy_saturation.Value = 2;
                        ApplyToPalette();
                        break;
                    }
            }
        }
        private void LoadFile(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "My Nes Palette Present (*.mnpp)|*.mnpp";
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                string[] lines = File.ReadAllLines(op.FileName);
                float brightness = 0;
                float contrast=0;
                float gamma = 0;
                float hue = 0;
                float saturation = 0;

                // Calculate
                for (int i = 0; i < lines.Length; i++)
                {
                    string[] pars = lines[i].Split(new char[] { '=' });
                    switch (pars[0])
                    {
                        case "Brightness": brightness = float.Parse(pars[1]); break;
                        case "Contrast": contrast = float.Parse(pars[1]); break;
                        case "Gamma": gamma = float.Parse(pars[1]); break;
                        case "Hue": hue = float.Parse(pars[1]); break;
                        case "Saturation": saturation = float.Parse(pars[1]); break;
                    }
                }
                switch (tabControl1.SelectedIndex)
                {
                    case 0:// NTSC
                        {
                            trackBar_ntsc_hue.Value = ToHue(hue);
                            trackBar_ntsc_contrast.Value = ToContrast(contrast);
                            trackBar_ntsc_gamma.Value = ToGamma(gamma);
                            trackBar_ntsc_brightness.Value = ToBrightness(brightness);
                            trackBar_ntsc_saturation.Value = ToSaturation(saturation);
                            break;
                        }
                    case 1:// PAL
                        {
                            trackBar_pal_hue.Value = ToHue(hue);
                            trackBar_pal_contrast.Value = ToContrast(contrast);
                            trackBar_pal_gamma.Value = ToGamma(gamma);
                            trackBar_pal_brightness.Value = ToBrightness(brightness);
                            trackBar_pal_saturation.Value = ToSaturation(saturation);
                            break;
                        }
                    case 2:// DENDY
                        {
                            trackBar_dendy_hue.Value = ToHue(hue);
                            trackBar_dendy_contrast.Value = ToContrast(contrast);
                            trackBar_dendy_gamma.Value = ToGamma(gamma);
                            trackBar_dendy_brightness.Value = ToBrightness(brightness);
                            trackBar_dendy_saturation.Value = ToSaturation(saturation);
                            break;
                        }
                }
            }
        }
        private void SaveFile(object sender, EventArgs e)
        {
            SaveFileDialog sav = new SaveFileDialog();
            sav.Filter = "My Nes Palette Present (*.mnpp)|*.mnpp";
            if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                List<string> lines = new List<string>();
                switch (tabControl1.SelectedIndex)
                {
                    case 0:// NTSC
                        {
                            lines.Add("Brightness=" + NTSCPaletteGenerator.brightness);
                            lines.Add("Contrast=" + NTSCPaletteGenerator.contrast);
                            lines.Add("Gamma=" + NTSCPaletteGenerator.gamma);
                            lines.Add("Hue=" + NTSCPaletteGenerator.hue_tweak);
                            lines.Add("Saturation=" + NTSCPaletteGenerator.saturation);
                            break;
                        }
                    case 1:// PAL
                        {
                            lines.Add("Brightness=" + PALBPaletteGenerator.brightness);
                            lines.Add("Contrast=" + PALBPaletteGenerator.contrast);
                            lines.Add("Gamma=" + PALBPaletteGenerator.gamma);
                            lines.Add("Hue=" + PALBPaletteGenerator.hue_tweak);
                            lines.Add("Saturation=" + PALBPaletteGenerator.saturation);
                            break;
                        }
                    case 2:// DENDY
                        {
                            lines.Add("Brightness=" + DENDYPaletteGenerator.brightness);
                            lines.Add("Contrast=" + DENDYPaletteGenerator.contrast);
                            lines.Add("Gamma=" + DENDYPaletteGenerator.gamma);
                            lines.Add("Hue=" + DENDYPaletteGenerator.hue_tweak);
                            lines.Add("Saturation=" + DENDYPaletteGenerator.saturation);
                            break;
                        }
                }
                File.WriteAllLines(sav.FileName, lines.ToArray());
            }
        }
        private void UPDATEValues(object sender, EventArgs e)
        {
            ApplyToPalette();
            // Apply to emulation core !
            NesCore.SetupPalette();
        }
        // Apply
        private void button21_Click(object sender, EventArgs e)
        {
            NesCore.SetupPalette();
        }
    }
}
