//
//  MainWindow.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2009 - 2013 Ala Ibrahim Hadid 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.IO;
using System.Threading;
using System.Diagnostics;
using Gtk;
using MyNesGTK;
using MyNes.Core;
using MyNes.Renderers;
using SdlDotNet;
using SdlDotNet.Graphics;

public partial class MainWindow: Gtk.Window
{	
    public MainWindow(): base (Gtk.WindowType.Toplevel)
    {
        Build();
        // load settings
        this.Move(MainClass.Settings.win_x, MainClass.Settings.win_y);
        this.Resize(MainClass.Settings.win_width, MainClass.Settings.win_height);
        MyNes.Core.Console.LineWritten += (sender, e) => WriteLine(e.Text, e.Code);
    }

    private Thread gameThread;

    public void WriteLine(string line, DebugCode status = DebugCode.None)
    {
        switch (status)
        {
            case DebugCode.Error:
                System.Console.ForegroundColor = ConsoleColor.Red;
                break;
            case DebugCode.Good:
                System.Console.ForegroundColor = ConsoleColor.Green;
                break;
            case DebugCode.None:
                System.Console.ForegroundColor = ConsoleColor.White;
                break;
            case DebugCode.Warning:
                System.Console.ForegroundColor = ConsoleColor.Yellow;
                break;
        }
        System.Console.WriteLine(line);
    }

    protected void OnDeleteEvent(object sender, DeleteEventArgs a)
    {
        // kill nes if alive
        if (RenderersCore.AvailableRenderers[MainClass.Settings.CurrentRendererIndex].IsAlive)
        {
            RenderersCore.AvailableRenderers[MainClass.Settings.CurrentRendererIndex].Kill();
        }
        /*if (gameThread!=null)
		{
			if (gameThread.IsAlive)
			{
				gameThread.Abort();
			}
		}*/
        // save settings
        int x = 0;
        int y = 0;
        int w = 0;
        int h = 0;
        this.GetPosition(out x, out y);
        this.GetSize(out w, out h);
        MainClass.Settings.win_x = x;
        MainClass.Settings.win_y = y;
        MainClass.Settings.win_width = w;
        MainClass.Settings.win_height = h;
        MainClass.SaveSettings();
        // quit
        Application.Quit();
        a.RetVal = true;
    }

    public void LoadRom(string romPath)
    {
        if (Nes.ON)
        {
            Nes.Shutdown();
            RenderersCore.AvailableRenderers[MainClass.Settings.CurrentRendererIndex].Kill();
        }
        if (gameThread != null)
        {
            if (gameThread.IsAlive)
            {
                gameThread.Abort();
            }
        }
        // create new nes
        try
        {
            Nes.CreateNew(romPath, MainClass.Settings.EmulationSystem);
        }
        catch
        {
        }
        Nes.TurnOn();
        Nes.Pause = true;
        RenderersCore.AvailableRenderers[MainClass.Settings.CurrentRendererIndex].Start();
        gameThread = new Thread(new ThreadStart(Nes.Run));
        gameThread.Start();
    }

