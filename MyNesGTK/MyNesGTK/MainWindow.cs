//
//  MainWindow.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2015 Ala Ibrahim Hadid
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
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;
using Gtk;
using MyNes.Core;
using MyNesGTK;

public partial class MainWindow: Gtk.Window
{
	public MainWindow()
		: base(Gtk.WindowType.Toplevel)
	{
		Build();

		FileFilter filter = new FileFilter();
		filter.Name = "INES rom (*.nes)";
		filter.AddMimeType("Ines");
		filter.AddPattern("*.nes");
		filechooserwidget2.AddFilter(filter);

		InitializeColumns();
		LoadSettings();
		MyNesSDL.Settings.LoadSettings(System.IO.Path.Combine(MainClass.WorkingFolder, "SDLSettings.conf"));
		GameGenieFolder = MyNesSDL.Settings.Folder_GameGenieCodes;
		StateFolder = MyNesSDL.Settings.Folder_STATE;
		SnapsFolder = MyNesSDL.Settings.Folder_SNAPS;
	}

	private System.Diagnostics.Process currentProcess;
	private Gtk.TreeStore gameInfoList = new Gtk.TreeStore(typeof(string), typeof(string));
	private List<string> gameInfoLines = new List<string>();
	private string GameGenieFolder;
	private string StateFolder;
	private string SnapsFolder;
	private List<string > GameGenieCodes = new List<string>();
	private List<string> Snapshots = new List<string>();
	private int selectedSnapshot;

	private void InitializeColumns()
	{
		TreeViewColumn propertyColumn = new TreeViewColumn();
		propertyColumn.Title = "Property";
		// Create the text cell that will display the artist name
		Gtk.CellRendererText propertyNameCell = new Gtk.CellRendererText();
		// Add the cell to the column
		propertyColumn.PackStart(propertyNameCell, true);

		// Create a column for the song title
		TreeViewColumn valueColumn = new TreeViewColumn();
		valueColumn.Title = "Value";
		// Do the same for the song title column
		Gtk.CellRendererText valueTitleCell = new Gtk.CellRendererText();
		valueColumn.PackStart(valueTitleCell, true);

		// Tell the Cell Renderers which items in the model to display
		propertyColumn.AddAttribute(propertyNameCell, "text", 0);
		valueColumn.AddAttribute(valueTitleCell, "text", 1);

		// Add the columns to the TreeView
		treeview2.AppendColumn(propertyColumn);
		treeview2.AppendColumn(valueColumn);

		// Assign the model to the TreeView
		treeview2.Model = gameInfoList;
	}

	private void LoadSettings()
	{
		filechooserwidget2.SetFilename(MyNesGTK.Settings.LastUsedFile);

		this.SetSizeRequest(MyNesGTK.Settings.WindowWidth, MyNesGTK.Settings.WindowHeight);

		this.SetPosition(WindowPosition.None);
		this.Move(MyNesGTK.Settings.WindowX, MyNesGTK.Settings.WindowY);
		this.hpaned1hpaned1.Position = MyNesGTK.Settings.PanePosition;
		this.vpaned1.Position = MyNesGTK.Settings.VPanePosition;
	}

	private void SaveSettings()
	{
		this.GetSize(out MyNesGTK.Settings.WindowWidth, out MyNesGTK.Settings.WindowHeight);
		this.GetPosition(out MyNesGTK.Settings.WindowX, out MyNesGTK.Settings.WindowY);
		MyNesGTK.Settings.PanePosition = this.hpaned1hpaned1.Position;
		MyNesGTK.Settings.VPanePosition = this.vpaned1.Position;
	}

	public void PlaySelectedGame()
	{
		if (filechooserwidget2.Filename == null)
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, "Please select a file from the list first.");

