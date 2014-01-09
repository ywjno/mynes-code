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
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using MyNes.Core;
using MyNes.Core.IO;
using MyNes.Core.PPU;
using MyNes.Core.ROM.Exceptions;
using MyNes.Core.ROM;
using MyNes.Renderers;
using MMB;
namespace MyNes
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            LoadSettings();
        }

        private const string mainTitle = "My Nes [v6 beta]";// Never change this !
        private string currentGameFile;
        private int mouseHideTimer = 0;
        private bool mouseHiding = false;

        private void LoadSettings()
        {
            LoadLanguages();
            ApplyViewSettings();
            this.Location = Program.Settings.MainWindowLocation;
            this.Size = Program.Settings.MainWindowSize;
            LoadRecents();
            // This will reload state slot menu items
            stateToolStripMenuItem_DropDownOpening(this, null);
            // Load text for state slot
            toolStripSplitButton_stateSlot.Text = Program.ResourceManager.GetString("Item_StateSlot")
                  + " " + NesCore.StateSlot;
        }
        private void SaveSettings()
        {
            Program.Settings.MainWindowLocation = this.Location;
            Program.Settings.MainWindowSize = this.Size;
            Program.Settings.Save();
        }
        private void LoadRecents()
        {
            if (Program.Settings.FileRecents == null)
                Program.Settings.FileRecents = new System.Collections.Specialized.StringCollection();

            recentRomsToolStripMenuItem.DropDownItems.Clear();
            toolStripSplitButton_recents.DropDownItems.Clear();
            foreach (string file in Program.Settings.FileRecents)
            {
                if (File.Exists(file))
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = Path.GetFileName(file);
                    item.Tag = item.ToolTipText = file;
                    recentRomsToolStripMenuItem.DropDownItems.Add(item);
                    // Add another items
                    item = new ToolStripMenuItem();
                    item.Text = Path.GetFileName(file);
                    item.Tag = item.ToolTipText = file;
                    toolStripSplitButton_recents.DropDownItems.Add(item);
                }
            }
        }
        private void LoadLanguages()
        {
            for (int i = 0; i < Program.SupportedLanguages.Length / 3; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = Program.SupportedLanguages[i, 2];
                item.Checked = Program.SupportedLanguages[i, 0] == Program.Settings.Language;
                languageToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        private void AddRecent(string fileName)
        {
            // If the file exists, remove it
            if (Program.Settings.FileRecents.Contains(fileName))
                Program.Settings.FileRecents.Remove(fileName);
            // Insert at the beginning
            Program.Settings.FileRecents.Insert(0, fileName);
            // Limit to 10 !
            if (Program.Settings.FileRecents.Count == 10)
                Program.Settings.FileRecents.RemoveAt(9);
            Program.Settings.Save();
            // Refresh !
            LoadRecents();
        }
        private void ApplyViewSettings()
        {
            if (!Program.Settings.ShowMenu && Program.Settings.HidingMenuForFirstTime)
            {
                Program.Settings.HidingMenuForFirstTime = false;
                ManagedMessageBox.ShowMessage(Program.ResourceManager.GetString("Message_YoureHidingTheMainMenuForTheFirstTime"), "My Nes");
            }
            menuStrip1.Visible = showMenuStripToolStripMenuItem.Checked = Program.Settings.ShowMenu;
            toolStrip1.Visible = showToolsStripToolStripMenuItem.Checked = Program.Settings.ShowToolsBar;
            statusStrip1.Visible = showStatusStripToolStripMenuItem.Checked = Program.Settings.ShowStatus;
        }

        public void LoadRom(string FileName, bool addRecent)
        {
            currentGameFile = FileName;
            #region Check if archive
            SevenZip.SevenZipExtractor EXTRACTOR;
            if (Path.GetExtension(FileName).ToLower() != ".nes")
            {
                if (!File.Exists("7z.dll"))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_7zIsNotExist"),
                       Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                    if (NesCore.ON) NesCore.PAUSED = false;
                    return;
                }
                try
                {
                    EXTRACTOR = new SevenZip.SevenZipExtractor(FileName);
                }
                catch (Exception ex)
                {
                    ManagedMessageBox.ShowErrorMessage(ex.Message,
                     Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                    if (NesCore.ON) NesCore.PAUSED = false;
                    return;
                }
                if (EXTRACTOR.ArchiveFileData.Count == 1)
                {
                    if (EXTRACTOR.ArchiveFileData[0].FileName.Substring(EXTRACTOR.ArchiveFileData[0].FileName.Length - 4, 4).ToLower() == ".NesCore")
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
                    { if (NesCore.ON) NesCore.PAUSED = false; return; }
                }
            }
            #endregion
            // Check rom ...
            int mapperN = 0;
            switch (NesCore.CheckRom(FileName, out mapperN))
            {
                case RomReadResult.NotSupportedBoard:
                    {
                        ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_NotsupportedMapper") + " #" + mapperN,
                            Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                        if (NesCore.ON) NesCore.PAUSED = false;
                        return;
                    }
                case RomReadResult.Invalid:
                    {
                        ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_RomInvalid"),
                                    Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                        if (NesCore.ON) NesCore.PAUSED = false;
                        return;
                    }
            }
            if (NesCore.ON)
            {
                NesCore.ShutDown();
            }
            try
            {
                NesCore.CreateNew(FileName, Program.Settings.TVFormat);
            }
            // These exceptions should happen only when we never do the check above !
            catch (NotSupportedMapperOrBoardExcption ex)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_NotsupportedMapper") + " #" + ex.Mapper,
                          Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                if (NesCore.ON) NesCore.PAUSED = false;
                return;
            }
            catch (InvailedRomException ex)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_RomInvalid"),
                           Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                if (NesCore.ON) NesCore.PAUSED = false;
                return;
            }
            catch (Exception ex)
            {
                ManagedMessageBox.ShowErrorMessage(ex.Message + "\n\n" + ex.ToString(),
                       Program.ResourceManager.GetString("MessageCaption_OpenRom"));
                if (NesCore.ON) NesCore.PAUSED = false;
                return;
            }
            // add recent !
            if (addRecent)
                AddRecent(currentGameFile);
            // pause the emulation so the renderer should continue once it's ready
            NesCore.PAUSED = true;
            // apply settings !
            ApplyEmuSettings();
            // turn on
            NesCore.TurnOn(true);
            // initialize renderer
            InitializeRenderer();
            // un-pause !
            NesCore.PAUSED = false;
        }
        private void InitializeRenderer()
        {
            // Video and sound
            ApplyVideo();
            ApplyAudio();
            SetupPalette();
            SetupInput();
            // Rom title !
            if (NesCore.RomInfo.DatabaseGameInfo.Game_Name != null)
            {
                this.Text = NesCore.RomInfo.DatabaseGameInfo.Game_Name +
                    " (" + NesCore.RomInfo.DatabaseGameInfo.Game_AltName + ") - " + mainTitle;
            }
            else
            {
                this.Text = Path.GetFileNameWithoutExtension(NesCore.RomInfo.RomPath) + " - " + mainTitle;
            }
        }
        private void SetupInput()
        {
            // Initialize ..
            SlimDXInputManager inputManager = new SlimDXInputManager(this.Handle);
            //Setup input
            SlimDXJoypad joy1 = new SlimDXJoypad(inputManager);
            SlimDXJoypad joy2 = new SlimDXJoypad(inputManager);
            SlimDXJoypad joy3 = new SlimDXJoypad(inputManager);
            SlimDXJoypad joy4 = new SlimDXJoypad(inputManager);

            NesCore.SetupInput(inputManager, joy1, joy2, joy3, joy4, false);

            NesCore.ControlsUnit.VSunisystemDIP = new SlimDXVSUnisystemDIP(inputManager);

            ApplyInput();
        }
        private void ApplyInput()
        {
            // Get profiles
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();

            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).A.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.A;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).B.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.B;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).TurboA.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.TurboA;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).TurboB.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.TurboB;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).Down.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.Down;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).Left.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.Left;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).Right.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.Right;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).Up.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.Up;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).Select.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.Select;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad1).Start.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player1.Start;

            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).A.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.A;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).B.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.B;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).TurboA.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.TurboA;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).TurboB.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.TurboB;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).Down.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.Down;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).Left.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.Left;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).Right.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.Right;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).Up.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.Up;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).Select.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.Select;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad2).Start.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player2.Start;

            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).A.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.A;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).B.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.B;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).TurboA.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.TurboA;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).TurboB.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.TurboB;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).Down.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.Down;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).Left.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.Left;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).Right.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.Right;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).Up.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.Up;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).Select.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.Select;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad3).Start.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player3.Start;

            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).A.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.A;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).B.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.B;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).TurboA.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.TurboA;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).TurboB.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.TurboB;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).Down.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.Down;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).Left.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.Left;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).Right.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.Right;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).Up.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.Up;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).Select.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.Select;
            ((SlimDXJoypad)NesCore.ControlsUnit.Joypad4).Start.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Player4.Start;

            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).CreditLeftCoinSlot.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.CreditLeftCoinSlot;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).CreditRightCoinSlot.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.CreditRightCoinSlot;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).CreditServiceButton.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.CreditServiceButton;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch1.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch1;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch2.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch2;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch3.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch3;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch4.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch4;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch5.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch5;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch6.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch6;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch7.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch7;
            ((SlimDXVSUnisystemDIP)NesCore.ControlsUnit.VSunisystemDIP).DIPSwitch8.Input = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].VSunisystemDIP.DIPSwitch8;

            if (Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].ConnectZapper)
            {
                NesCore.ControlsUnit.IsZapperConnected = true;
                NesCore.ControlsUnit.Zapper = new SlimDXZapper();
            }
            NesCore.ControlsUnit.IsFourPlayers = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Connect4Players;
        }
        private void ApplyVideo()
        {
            if (NesCore.VideoOutput != null)
                NesCore.VideoOutput.ShutDown();
            NesCore.VideoOutput = null;
            NesCore.PAUSED = true;
            // Windowed stretch !
            if (Program.Settings.VideoStretchWindowToFitSize)
            {
                // Determine res
                int w = 256;
                int h = 240;
                if (Program.Settings.VideoCutLines)
                {
                    if (NesCore.TV == TVSystem.NTSC)
                        h = 224;
                    else
                        h = 238;
                }
                w *= Program.Settings.VideoWindowStretchMultiply;
                h *= Program.Settings.VideoWindowStretchMultiply;
                // Do the stretch !
                int windowW = w + 16;
                int windowH = h + 39;
                if (menuStrip1.Visible)
                    windowH += menuStrip1.Height;
                if (toolStrip1.Visible)
                    windowH += toolStrip1.Height;
                if (statusStrip1.Visible)
                    windowH += statusStrip1.Height;
                this.Size = new Size(windowW, windowH);

                //MessageBox.Show("Surface size is "+panel_surface.Width +" x "+panel_surface.Height);
            }
            IVideoDevice video = null;
            switch (Program.Settings.VideoOutputMode)
            {
                case VideoOutputMode.DirectX9: video = new SlimDXVideo(panel_surface); break;
            }
            video.Initialize();

            NesCore.VideoOutput = video;
        }
        private void ApplyAudio()
        {
            IAudioDevice audio = null;

            switch (Program.Settings.AudioOutputMode)
            {
                case SoundOutputMode.DirectSound: audio = new SlimDXDirectSound(this.Handle); break;
            }

            NesCore.APU.SetupPlayback(Program.Settings.AudioFrequency);
            NesCore.AudioOutput = audio;
        }
        private void ApplyEmuSettings()
        {
            NesCore.ApplySettings(new NesCoreSettings(
                  Program.Settings.AudioSoundEnabled,
                  Program.Settings.FolderSrams,
                  Program.Settings.SaveSRAMOnShutdown));
            // Frame skipping
            NesCore.FrameSkipEnabled = Program.Settings.FrameSkippingEnabled;
            NesCore.frameSkipReload = Program.Settings.FrameSkippingCount;
        }
        private void SetupPalette()
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

            DENDYPaletteGenerator.hue_tweak = (float)Program.Settings.PaletteDENDYHue;
            DENDYPaletteGenerator.contrast = (float)Program.Settings.PaletteDENDYContrast;
            DENDYPaletteGenerator.gamma = (float)Program.Settings.PaletteDENDYGamma;
            DENDYPaletteGenerator.brightness = (float)Program.Settings.PaletteDENDYBrightness;
            DENDYPaletteGenerator.saturation = (float)Program.Settings.PaletteDENDYSaturation;

            NesCore.SetupPalette();
        }

        private void Form_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (NesCore.ON)
                NesCore.ShutDown();
            SaveSettings();
        }
        private void ShowConsole(object sender, EventArgs e)
        {
            foreach (Form frm in this.OwnedForms)
            {
                if (frm.Tag.ToString() == "Console")
                {
                    frm.Activate();
                    return;
                }
            }
            FormConsole newfrm = new FormConsole();
            newfrm.Show(this);
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ShowMemoryWatcher(object sender, EventArgs e)
        {
            foreach (Form frm in this.OwnedForms)
            {
                if (frm.Tag.ToString() == "Memory")
                {
                    frm.Activate();
                    return;
                }
            }
            FormMemoryWatcher newfrm = new FormMemoryWatcher();
            newfrm.Show(this);
        }
        private void ShowSpeed(object sender, EventArgs e)
        {
            foreach (Form frm in this.OwnedForms)
            {
                if (frm.Tag.ToString() == "Speed")
                {
                    frm.Activate();
                    return;
                }
            }
            FormSpeed newfrm = new FormSpeed();
            newfrm.Show(this);
        }
        private void OpenRom(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = true;
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = Program.ResourceManager.GetString("Filter_ROM");
            op.Title = Program.ResourceManager.GetString("Title_OpenRom");
            if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                LoadRom(op.FileName, true);
            }
            else
            {
                if (NesCore.ON)
                    NesCore.PAUSED = false;
            }
        }
        private void ShowVideoSettings(object sender, EventArgs e)
        {
            NesCore.PAUSED = true;

            FormVideoSettings frm = new FormVideoSettings();
            frm.ShowDialog(this);
            if (NesCore.ON)
            {
                NesCore.VideoOutput.ShutDown();

                ApplyVideo();
                NesCore.PAUSED = false;
            }
        }
        private void ShowAudioSettings(object sender, EventArgs e)
        {
            NesCore.PAUSED = true;

            FormAudioSettings frm = new FormAudioSettings();
            frm.ShowDialog(this);

            if (NesCore.ON)
            {
                NesCore.AudioOutput.Shutdown();
                // Apply
                ApplyAudio();
                NesCore.PAUSED = false;
            }
        }
        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NesCore.ShutDown();
        }
        private void ShowPaletteSettings(object sender, EventArgs e)
        {
            // NesCore.PAUSED = true;
            // turn of auto pause
            bool autoPause = Program.Settings.MainWindowAutoPauseOnFocusLost;
            Program.Settings.MainWindowAutoPauseOnFocusLost = false;
            FormPaletteSettings frm = new FormPaletteSettings();
            frm.ShowDialog(this);
            if (NesCore.ON)
            {
                SetupPalette();// Apply palette to emulation !
                //   NesCore.PAUSED = false;
            }

            Program.Settings.MainWindowAutoPauseOnFocusLost = autoPause;
        }
        private void ShowPathsSettings(object sender, EventArgs e)
        {
            NesCore.PAUSED = true;

            FormPaths frm = new FormPaths();
            frm.ShowDialog(this);

            if (NesCore.ON)
            {
                NesCore.SRAMFolder = Program.Settings.FolderSrams;
                NesCore.PAUSED = false;
            }
        }
        private void ShowInputSetting(object sender, EventArgs e)
        {
            NesCore.PAUSED = true;
            FormInputSettings frm = new FormInputSettings();
            frm.ShowDialog(this);
            if (NesCore.ON)
            {
                ApplyInput();
                NesCore.PAUSED = false;
            }
        }
        private void ShowBrowser(object sender, EventArgs e)
        {
            foreach (Form frm in this.OwnedForms)
            {
                if (frm.Tag.ToString() == "Browser")
                {
                    frm.Activate();
                    return;
                }
            }
            FormBrowser newfrm = new FormBrowser();
            newfrm.Show(this);
        }
        private void regionToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // Load tv setting
            foreach (ToolStripMenuItem it in regionToolStripMenuItem.DropDownItems)
                it.Checked = false;
            switch (Program.Settings.TVFormat)
            {
                case TVSystemSettings.AUTO: aUTOToolStripMenuItem.Checked = true; break;
                case TVSystemSettings.DENDY: dENDYToolStripMenuItem.Checked = true; break;
                case TVSystemSettings.NTSC: nTSCToolStripMenuItem.Checked = true; break;
                case TVSystemSettings.PALB: pALBToolStripMenuItem.Checked = true; break;
            }
        }
        private void aUTOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in regionToolStripMenuItem.DropDownItems)
                it.Checked = false;
            aUTOToolStripMenuItem.Checked = true;
            // Save
            Program.Settings.TVFormat = TVSystemSettings.AUTO;
            Program.Settings.Save();
            if (NesCore.ON)
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_RegionChangedToAuto"),
                        120, Color.Yellow.ToArgb());
        }
        private void nTSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in regionToolStripMenuItem.DropDownItems)
                it.Checked = false;
            nTSCToolStripMenuItem.Checked = true;
            // Save
            Program.Settings.TVFormat = TVSystemSettings.NTSC;
            Program.Settings.Save();
            if (NesCore.ON)
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_RegionChangedToNTSC"), 120, Color.Yellow.ToArgb());

        }
        private void pALBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in regionToolStripMenuItem.DropDownItems)
                it.Checked = false;
            pALBToolStripMenuItem.Checked = true;
            // Save
            Program.Settings.TVFormat = TVSystemSettings.PALB;
            Program.Settings.Save();
            if (NesCore.ON)
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_RegionChangedToPALB"), 120, Color.Yellow.ToArgb());
        }
        private void dENDYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in regionToolStripMenuItem.DropDownItems)
                it.Checked = false;
            dENDYToolStripMenuItem.Checked = true;
            // Save
            Program.Settings.TVFormat = TVSystemSettings.DENDY;
            Program.Settings.Save();
            if (NesCore.ON)
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_RegionChangedToDENDY"), 120, Color.Yellow.ToArgb());
        }
        private void TogglePause(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = !NesCore.PAUSED;
        }
        private void HardReset(object sender, EventArgs e)
        {
            if (NesCore.ON)
                LoadRom(NesCore.RomInfo.RomPath, false);
        }
        private void SoftReset(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.SoftReset();
        }
        private void fileToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            recentRomsToolStripMenuItem.Enabled = recentRomsToolStripMenuItem.DropDownItems.Count > 0;
        }
        private void recordSoundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                if (NesCore.AudioOutput == null)
                {
                    return;
                }
                NesCore.PAUSED = true;
                if (NesCore.AudioOutput.IsRecording)
                {
                    NesCore.AudioOutput.RecordStop();
                }
                else
                {
                    SaveFileDialog sav = new SaveFileDialog();
                    sav.Title = Program.ResourceManager.GetString("Title_SaveWav");
                    sav.Filter = Program.ResourceManager.GetString("Filter_PCMWav");
                    if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                        NesCore.AudioOutput.Record(sav.FileName);
                }
                NesCore.PAUSED = false;
            }
        }
        private void fileToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                takesnapshotToolStripMenuItem.Enabled = true;
                if (NesCore.AudioOutput == null)
                {
                    recordSoundToolStripMenuItem.Enabled = false;
                    recordSoundToolStripMenuItem.Text = Program.ResourceManager.GetString("Button_RecordSound");
                    return;
                }
                recordSoundToolStripMenuItem.Enabled = true;
                if (NesCore.AudioOutput.IsRecording)
                {
                    recordSoundToolStripMenuItem.Text = Program.ResourceManager.GetString("Button_StopRecordSound");
                }
                else
                {
                    recordSoundToolStripMenuItem.Text = Program.ResourceManager.GetString("Button_RecordSound");
                }
            }
            else
            {
                takesnapshotToolStripMenuItem.Enabled = false;
                recordSoundToolStripMenuItem.Enabled = false;
                recordSoundToolStripMenuItem.Text = Program.ResourceManager.GetString("Button_RecordSound");
            }
        }
        private void inputToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // Fix
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();

            connect4PlayersToolStripMenuItem.Checked = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Connect4Players;
            connectZapperToolStripMenuItem.Checked = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].ConnectZapper;

            profileToolStripMenuItem.DropDownItems.Clear();

            foreach (ControlProfile p in Program.Settings.InputProfiles)
            {
                ToolStripMenuItem it = new ToolStripMenuItem();
                it.Text = p.Name;
                it.Checked = p.Name == Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Name;

                profileToolStripMenuItem.DropDownItems.Add(it);
            }
        }
        private void connectZapperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NesCore.PAUSED = true;
            // Get profiles
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();

            Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].ConnectZapper =
                !Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].ConnectZapper;
            Program.Settings.Save();
            if (NesCore.ON)
            {
                ApplyInput();
                NesCore.PAUSED = false;
            }
        }
        private void connect4PlayersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NesCore.PAUSED = true;
            // Get profiles
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();

            Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Connect4Players =
                !Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Connect4Players;
            Program.Settings.Save();
            if (NesCore.ON)
            {
                ApplyInput();
                NesCore.PAUSED = false;
            }
        }
        private void profileToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            NesCore.PAUSED = true;
            // Get profiles
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();
            for (int i = 0; i < Program.Settings.InputProfiles.Count; i++)
            {
                if (e.ClickedItem.Text == Program.Settings.InputProfiles[i].Name)
                {
                    Program.Settings.InputProfileIndex = i;
                    // Save
                    Program.Settings.Save();
                    if (NesCore.ON)
                    {
                        ApplyInput();
                        NesCore.PAUSED = false;
                    }

                    break;
                }
            }
        }
        private void TakeSnapshot(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;

                // Make sure
                Directory.CreateDirectory(Program.Settings.FolderSnapshots);
                // Take it !
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.TakeSnapshot(Program.Settings.FolderSnapshots,
                    Path.GetFileNameWithoutExtension(NesCore.RomInfo.RomPath),
                    Program.Settings.SnapshotsFormat,
                    false);

                NesCore.PAUSED = false;
            }
        }
        private void recentRomsToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = true;
            LoadRom(e.ClickedItem.Tag.ToString(), true);
        }
        private void SwitchToFullscreen(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;
                NesCore.VideoOutput.SwitchFullscreen();
            }
        }
        private void FormMain_ResizeBegin(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.VideoOutput.ResizeBegin();
            }
        }
        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.VideoOutput.ResizeEnd();
            }
        }
        private void stateToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            slotToolStripMenuItem.DropDownItems.Clear();
            for (int i = 0; i < 10; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = Program.ResourceManager.GetString("Item_StateSlot") + " " + i;
                item.Tag = i;
                item.Checked = (i == NesCore.StateSlot);
                Keys k = (Keys)Enum.Parse(typeof(Keys), "D" + i.ToString());
                item.ShortcutKeys = Keys.Control | k;
                slotToolStripMenuItem.DropDownItems.Add(item);
            }
        }
        private void slotToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            NesCore.StateSlot = (int)e.ClickedItem.Tag;
            if (NesCore.VideoOutput != null)
                NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_StateSlotChangedTo")
                    + " " + NesCore.StateSlot, 120, Color.White.ToArgb());
            toolStripSplitButton_stateSlot.Text = Program.ResourceManager.GetString("Item_StateSlot")
                + " " + NesCore.StateSlot;
        }
        private void SaveState(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.SaveState(Program.Settings.FolderStates);
        }
        private void SaveStateAs(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;
                SaveFileDialog sav = new SaveFileDialog();
                sav.Title = Program.ResourceManager.GetString("Title_SaveStateFile");
                sav.Filter = Program.ResourceManager.GetString("Filter_StateFile");
                if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    NesCore.SaveStateAs(sav.FileName);
                }
            }
        }
        private void LoadState(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.LoadState(Program.Settings.FolderStates);
        }
        private void LoadStateAs(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;
                OpenFileDialog op = new OpenFileDialog();
                op.Title = Program.ResourceManager.GetString("Title_LoadStateFile");
                op.Filter = Program.ResourceManager.GetString("Filter_StateFile");
                if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    NesCore.LoadStateAs(op.FileName);
                }
            }
        }
        private void QuickSaveState(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.SaveMemoryState();
        }
        private void QuickLoadState(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.LoadMemoryState();
        }
        private void SaveSRAM(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.RequestSRAMSave();
        }
        private void SaveSRAMAs(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;
                SaveFileDialog sav = new SaveFileDialog();
                sav.Title = Program.ResourceManager.GetString("Title_SaveSRAM");
                sav.Filter = Program.ResourceManager.GetString("Filter_SRAMFile");
                if (sav.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    NesCore.SaveSramAs(sav.FileName);
                }
            }
        }
        private void LoadSRAM(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.RequestSRAMLoad();
        }
        private void LoadSRAMAs(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;
                OpenFileDialog op = new OpenFileDialog();
                op.Title = Program.ResourceManager.GetString("Title_LoadStateFile");
                op.Filter = Program.ResourceManager.GetString("Title_LoadSRAMFile");
                if (op.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                {
                    NesCore.LoadSramAs(op.FileName);
                }
            }
        }
        private void ToggleTurbo(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.SpeedLimiter.ON = !NesCore.SpeedLimiter.ON;
                if (!NesCore.SpeedLimiter.ON)
                {
                    NesCore.VideoOutput.DrawNotification("Turbo enabled !", 120, Color.Green.ToArgb());
                }
                else
                {
                    NesCore.VideoOutput.DrawNotification("Turbo disabled !", 120, Color.Green.ToArgb());
                }
                NesCore.AudioOutput.ResetBuffer();
                NesCore.APU.ResetBuffer();
            }
        }
        private void toolsToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                turboSpeedToolStripMenuItem.Checked = !NesCore.SpeedLimiter.ON;
            }
            else
            { turboSpeedToolStripMenuItem.Checked = false; }
        }
        private void frameskippingToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            // Uncheck all
            for (int i = 0; i < frameskippingToolStripMenuItem.DropDownItems.Count; i++)
            {
                ((ToolStripMenuItem)frameskippingToolStripMenuItem.DropDownItems[i]).Checked = false;
            }
            if (!Program.Settings.FrameSkippingEnabled)
                disableToolStripMenuItem.Checked = true;
            else
            {
                switch (Program.Settings.FrameSkippingCount)
                {
                    default: disableToolStripMenuItem.Checked = true; break;
                    case 1: fPSForNTSCToolStripMenuItem.Checked = true; break;
                    case 2: fPSForNTSCToolStripMenuItem1.Checked = true; break;
                    case 3: fPSForNTSCToolStripMenuItem2.Checked = true; break;
                    case 4: toolStripMenuItem2.Checked = true; break;
                }
            }
        }
        private void disableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.FrameSkippingEnabled = false;
            if (NesCore.ON)
                ApplyEmuSettings();
        }
        private void fPSForNTSCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.FrameSkippingEnabled = true;
            Program.Settings.FrameSkippingCount = 1;
            if (NesCore.ON)
                ApplyEmuSettings();
        }
        private void fPSForNTSCToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Program.Settings.FrameSkippingEnabled = true;
            Program.Settings.FrameSkippingCount = 2;
            if (NesCore.ON)
                ApplyEmuSettings();
        }
        private void fPSForNTSCToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.Settings.FrameSkippingEnabled = true;
            Program.Settings.FrameSkippingCount = 3;
            if (NesCore.ON)
                ApplyEmuSettings();
        }
        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Program.Settings.FrameSkippingEnabled = true;
            Program.Settings.FrameSkippingCount = 4;
            if (NesCore.ON)
                ApplyEmuSettings();
        }
        private void languageToolStripMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            int i = 0;
            int index = 0;
            foreach (ToolStripMenuItem item in languageToolStripMenuItem.DropDownItems)
            {
                if (item.Text == e.ClickedItem.Text)
                {
                    item.Checked = true;
                    index = i;
                }
                else
                    item.Checked = false;
                i++;
            }
            Program.Language = Program.SupportedLanguages[index, 0];
            Program.Settings.Language = Program.SupportedLanguages[index, 0];

            MessageBox.Show(Program.ResourceManager.GetString("Message_YouMustRestartTheProgramToApplyLanguage"),
                Program.ResourceManager.GetString("MessageCaption_ApplyLanguage"));
        }
        private void showMenuStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.ShowMenu = !Program.Settings.ShowMenu;
            ApplyViewSettings();
        }
        private void showToolsStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.ShowToolsBar = !Program.Settings.ShowToolsBar;
            ApplyViewSettings();
        }
        private void ShowHelp(object sender, EventArgs e)
        {
            try
            {
                string startup = Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]);
                Help.ShowHelp(this, startup + "\\" + Program.CultureInfo.Name + "\\Help.chm", HelpNavigator.TableOfContents);
            }
            catch (Exception ex)
            {
                ManagedMessageBox.ShowErrorMessage(ex.Message, mainTitle);
            }
        }
        private void toolStripSplitButton1_DropDownOpening(object sender, EventArgs e)
        {
            foreach (ToolStripMenuItem it in toolStripSplitButton1.DropDownItems)
                it.Checked = false;
            switch (Program.Settings.TVFormat)
            {
                case TVSystemSettings.AUTO: aUTOToolStripMenuItem1.Checked = true; break;
                case TVSystemSettings.DENDY: dENDYToolStripMenuItem1.Checked = true; break;
                case TVSystemSettings.NTSC: nTSCToolStripMenuItem1.Checked = true; break;
                case TVSystemSettings.PALB: pALBToolStripMenuItem1.Checked = true; break;
            }
        }
        private void toolStripSplitButton2_DropDownOpening(object sender, EventArgs e)
        {
            toolStripSplitButton_stateSlot.DropDownItems.Clear();
            for (int i = 0; i < 10; i++)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = Program.ResourceManager.GetString("Item_StateSlot") + " " + i;
                item.Tag = i;
                item.Checked = (i == NesCore.StateSlot);

                toolStripSplitButton_stateSlot.DropDownItems.Add(item);
            }
        }
        private void toolStripSplitButton2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            NesCore.StateSlot = (int)e.ClickedItem.Tag;
            if (NesCore.VideoOutput != null)
                NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_StateSlotChangedTo")
                    + " " + NesCore.StateSlot, 120, Color.White.ToArgb());
            toolStripSplitButton_stateSlot.Text = Program.ResourceManager.GetString("Item_StateSlot")
                    + " " + NesCore.StateSlot;
        }
        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
            // Switch region..
            switch (Program.Settings.TVFormat)
            {
                case TVSystemSettings.AUTO: nTSCToolStripMenuItem_Click(this, null); break;
                case TVSystemSettings.DENDY: aUTOToolStripMenuItem_Click(this, null); break;
                case TVSystemSettings.NTSC: pALBToolStripMenuItem_Click(this, null); break;
                case TVSystemSettings.PALB: dENDYToolStripMenuItem_Click(this, null); break;
            }
        }
        private void toolStripSplitButton_stateSlot_ButtonClick(object sender, EventArgs e)
        {
            NesCore.StateSlot = (NesCore.StateSlot + 1) % 10;
            if (NesCore.VideoOutput != null)
                NesCore.VideoOutput.DrawNotification(Program.ResourceManager.GetString("Status_StateSlotChangedTo")
                    + " " + NesCore.StateSlot, 120, Color.White.ToArgb());
            toolStripSplitButton_stateSlot.Text = Program.ResourceManager.GetString("Item_StateSlot")
                    + " " + NesCore.StateSlot;
        }
        private void aboutMyNesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = true;

            FormAbout frm = new FormAbout();
            frm.ShowDialog(this);

            if (NesCore.ON)
                NesCore.PAUSED = false;
        }
        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            if (NesCore.ON && Program.Settings.MainWindowAutoPauseOnFocusLost)
                NesCore.PAUSED = true;
        }
        private void FormMain_Activated(object sender, EventArgs e)
        {
            if (NesCore.ON && Program.Settings.MainWindowAutoPauseOnFocusLost)
                NesCore.PAUSED = false;
        }
        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = true;

            FormPreferences frm = new FormPreferences();
            frm.ShowDialog(this);

            if (NesCore.ON)
                NesCore.PAUSED = false;
        }
        // The status timer
        private void timer_status_Tick(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                // Game genie
                if (NesCore.BOARD.IsGameGenieActive)
                    StatusLabel_GameGenie.Text = "Game Genie";
                else
                    StatusLabel_GameGenie.Text = "";

                if (NesCore.PAUSED)
                {
                    StatusLabel_emulation.Text = Program.ResourceManager.GetString("Status_Emulation") + ": " +
                   Program.ResourceManager.GetString("Status_PAUSED");
                    // Show mouse cursor
                    if (mouseHiding)
                    { Cursor.Show(); mouseHiding = false; }
                }
                else
                {
                    StatusLabel_emulation.Text = Program.ResourceManager.GetString("Status_Emulation") + ": " +
                      Program.ResourceManager.GetString("Status_ON");
                    // Mouse hiding ?
                    if (Program.Settings.AutoHideMouse)
                    {
                        if (mouseHideTimer > 0)
                            mouseHideTimer--;
                        else if (mouseHideTimer == 0)
                        {
                            mouseHideTimer = -1;
                            if (this.Focused)
                            {
                                if (!mouseHiding)
                                {
                                    mouseHiding = true;
                                    Cursor.Hide();
                                }
                            }
                            else  // Show mouse cursor
                            {
                                if (mouseHiding)
                                { Cursor.Show(); mouseHiding = false; }
                            }
                        }
                    }

                }
                StatusLabel_tv.Text = NesCore.TV.ToString();
                // Normal status
                string status = "";

                if (NesCore.AudioOutput != null)
                {
                    if (NesCore.AudioOutput.IsRecording)
                    {
                        status += Program.ResourceManager.GetString("Status_RecordingSound") +
                         " [" + TimeSpan.FromSeconds(NesCore.AudioOutput.RecordTime) + "]";
                    }
                }
                StatusLabel_notifications.Text = status;

            }
            else
            {
                StatusLabel_emulation.Text = Program.ResourceManager.GetString("Status_Emulation") + ": " +
                  Program.ResourceManager.GetString("Status_OFF");
                StatusLabel_tv.Text = "";
                StatusLabel_GameGenie.Text = "";
                if (this.Text != mainTitle)
                    this.Text = mainTitle;
                // Show mouse cursor
                if (mouseHiding)
                { Cursor.Show(); mouseHiding = false; }
            }
        }
        private void showStatusStripToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.Settings.ShowStatus = !Program.Settings.ShowStatus;
            ApplyViewSettings();
        }
        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseHiding)
            { Cursor.Show(); mouseHiding = false; }
            if (Program.Settings.AutoHideMouse)
                mouseHideTimer = Program.Settings.AutoHideMousePeriod;
        }
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        private void menuStrip1_MenuActivate(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = true;
        }
        private void menuStrip1_MenuDeactivate(object sender, EventArgs e)
        {
            if (NesCore.ON)
                NesCore.PAUSED = false;
        }
        private void toolStripSplitButton2_DropDownOpening_1(object sender, EventArgs e)
        {
            // Fix
            if (Program.Settings.InputProfiles == null)
                ControlProfile.BuildDefaultProfile();
            if (Program.Settings.InputProfiles.Count == 0)
                ControlProfile.BuildDefaultProfile();

            connect4PlayersToolStripMenuItem1.Checked = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Connect4Players;
            connectZapperToolStripMenuItem1.Checked = Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].ConnectZapper;

            profileToolStripMenuItem1.DropDownItems.Clear();

            foreach (ControlProfile p in Program.Settings.InputProfiles)
            {
                ToolStripMenuItem it = new ToolStripMenuItem();
                it.Text = p.Name;
                it.Checked = p.Name == Program.Settings.InputProfiles[Program.Settings.InputProfileIndex].Name;

                profileToolStripMenuItem1.DropDownItems.Add(it);
            }
        }
        private void ActiveGameGenie(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;
                if (!NesCore.BOARD.IsGameGenieActive && NesCore.BOARD.GameGenieCodes == null)
                {
                    //configure
                    FormGameGenie frm = new FormGameGenie();
                    frm.ShowDialog(this);
                }
                else
                {
                    NesCore.BOARD.IsGameGenieActive = !NesCore.BOARD.IsGameGenieActive;
                }
                NesCore.PAUSED = false;
            }
        }
        private void ConfigureGameGenie(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                NesCore.PAUSED = true;

                //configure
                FormGameGenie frm = new FormGameGenie();
                frm.ShowDialog(this);

                NesCore.PAUSED = false;
            }
        }
        private void gameGenieToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                activeToolStripMenuItem.Checked = NesCore.BOARD.IsGameGenieActive;
            }
            else
            {
                activeToolStripMenuItem.Checked = false;
            }
        }
        private void toolStripSplitButton3_DropDownOpening(object sender, EventArgs e)
        {
            if (NesCore.ON)
            {
                activeToolStripMenuItem1.Checked = NesCore.BOARD.IsGameGenieActive;
            }
            else
            {
                activeToolStripMenuItem1.Checked = false;
            }
        }
    }
}