    protected void OnRenderersActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.TogglePause(true);
        Dialog_RendererSelect dialog = new Dialog_RendererSelect();
        dialog.Modal = true;
        if (dialog.Run() == (int)ResponseType.Ok)
        {
            dialog.SaveSettings();
        }
        dialog.Destroy();
        if (Nes.ON)
            Nes.TogglePause(false);
    }

    protected void OnVideoAction1Activated(object sender, EventArgs e)
    {	
        try
        {
            if (Nes.ON)
                Nes.TogglePause(true);
            Dialog_VideoSettings dialog = new Dialog_VideoSettings();
            dialog.Modal = true;
            if (dialog.Run() == (int)ResponseType.Ok)
            {
                dialog.SaveSettings();
            }
            dialog.Destroy();
            if (Nes.ON)
                Nes.TogglePause(false);
        }
        catch (Exception ex)
        {
            Trace.WriteLine("ERROR: " + ex.Message);
            Trace.WriteLine(ex.ToString());
            Trace.Flush();
        }
    }

    protected void OnSoundActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.TogglePause(true);
        Dialog_SoundSettings dialog = new Dialog_SoundSettings();
        dialog.Modal = true;
        if (dialog.Run() == (int)ResponseType.Ok)
        {
            dialog.SaveSettings();
        }
        dialog.Destroy();
        if (Nes.ON)
            Nes.TogglePause(false);
    }

    protected void OnPathsActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.TogglePause(true);
        Dialog_PathsSettings dialog = new Dialog_PathsSettings();
        dialog.Modal = true;
        if (dialog.Run() == (int)ResponseType.Ok)
        {
            dialog.SaveSettings();
        }
        dialog.Destroy();
        if (Nes.ON)
            Nes.TogglePause(false);
    }

    protected void OnConfigureActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.TogglePause(true);
        Dialog_Input dialog = new Dialog_Input();
        dialog.Modal = true;
        dialog.Run();

        dialog.SaveSettings();

        dialog.Destroy();
        if (Nes.ON)
            Nes.TogglePause(false);
    }
    // open
    protected void OnOpenActionActivated(object sender, EventArgs e)
    {
        FileChooserDialog openD = new FileChooserDialog("Open file",
                                                        this, FileChooserAction.Open,
                                                        Stock.Cancel, ResponseType.Cancel,
                                                        Stock.Open, ResponseType.Accept);
        FileFilter filter = new FileFilter();
        filter.Name = "INES rom (*.nes)";
        filter.AddMimeType("Ines");
        filter.AddPattern("*.nes");
        openD.AddFilter(filter);
        if (MainClass.Settings.CurrentFilePath != null)
            openD.SetFilename(MainClass.Settings.CurrentFilePath);
        if (openD.Run() == (int)ResponseType.Accept)
        {
            MainClass.Settings.CurrentFilePath = openD.Filename;
            LoadRom(openD.Filename);
        }
        openD.Destroy();
    }
    // quit
    protected void OnQuitActionActivated(object sender, EventArgs e)
    {
        MyNesGTK.MainClass.SaveSettings();
        Application.Quit();
    }
    // help
    protected void OnHelpActionActivated(object sender, EventArgs e)
    {
        if (File.Exists(System.IO.Path.GetFullPath("Help.htm")))
            System.Diagnostics.Process.Start(System.IO.Path.GetFullPath("Help.htm"));
    }

    protected void OnPaletteActionActivated(object sender, EventArgs e)
    {
        Dialog_Palette dialog = new Dialog_Palette();
        dialog.Modal = true;
        if (dialog.Run() == (int)ResponseType.Ok)
        {
            dialog.SaveSettings();
        }
        else
        {
            dialog.CancelSettings();
        }
        dialog.Destroy();
    }

    protected void OnEmulationSystemActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.TogglePause(true);
        Dialog_EmulationSystem dialog = new Dialog_EmulationSystem();
        dialog.Modal = true;
        if (dialog.Run() == (int)ResponseType.Ok)
        {
            dialog.SaveSettings();
        }
        dialog.Destroy();
        if (Nes.ON)
            Nes.TogglePause(false);
    }

    protected void OnTogglePauseActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.Pause = !Nes.Pause;
    }

    protected void OnTurnOffAction1Activated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.Shutdown();
    }

    protected void OnHardResetAction1Activated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.HardReset();
    }

    protected void OnSoftResetAction1Activated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.SoftReset();
    }

    protected void On0ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 0;
    }

    protected void On1ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 1;
    }

    protected void On2ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 2;
    }

    protected void On3ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 3;
    }

    protected void On4ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 4;
    }

    protected void On5ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 5;
    }

    protected void On6ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 6;
    }

    protected void On7ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 7;
    }

    protected void On8ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 8;
    }

    protected void On9ActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.StateSlot = 9;
    }
    // save state
    protected void OnSaveActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON && Directory.Exists(RenderersCore.SettingsManager.Settings.Folders_StateFolder))
            Nes.SaveState(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
    }

    protected void OnSaveAsActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
        {
            FileChooserDialog sav = new FileChooserDialog("Save state as",
                                                          this, FileChooserAction.Save,
                                                          Stock.Cancel, ResponseType.Cancel,
                                                          Stock.Save, ResponseType.Accept);
            FileFilter filter = new FileFilter();
            filter.Name = "My Nes State (*.mns)";
            filter.AddMimeType("mns");
            filter.AddPattern("*.mns");
            sav.AddFilter(filter);
            if (sav.Run() == (int)ResponseType.Accept)
            {
                Nes.SaveStateAs(sav.Filename);
            }
            sav.Destroy();
        }
    }
    // load state
    protected void OnLoadActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON && Directory.Exists(RenderersCore.SettingsManager.Settings.Folders_StateFolder))
            Nes.LoadState(RenderersCore.SettingsManager.Settings.Folders_StateFolder);
    }

    protected void OnLoadAsActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
        {
            FileChooserDialog openD = new FileChooserDialog("Load state as",
                                                            this, FileChooserAction.Open,
                                                            Stock.Cancel, ResponseType.Cancel,
                                                            Stock.Open, ResponseType.Accept);
            FileFilter filter = new FileFilter();
            filter.Name = "My Nes State (*.mns)";
            filter.AddMimeType("mns");
            filter.AddPattern("*.mns");
            openD.AddFilter(filter);
            if (openD.Run() == (int)ResponseType.Accept)
            {
                Nes.LoadStateAs(openD.Filename);
            }
            openD.Destroy();
        }
    }

    protected void OnActiveActionActivated(object sender, EventArgs e)
    {
        if (Nes.ON)
        {
            Nes.TogglePause(true);
            if (!Nes.Board.IsGameGenieActive && Nes.Board.GameGenieCodes == null)
            {
                //configure
                Dialog_GameGenieConfigure dialog = new Dialog_GameGenieConfigure();
                dialog.Modal = true;
                if (dialog.Run() == (int)ResponseType.Ok)
                {
                    dialog.SaveSettings();
                }
                dialog.Destroy();
                ActiveAction.Active = Nes.Board.IsGameGenieActive;
            }
            else
            {
                Nes.Board.IsGameGenieActive = !Nes.Board.IsGameGenieActive;
                ActiveAction.Active = Nes.Board.IsGameGenieActive;
            }
            Nes.TogglePause(false);
        }
        else
        {
            ActiveAction.Active = false; 
        }
    }

    protected void OnConfigureAction1Activated(object sender, EventArgs e)
    {
        if (Nes.ON)
            Nes.TogglePause(true);
        else
        {
            Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
                                                             Gtk.MessageType.Info,
                                                             Gtk.ButtonsType.Ok, "Nes is off.");

            dialog.Run();
            dialog.Destroy();
            return;
        }
        //try
        {
            Dialog_GameGenieConfigure dialog = new Dialog_GameGenieConfigure();
            dialog.Modal = true;
            if (dialog.Run() == (int)ResponseType.Ok)
            {
                dialog.SaveSettings();
            }
            dialog.Destroy();
        }
        //catch()
        {
        }
        if (Nes.ON)
            Nes.TogglePause(false);
    }

    protected void OnAboutMyNesGTKActionActivated(object sender, EventArgs e)
    {
        Dialog_About dialog = new Dialog_About();
        dialog.Modal = true;
        dialog.Run();
        dialog.Destroy();
    }

    protected void OnRecordSoundAction1Activated(object sender, EventArgs e)
    {
        if (Nes.ON)
        {
            Nes.TogglePause(true);
            if (Nes.AudioDevice.IsRecording)
            {
                Nes.AudioDevice.RecordStop();
                RecordSoundAction1.Label = "Record sound";
            }
            else
            {
                FileChooserDialog openD = new FileChooserDialog("Save sound file",
                                                                this, FileChooserAction.Save,
                                                                Stock.Cancel, ResponseType.Cancel,
                                                                Stock.Save, ResponseType.Accept);
                FileFilter filter = new FileFilter();
                filter.Name = "Wav (*.wav)";
                filter.AddMimeType("wav");
                filter.AddPattern("*.wav");
                openD.AddFilter(filter);
                openD.SetFilename("recorded.wav");
                if (openD.Run() == (int)ResponseType.Accept)
                {
                    Nes.AudioDevice.Record(openD.Filename);
                }
                openD.Destroy();
                RecordSoundAction1.Label = "Stop recording sound";
            }
            Nes.TogglePause(false);
        }
    }
}










	



	






	