			dialog.Run();
			dialog.Destroy();
			return;
		}
		if (!File.Exists(filechooserwidget2.Filename))
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, "Please select a file from the list first.");

			dialog.Run();
			dialog.Destroy();
			return;
		}
		MyNesGTK.Settings.LastUsedFile = filechooserwidget2.Filename;
		LoadRom(filechooserwidget2.Filename);
	}

	public void ExitCurrentGame()
	{
		try
		{
			if (currentProcess != null)
			{
				currentProcess.CloseMainWindow();
				currentProcess.WaitForExit();
				currentProcess = null;
			}
		}
		catch
		{
		}
	}

	public void LoadRom(string filePath)
	{
		try
		{
			if (currentProcess != null)
			{
				if (!currentProcess.HasExited)
				{
					currentProcess.CloseMainWindow();
					currentProcess.WaitForExit();
				}
				currentProcess = null;
			}
			// Start the process
			#region commands
			string commands = "";
			// Game Genie
			if (checkbutton_enable_gg.Active)
			{
				commands += "gamegenie_enable" + " ";
			}
			// State
			if (checkbutton_loadstate.Active)
			{
				commands += "state_slot_" + combobox_state.Active + " state_load ";
			}
			#endregion
			if (commands.Length > 0)
				commands = commands.Substring(0, commands.Length - 1);
			if (filePath.Contains(":"))// Windows
			{
				currentProcess = Process.Start(System.IO.Path.Combine(MainClass.ApplicationFolder, "MyNesSDL.exe"),
					(commands.Length > 0) ? ("\"" + filePath + "\"" + " " + commands) : ("\"" + filePath + "\""));
			}
			else// TODO: Linux and others !? works in Linux anyway ...
			{
				currentProcess = Process.Start("mono",
					"\"" + System.IO.Path.Combine(MainClass.ApplicationFolder, "MyNesSDL.exe") + "\"" +" "+
					((commands.Length > 0) ? ("\"" + filePath + "\"" + " " + commands) : ("\"" + filePath + "\"")));
			}
		}
		catch (Exception ex)
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, ex.Message);

			dialog.Run();
			dialog.Destroy();
		}
	}

	private string GetFileSize(string FilePath)
	{
		if (File.Exists(System.IO.Path.GetFullPath(FilePath)) == true)
		{
			FileInfo Info = new FileInfo(FilePath);
			string Unit = " " + "Byte";
			double Len = Info.Length;
			if (Info.Length >= 1024)
			{
				Len = Info.Length / 1024.00;
				Unit = " KB";
			}
			if (Len >= 1024)
			{
				Len /= 1024.00;
				Unit = " MB";
			}
			if (Len >= 1024)
			{
				Len /= 1024.00;
				Unit = " GB";
			}
			return Len.ToString("F2") + Unit;
		}
		return "";
	}

	private string CalculateCRC(string filePath, int bytesToSkip)
	{
		if (File.Exists(filePath))
		{
			Stream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
			fileStream.Read(new byte[bytesToSkip], 0, bytesToSkip);
			byte[] fileBuffer = new byte[fileStream.Length - bytesToSkip];
			fileStream.Read(fileBuffer, 0, (int)(fileStream.Length - bytesToSkip));
			fileStream.Close();

			string crc = "";
			Crc32 crc32 = new Crc32();
			byte[] crc32Buffer = crc32.ComputeHash(fileBuffer);

			foreach (byte b in crc32Buffer)
				crc += b.ToString("x2").ToLower();

			return crc;
		}
		return "";
	}

	private string GetSize(long size)
	{
		string Unit = " Byte";
		double Len = size;
		if (size >= 1024)
		{
			Len = size / 1024.00;
			Unit = " KB";
		}
		if (Len >= 1024)
		{
			Len /= 1024.00;
			Unit = " MB";
		}
		if (Len >= 1024)
		{
			Len /= 1024.00;
			Unit = " GB";
		}
		if (Len < 0)
			return "???";
		return Len.ToString("F2") + Unit;
	}

	private void RefreshFileInfo()
	{
		if (gameInfoList == null)
			return;
		try
		{
			gameInfoLines = new List<string>();
			gameInfoList.Clear();
			if (System.IO.Path.GetExtension(filechooserwidget2.Filename).ToLower() == ".nes")
			{
				Gtk.TreeIter iter;
				INes header = new INes();
				header.Load(filechooserwidget2.Filename, false);
				if (header.IsValid)
				{
					#region Database

					// Add database info if found !
					//Get database info
					bool found = false;
					NesCartDatabaseGameInfo info = NesCartDatabase.Find(header.SHA1, out found);
					NesCartDatabaseCartridgeInfo cart = new NesCartDatabaseCartridgeInfo();
					if (info.Cartridges != null)
					{
						foreach (NesCartDatabaseCartridgeInfo cartinf in info.Cartridges)
							if (cartinf.SHA1.ToLower() == header.SHA1.ToLower())
							{
								cart = cartinf;
								break;
							}
					}
					if (found)
					{
						iter = gameInfoList.AppendValues("Info From Database");
						gameInfoLines.Add("[Info From Database]");
						FieldInfo[] Fields = typeof(NesCartDatabaseGameInfo).GetFields(BindingFlags.Public
							                     | BindingFlags.Instance);
						for (int i = 0; i < Fields.Length; i++)
						{
							if (Fields[i].FieldType == typeof(System.String))
							{
								try
								{
									gameInfoList.AppendValues(iter, Fields[i].Name.Replace("_", " "), Fields[i].GetValue
                                        (info).ToString());
									gameInfoLines.Add(Fields[i].Name.Replace("_", " ") + " : " + Fields[i].GetValue
                                        (info).ToString());
								}
								catch
								{
								}
							}
						}

						//chips
						if (cart.chip_type != null)
						{
							for (int i = 0; i < cart.chip_type.Count; i++)
							{
								gameInfoList.AppendValues(iter, "Chip " + (i + 1), cart.chip_type[i]);
								gameInfoLines.Add("Chip " + (i + 1) + " : " + cart.chip_type[i]);
							}
						}

						//Cartridge
						Fields = typeof(NesCartDatabaseCartridgeInfo).GetFields(BindingFlags.Public
							| BindingFlags.Instance);  
						for (int i = 0; i < Fields.Length; i++)
						{
							if (Fields[i].FieldType == typeof(System.String))
							{
								try
								{
									gameInfoList.AppendValues(iter, Fields[i].Name.Replace("_", " "), Fields[i].GetValue
                                        (cart).ToString());
									gameInfoLines.Add(Fields[i].Name.Replace("_", " ") + " : " + Fields[i].GetValue
                                        (cart).ToString());
								}
								catch
								{
								}
							}
						}

						//DataBase
						Fields = typeof(NesCartDatabase).GetFields(BindingFlags.Public
							| BindingFlags.Static);
						for (int i = 0; i < Fields.Length; i++)
						{
							if (Fields[i].FieldType == typeof(System.String))
							{
								try
								{
									gameInfoList.AppendValues(iter, Fields[i].Name.Replace("_", " "), Fields[i].GetValue
                                        (info).ToString());
									gameInfoLines.Add(Fields[i].Name.Replace("_", " ") + " : " + Fields[i].GetValue
                                        (info).ToString());
								}
								catch
								{
								}
							}
						}
					}
					#endregion

					iter = gameInfoList.AppendValues("File Info");
					gameInfoLines.Add("[File Info]");
					string crc = "";
					gameInfoList.AppendValues(iter, "CRC32", crc = CalculateCRC(filechooserwidget2.Filename, 16).ToString());
					gameInfoLines.Add("CRC32 : " + crc);
					gameInfoLines.Add("");
					iter = gameInfoList.AppendValues("INES Header");
					gameInfoLines.Add("[INES Header]");
					gameInfoList.AppendValues(iter, "SHA1", header.SHA1);
					gameInfoLines.Add("SHA1 : " + header.SHA1);
					gameInfoList.AppendValues(iter, "Mapper #", header.MapperNumber.ToString());
					gameInfoLines.Add("Mapper # : " + header.MapperNumber.ToString());
					gameInfoList.AppendValues(iter, "Mirroring", header.Mirroring.ToString());
					gameInfoLines.Add("Mirroring : " + header.Mirroring.ToString());
					gameInfoList.AppendValues(iter, "Has Battery", header.HasBattery.ToString());
					gameInfoLines.Add("Has Battery : " + header.HasBattery.ToString());
					gameInfoList.AppendValues(iter, "Has Trainer", header.HasTrainer.ToString());
					gameInfoLines.Add("Has Trainer : " + header.HasTrainer.ToString());
					gameInfoList.AppendValues(iter, "Is Playchoice10", header.IsPlaychoice10.ToString());
					gameInfoLines.Add("Is Playchoice10 : " + header.IsPlaychoice10.ToString());
					gameInfoList.AppendValues(iter, "Is VS Unisystem", header.IsVSUnisystem.ToString());
					gameInfoLines.Add("Is VS Unisystem : " + header.IsVSUnisystem.ToString());
					gameInfoList.AppendValues(iter, "PRG Count", header.PRGCount.ToString());
					gameInfoLines.Add("PRG Count : " + header.PRGCount.ToString());
					gameInfoList.AppendValues(iter, "PRG Size", GetSize(header.PRGCount * 0x4000));
					gameInfoLines.Add("PRG Size : " + GetSize(header.PRGCount * 0x4000));
					gameInfoList.AppendValues(iter, "CHR Count", header.CHRCount.ToString());
					gameInfoLines.Add("CHR Count : " + header.CHRCount.ToString());
					gameInfoList.AppendValues(iter, "CHR Size", GetSize(header.CHRCount * 0x2000));
					gameInfoLines.Add("CHR Size : " + GetSize(header.CHRCount * 0x2000));
					gameInfoLines.Add("");

				}
				else
				{
					iter = gameInfoList.AppendValues("File Info");
					gameInfoLines.Add("[File Info]");
					string crc = "";
					gameInfoList.AppendValues(iter, "CRC32", crc = CalculateCRC(filechooserwidget2.Filename, 0).ToString());
					gameInfoLines.Add("CRC32 : " + crc);
					gameInfoLines.Add("");
				}
			}
			else
			{
				Gtk.TreeIter iter = gameInfoList.AppendValues("File Info");
				gameInfoLines.Add("[File Info]");
				string crc = "";
				gameInfoList.AppendValues(iter, "CRC32", crc = CalculateCRC(filechooserwidget2.Filename, 0).ToString());
				gameInfoLines.Add("CRC32 : " + crc);
				gameInfoLines.Add("");
			}
			treeview2.ExpandAll();
		}
		catch
		{
		}
	}

	private void RefreshState()
	{
		checkbutton_loadstate.Active = false;
		// TODO: make a nice looking slot combobox (view available state file for selected game)
		ListStore ClearList = new ListStore(typeof(string), typeof(string));
		combobox_state.Model = ClearList;
 
		if (StateFolder != null)
		{
			for (int i = 0; i < 10; i++)
			{

				string filePath = System.IO.Path.Combine(StateFolder,
					                  System.IO.Path.GetFileNameWithoutExtension(filechooserwidget2.Filename) + "_" + i + "_.mns");
				if (System.IO.File.Exists(filePath))
				{
					FileInfo inf = new FileInfo(filePath);
					combobox_state.AppendText("Slot " + i + " [" + inf.LastWriteTime.ToUniversalTime().ToString() + "]");
					combobox_state.Active = i;
				}
				else
				{
					combobox_state.AppendText("Slot " + i);
				}
			}
		}
		else
		{
			for (int i = 0; i < 10; i++)
			{
				combobox_state.AppendText("Slot " + i);
			}
		}
		if (combobox_state.Active < 0)
			combobox_state.Active = 0;
	}

	private void RefreshSnaps()
	{
		Snapshots = new List<string>();
		image_snap.Pixbuf = Gdk.Pixbuf.LoadFromResource("MyNesGTK.resources.MyNesImage.png");
		if (filechooserwidget2.Filename == null)
			return;
		if (SnapsFolder != null)
		{
			string[] files = System.IO.Directory.GetFiles(SnapsFolder);
			// Go reverse, this will fix some detection problems.
			for (int i = files.Length - 1; i >= 0; i--)
			{
				if (files[i].Contains(System.IO.Path.GetFileNameWithoutExtension(filechooserwidget2.Filename)))
				{
					Snapshots.Add(files[i]);
				}
			}
		}
		selectedSnapshot = 0;
		if (selectedSnapshot < Snapshots.Count)
		{
			image_snap.File = Snapshots[selectedSnapshot];
		}
	}

	private void ShowNextSnap()
	{
		selectedSnapshot++;
		if (selectedSnapshot >= Snapshots.Count)
			selectedSnapshot = 0;
		if (selectedSnapshot < Snapshots.Count)
		{
			image_snap.File = Snapshots[selectedSnapshot];
		}
		else
			image_snap.Pixbuf = Gdk.Pixbuf.LoadFromResource("MyNesGTK.resources.MyNesImage.png");
	}

	private void ShowPreviousSnap()
	{
		selectedSnapshot--;
		if (selectedSnapshot < 0)
			selectedSnapshot = Snapshots.Count - 1;
		if (selectedSnapshot < Snapshots.Count)
		{
			image_snap.File = Snapshots[selectedSnapshot];
		}
		else
			image_snap.Pixbuf = Gdk.Pixbuf.LoadFromResource("MyNesGTK.resources.MyNesImage.png");
	}

	private void LoadGameGenieCodes()
	{
		GameGenieCodes = new List<string>();
		ListStore ClearList = new ListStore(typeof(string), typeof(string));
		combobox_gg_codes.Model = ClearList;
		if (!Directory.Exists(GameGenieFolder))
		{
			return;
		}
		if (!File.Exists(filechooserwidget2.Filename))
		{
			return;
		}
		string filePath = System.IO.Path.Combine(GameGenieFolder,
			                  System.IO.Path.GetFileNameWithoutExtension(filechooserwidget2.Filename) + ".ggc");
		if (File.Exists(filePath))
		{
			string[] lines = File.ReadAllLines(filePath);
			// Clear all
			if (lines.Length > 0)
			{

				for (int i = 0; i < lines.Length; i++)
				{
					combobox_gg_codes.AppendText(lines[i]);
					GameGenieCodes.Add(lines[i]);
				}
				try
				{
					combobox_gg_codes.Active = 0;
				}
				catch
				{
				}
			}
		}
	}

	private void SaveGameGenieCodes()
	{
		if (!Directory.Exists(GameGenieFolder))
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, "Game Genie folder is not exist !");

			dialog.Run();
			dialog.Destroy();
			return;
		}
		if (!File.Exists(filechooserwidget2.Filename))
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, "No game selected. Please select a game first.");

			dialog.Run();
			dialog.Destroy();
			return;
		}
		if (GameGenieCodes.Count == 0)
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, "There is no Game Genie Code to save !");

			dialog.Run();
			dialog.Destroy();
			return;
		}
		string filePath = System.IO.Path.Combine(GameGenieFolder,
			                  System.IO.Path.GetFileNameWithoutExtension(filechooserwidget2.Filename) + ".ggc");

		File.WriteAllLines(filePath, GameGenieCodes.ToArray());

		Gtk.MessageDialog savedialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
			                               Gtk.MessageType.Info,
			                               Gtk.ButtonsType.Ok, "Game Genie file saved successfully.");

		savedialog.Run();
		savedialog.Destroy();
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		SaveSettings();
		Application.Quit();
		a.RetVal = true;
	}

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

		openD.SetFilename(MyNesGTK.Settings.LastUsedFile);
		if (openD.Run() == (int)ResponseType.Accept)
		{
			MyNesGTK.Settings.LastUsedFile = openD.Filename;
			LoadRom(openD.Filename);
		}
		openD.Destroy();
	}

	protected void OnQuitActionActivated(object sender, EventArgs e)
	{
		Application.Quit();
	}

	protected void OnHelpActionActivated(object sender, EventArgs e)
	{
		try
		{
			string helpPath = System.IO.Path.Combine(MainClass.ApplicationFolder, "Help");
			helpPath = System.IO.Path.Combine(helpPath, "index.htm");
			Process.Start(helpPath);
		}
		catch (Exception ex)
		{
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, ex.Message);

			dialog.Run();
			dialog.Destroy();
		}
	}

	protected void OnAboutMyNesGTKActionActivated(object sender, EventArgs e)
	{
		Dialog_About dialog = new Dialog_About();
		dialog.Modal = true;
		dialog.Run();
		dialog.Destroy();
	}

	protected void OnVideoActionActivated(object sender, EventArgs e)
	{
		Dialog_VideoSettings dialog = new Dialog_VideoSettings();
		dialog.Modal = true;
		if (dialog.Run() == (int)ResponseType.Ok)
		{
			dialog.SaveSettings();
		}
		dialog.Destroy();
	}

	protected void OnAudioActionActivated(object sender, EventArgs e)
	{
		Dialog_Audio dialog = new Dialog_Audio();
		dialog.Modal = true;
		if (dialog.Run() == (int)ResponseType.Ok)
		{
			dialog.SaveSettings();
		}
		dialog.Destroy();
	}

	protected void OnPathsActionActivated(object sender, EventArgs e)
	{
		Dialog_Paths dialog = new Dialog_Paths();
		dialog.Modal = true;
		if (dialog.Run() == (int)ResponseType.Ok)
		{
			dialog.SaveSettings();
		}
		dialog.Destroy();
	}

	protected void OnPreferencesActionActivated(object sender, EventArgs e)
	{
		Dialog_Preferences dialog = new Dialog_Preferences();
		dialog.Modal = true;
		if (dialog.Run() == (int)ResponseType.Ok)
		{
			dialog.SaveSettings();
		}
		dialog.Destroy();
	}

	protected void OnFilechooserwidget2FileActivated(object sender, EventArgs e)
	{
		PlaySelectedGame();
	}

	protected void OnPaletteActionActivated(object sender, EventArgs e)
	{
		Dialog_Palettes dialog = new Dialog_Palettes();
		dialog.Modal = true;
		if (dialog.Run() == (int)ResponseType.Ok)
		{
			dialog.SaveSettings();
		}
		dialog.Destroy();
	}

	protected void OnInputActionActivated(object sender, EventArgs e)
	{
		/*
        Dialog_Input dialog = new Dialog_Input();
        dialog.Modal = true;
        if (dialog.Run() == (int)ResponseType.Ok)
        {
            dialog.SaveSettings();
        }
        dialog.Destroy();*/
		Gtk.MessageDialog dialog = new Gtk.MessageDialog(this,
			                           Gtk.DialogFlags.DestroyWithParent,
			                           Gtk.MessageType.Info,
			                           Gtk.ButtonsType.Ok, 
			                           "Input settings is not implemented in GTK edition." +
			                           "\nTo change input settings, you'll need to use My Nes SDL instead." +
			                           "\nSimply run a game, then in the game window, press TAB." +
			                           "\nThis will bring up the main menu, use Up and Down from your keyboard to select the Settings menu " +
			                           "item then press Enter (return)." +
			                           "\nThen select Input from the settings menu items." +
			                           "\nFor more details, please see the help document.");

		dialog.Run();
		dialog.Destroy();
	}

	protected void OnFilechooserwidget2SelectionChanged(object sender, EventArgs e)
	{
		RefreshFileInfo();
		LoadGameGenieCodes();
		RefreshState();
		RefreshSnaps();
	}

	protected void OnRefreshActionActivated(object sender, EventArgs e)
	{
		RefreshFileInfo();
	}

	protected void OnSaveActionActivated(object sender, EventArgs e)
	{
		if (gameInfoList == null)
		{  
			Gtk.MessageDialog dialog = new Gtk.MessageDialog(this,
				                           Gtk.DialogFlags.DestroyWithParent,
				                           Gtk.MessageType.Error,
				                           Gtk.ButtonsType.Ok, 
				                           "No info entry to save !!");

			dialog.Run();
			dialog.Destroy();
			return;
		}
            
		FileChooserDialog openD = new FileChooserDialog("Save text file",
			                          this, FileChooserAction.Save,
			                          Stock.Cancel, ResponseType.Cancel,
			                          Stock.Save, ResponseType.Accept);
		FileFilter filter = new FileFilter();
		filter.Name = "Text file (*.txt)";
		filter.AddMimeType("Text");
		filter.AddPattern("*.txt");
		openD.AddFilter(filter);
		openD.SetFilename(filechooserwidget2.Filename.Replace(".nes", ".txt"));
		if (openD.Run() == (int)ResponseType.Accept)
		{
			File.WriteAllLines(openD.Filename, gameInfoLines.ToArray(), System.Text.Encoding.UTF8);
			try
			{
				Process.Start(openD.Filename);
			}
			catch
			{
			}
		}
		openD.Destroy();
	}

	protected void OnCopyActionActivated(object sender, EventArgs e)
	{

	}
	// Load game genie file
	protected void OnButton3Pressed(object sender, EventArgs e)
	{
		LoadGameGenieCodes();
	}
	// Save game genie file
	protected void OnButton4Pressed(object sender, EventArgs e)
	{
		SaveGameGenieCodes();
	}
	// Add game genie code
	protected void OnButton1Pressed(object sender, EventArgs e)
	{
		Dialog_AddGameGenieCode dialog = new Dialog_AddGameGenieCode();
		dialog.Modal = true;
		if (dialog.Run() == (int)ResponseType.Ok)
		{
			if (!GameGenieCodes.Contains(dialog.CodeEntered))
			{
				combobox_gg_codes.AppendText(dialog.CodeEntered);
				GameGenieCodes.Add(dialog.CodeEntered);

				combobox_gg_codes.Active = GameGenieCodes.Count - 1;
			}
		}
		dialog.Destroy();
	}
	// Remove game genie code
	protected void OnButton2Pressed(object sender, EventArgs e)
	{
		if (combobox_gg_codes.Active >= 0)
		{
			GameGenieCodes.RemoveAt(combobox_gg_codes.Active);
			combobox_gg_codes.RemoveText(combobox_gg_codes.Active);
			try
			{
				combobox_gg_codes.Active = 0;
			}
			catch
			{
			}
		}
	}

	protected void OnComboboxStateChanged(object sender, EventArgs e)
	{
		image_state.Pixbuf = null;
		if (StateFolder != null)
		{
			string filePath = System.IO.Path.Combine(StateFolder,
				                  System.IO.Path.GetFileNameWithoutExtension(filechooserwidget2.Filename) +
				                  "_" + combobox_state.Active + "_.jpg");
			if (System.IO.File.Exists(filePath))
			{
				image_state.File = filePath;
			}
			else
				image_snap.Pixbuf = Gdk.Pixbuf.LoadFromResource("MyNesGTK.resources.MyNesImage.png");
		}
	}

	protected void OnGoBackActionActivated(object sender, EventArgs e)
	{
		ShowPreviousSnap();
	}

	protected void OnGoForwardActionActivated(object sender, EventArgs e)
	{
		ShowNextSnap();
	}

	protected void OnOpenAction2Activated(object sender, EventArgs e)
	{
		if (selectedSnapshot < Snapshots.Count)
		{
			try
			{
				System.Diagnostics.Process.Start("explorer.exe", @"/select, " + Snapshots[selectedSnapshot]);
			}
			catch
			{
			}
		}
	}

	protected void PlaySelected(object sender, EventArgs e)
	{
		PlaySelectedGame();
	}

	protected void StopSelected(object sender, EventArgs e)
	{
		ExitCurrentGame();
	}

	protected void OnDeleteActionActivated(object sender, EventArgs e)
	{
		if (selectedSnapshot < Snapshots.Count)
		{
			if (File.Exists(Snapshots[selectedSnapshot]))
			{
				try
				{
					Gtk.MessageDialog qdialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
						                            Gtk.MessageType.Question,
						                            Gtk.ButtonsType.YesNo, "Are you sure you want to delete selected snapshot file ? \nThis can't be UNDONE !");

					if (qdialog.Run() == (int)ResponseType.Yes)
					{
						File.Delete(Snapshots[selectedSnapshot]);
						Snapshots.RemoveAt(selectedSnapshot);

						ShowNextSnap();
					}
					qdialog.Destroy();
				}
				catch (Exception x)
				{
					Gtk.MessageDialog dialog = new Gtk.MessageDialog(this, Gtk.DialogFlags.DestroyWithParent,
						                           Gtk.MessageType.Error,
						                           Gtk.ButtonsType.Ok, "Unable to delete the file:\n" + x);

					dialog.Run();
					dialog.Destroy();
				}
			}
		}
	}
}


    

