/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
using System.Threading;
using System.IO;
using System.Diagnostics;
using MMB;
using SevenZip;
using TheGamesDBAPI;
using System.Net;

namespace MyNes
{
    public partial class FormDetectAndDownloadFromTheGamesDB : Form
    {
        public FormDetectAndDownloadFromTheGamesDB()
        {
            InitializeComponent();

            // Fill up platforms
            ICollection<PlatformSearchResult> results = GamesDB.GetPlatforms();
            foreach (PlatformSearchResult res in results)
            {
                comboBox_platforms.Items.Add(res);
                if (res.Name == "Nintendo Entertainment System (NES)")
                    comboBox_platforms.SelectedIndex = comboBox_platforms.Items.Count - 1;
            }
            if (comboBox_platforms.Items.Count > 0 && comboBox_platforms.SelectedIndex < 0)
                comboBox_platforms.SelectedIndex = 0;
        }
        private TextWriterTraceListener listner;
        private WebClient client = new WebClient();
        private string logPath;
        private bool _turbo_speed;
        private bool useRomNameInsteadRomFileName;
        private bool matchCase;
        private bool matchWord;
        private bool useNameWhenPathNotValid;
        private bool searchmode_FileInRom;
        private bool searchmode_RomInFile;
        private bool searchmode_Both;
        private bool startWith;
        private bool contains;
        private bool endWith;
        private bool _clear_info_table;
        private bool _clear_snaps_table;
        private bool _clear_covers_table;
        // Status
        private string status_master;
        private string status_sub;
        private string status_sub_sub;
        private int progress_master;
        private int progress_sub;
        // Thread
        private Thread mainThread;
        private bool finished;
        // DB options
        private int _db_selected_platform_id;
        private bool _db_rename_rom_using_title;

        private bool _db_add_overview_as_tab;
        private bool _db_add_banners_as_tab;
        private bool _db_add_boxart_front_as_tab;
        private bool _db_add_boxart_back_as_tab;
        private bool _db_add_fanart_as_tab;
        private bool _db_add_screenshots_as_tab;

        private string _db_overview_folder;
        private string _db_banners_folder;
        private string _db_boxart_front_folder;
        private string _db_boxart_back_folder;
        private string _db_fanart_folder;
        private string _db_screenshots_folder;

        private bool _db_banners_is_cover;
        private bool _db_boxart_front_is_cover;
        private bool _db_boxart_back_is_cover;
        private bool _db_fanart_is_cover;
        private bool _db_screenshots_is_cover;

        private bool _db_fanart_ic_limitdownload;
        private bool _db_screenshots_ic_limitdownload;
        private bool _db_banners_ic_limitdownload;

        private void PROCESS()
        {
            // Add listener
            string logFileName = string.Format("{0}-detect and download from the-game-db.txt",
                DateTime.Now.ToLocalTime().ToString());
            logFileName = logFileName.Replace(":", "");
            logFileName = logFileName.Replace("/", "-");
            Directory.CreateDirectory("Logs");
            logPath = Path.Combine("Logs", logFileName);
            listner = new TextWriterTraceListener(HelperTools.GetFullPath(logPath));
            Trace.Listeners.Add(listner);
            // Start
            Trace.WriteLine(string.Format("Detect and download from the-game-db.for started at {0}",
                DateTime.Now.ToLocalTime()), "Detect And Download From TheGamesDB.net");
            int step_index = 0;
            int steps_count = 4;
            #region 1 Getting all platform entries from the internet
            Trace.WriteLine("Getting entries for selected platform ...", "Detect And Download From TheGamesDB.net");
            status_master = "Getting entries for selected platform ...";
            progress_master = 100 / (steps_count - step_index);
            // Get database content
            Platform selectedPlatform = GamesDB.GetPlatform(_db_selected_platform_id);
            List<GameSearchResult> databaseEntries = new List<GameSearchResult>(GamesDB.GetPlatformGames(_db_selected_platform_id));
            Trace.WriteLine("Platform entries done, total of " + databaseEntries.Count + " entries found.", "Detect And Download From TheGamesDB.net");
            #endregion
            #region 2 Get the games
            step_index++;
            Trace.WriteLine("Collecting the roms ...", "Detect And Download From TheGamesDB.net");
            status_master = "Collecting the roms ...";
            progress_master = 100 / (steps_count - step_index);
            DataSet set = MyNesDB.GetDataSet("GAMES");
            Trace.WriteLine("Roms collected, total of " + set.Tables[0].Rows.Count + " entries", "Detect And Download From TheGamesDB.net");

            // Clear detected files first ?
            if (_clear_info_table)
                MyNesDB.DeleteDetects("INFOS");
            if (_clear_snaps_table)
                MyNesDB.DeleteDetects("SNAPS");
            if (_clear_covers_table)
                MyNesDB.DeleteDetects("COVERS");

            #endregion
            #region 3 Compare and apply stuff
            step_index++;
            Trace.WriteLine("Comparing and applying naming", "Detect And Download From TheGamesDB.net");
            status_master = "Comparing ...";
            progress_master = 100 / (steps_count - step_index);

            int gameEntriesCount = set.Tables[0].Rows.Count;
            int matchedCount = 0;
            List<string> matchedRomNames = new List<string>();
            List<string> notMatchedRomNames = new List<string>();
            for (int game_index = 0; game_index < gameEntriesCount; game_index++)
            {
                string id = set.Tables[0].Rows[game_index]["Id"].ToString();
                string entryName = set.Tables[0].Rows[game_index]["Name"].ToString().Replace("&apos;", "'");
                string entryPath = set.Tables[0].Rows[game_index]["Path"].ToString().Replace("&apos;", "'");

                status_sub_sub = "";

                // Loop through database entries looking for a match
                for (int entry_index = 0; entry_index < databaseEntries.Count; entry_index++)
                {
                    if (FilterSearch(entryName, entryPath, databaseEntries[entry_index].Title))
                    {
                        Trace.WriteLine("GAME MATCHED [" + id + "] (" + entryName + ")", "Detect And Download From TheGamesDB.net");
                        matchedRomNames.Add(entryName);

                        //  Apply
                        ApplyRom(entryName, id, GamesDB.GetGame(databaseEntries[entry_index].ID));
                        Trace.WriteLine("ROM DATA UPDATED.", "Detect And Download From TheGamesDB.net");

                        matchedCount++;

                        if (_turbo_speed)
                            databaseEntries.RemoveAt(entry_index);
                        break;
                    }
                }

                // Progress
                progress_sub = (game_index * 100) / gameEntriesCount;
                status_sub = string.Format("{0} {1} / {2} ({3} MATCHED) ... {4} %",
                   Program.ResourceManager.GetString("Status_ApplyingDatabase"), (game_index + 1).ToString(), gameEntriesCount,
                    matchedCount.ToString(), progress_sub);
            }
            #endregion
            #region 4 Update log with matched and not found roms
            step_index++;
            Trace.WriteLine("Finishing", "Detect And Download From TheGamesDB.net");
            status_master = "Finishing ...";
            progress_master = 100 / (steps_count - step_index);

            Trace.WriteLine("----------------------------");
            Trace.WriteLine("MATCHED ROMS ( total of " + matchedRomNames.Count + " rom(s) )");
            Trace.WriteLine("------------");
            for (int i = 0; i < matchedRomNames.Count; i++)
                Trace.WriteLine((i + 1).ToString("D8") + "." + matchedRomNames[i]);

            Trace.WriteLine("----------------------------");
            Trace.WriteLine("ROMS NOT FOUND ( total of " + notMatchedRomNames.Count + " rom(s) )");
            Trace.WriteLine("--------------");
            for (int i = 0; i < notMatchedRomNames.Count; i++)
                Trace.WriteLine((i + 1).ToString("D8") + "." + notMatchedRomNames[i]);

            Trace.WriteLine("----------------------------");

            Trace.WriteLine(string.Format("Detect And Download From TheGamesDB.net finished at {0}.", DateTime.Now.ToLocalTime()), "Detect And Download From TheGamesDB.net");
            listner.Flush();
            Trace.Listeners.Remove(listner);
            CloseAfterFinish();
            #endregion
        }
        private bool FilterSearch(string entryName, string entryPath, string tgdbTitle)
        {
            // Let's see what's the mode
            string searchWord_ROM = "";
            string searchTargetText_FILE = "";
            bool isUsingName = false;

            if (entryPath == "N/A")
                if (useNameWhenPathNotValid)
                    isUsingName = true;
                else
                    entryPath = "";

            if (!useRomNameInsteadRomFileName)
            {
                if (!isUsingName)
                    searchWord_ROM = matchCase ? Path.GetFileNameWithoutExtension(entryPath) : Path.GetFileNameWithoutExtension(entryPath).ToLower();
                else
                    searchWord_ROM = matchCase ? entryName : entryName.ToLower();
                searchTargetText_FILE = matchCase ? tgdbTitle : tgdbTitle.ToLower();
            }
            else
            {
                searchWord_ROM = matchCase ? entryName : entryName.ToLower();
                searchTargetText_FILE = matchCase ? tgdbTitle : tgdbTitle.ToLower();
            }
            if (!matchWord)// Contain or IS
            {
                if (searchWord_ROM.Length == searchTargetText_FILE.Length)
                {
                    if (searchTargetText_FILE == searchWord_ROM)
                        return true;
                }
                // Contains
                else
                {
                    if (searchmode_Both)
                    {
                        if (searchWord_ROM.Length > searchTargetText_FILE.Length)
                        {
                            if (contains)
                            {
                                if (searchWord_ROM.Contains(searchTargetText_FILE))
                                    return true;
                            }
                            else if (startWith)
                            {
                                if (searchWord_ROM.StartsWith(searchTargetText_FILE))
                                    return true;
                            }
                            else if (endWith)
                            {
                                if (searchWord_ROM.EndsWith(searchTargetText_FILE))
                                    return true;
                            }
                        }
                        else
                        {
                            if (contains)
                            {
                                if (searchTargetText_FILE.Contains(searchWord_ROM))
                                    return true;
                            }
                            else if (startWith)
                            {
                                if (searchTargetText_FILE.StartsWith(searchWord_ROM))
                                    return true;
                            }
                            else if (endWith)
                            {
                                if (searchTargetText_FILE.EndsWith(searchWord_ROM))
                                    return true;
                            }
                        }
                    }
                    else if (searchmode_FileInRom)
                    {
                        if (searchWord_ROM.Length > searchTargetText_FILE.Length)
                        {
                            if (contains)
                            {
                                if (searchWord_ROM.Contains(searchTargetText_FILE))
                                    return true;
                            }
                            else if (startWith)
                            {
                                if (searchWord_ROM.StartsWith(searchTargetText_FILE))
                                    return true;
                            }
                            else if (endWith)
                            {
                                if (searchWord_ROM.EndsWith(searchTargetText_FILE))
                                    return true;
                            }
                        }
                    }
                    else if (searchmode_RomInFile)
                    {
                        if (searchWord_ROM.Length < searchTargetText_FILE.Length)
                        {
                            if (contains)
                            {
                                if (searchTargetText_FILE.Contains(searchWord_ROM))
                                    return true;
                            }
                            else if (startWith)
                            {
                                if (searchTargetText_FILE.StartsWith(searchWord_ROM))
                                    return true;
                            }
                            else if (endWith)
                            {
                                if (searchTargetText_FILE.EndsWith(searchWord_ROM))
                                    return true;
                            }
                        }
                    }
                }

            }
            else// IS
            {
                if (searchWord_ROM.Length == searchTargetText_FILE.Length)
                {
                    if (searchTargetText_FILE == searchWord_ROM)
                        return true;
                }
            }

            return false;
        }
        private void AddTabConentFilesToRom(string tabName, string downloads_folder, List<string> links, string gameID,
            string tableName)
        {
            // Download the files
            Trace.WriteLine(string.Format("Downloading files for '{0}'", tabName), "Detect And Download From TheGamesDB.net");
            string NameOfSavedFiles = tabName + "-" + gameID;

            int c = 1;
            List<string> filesToAdd = new List<string>();
            foreach (string link in links)
            {
                // Try downloading
                try
                {
                    Trace.WriteLine(string.Format("Downloading file from '{0}'", link), "Detect And Download From TheGamesDB.net");

                    Uri uri = new Uri(link);
                    string[] splited = link.Split(new char[] { '/' });
                    string ext = Path.GetExtension(splited[splited.Length - 1]);
                    int j = 0;
                    while (File.Exists(Path.GetFullPath(downloads_folder + "\\" + NameOfSavedFiles + "(" + (j + 1).ToString() + ")" + ext)))
                        j++;

                    client.DownloadFile(uri, Path.GetFullPath(downloads_folder + "\\" + NameOfSavedFiles + "(" + (j + 1).ToString() + ")" + ext));

                    filesToAdd.Add(downloads_folder + "\\" + NameOfSavedFiles + "(" + (j + 1).ToString() + ")" + ext);

                    status_sub_sub = string.Format("[Downloading file {0} of {1} from {2}]", c, links.Count, link);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(string.Format("XXX Unable to download file from '{0}'; {1}", link, ex.Message), "Detect And Download From TheGamesDB.net");
                }
                c++;
            }
            // Add it !
            for (int j = 0; j < filesToAdd.Count; j++)
            {
                // Make sure this file isn;t exist for selected game
                MyNesDetectEntryInfo[] detects = MyNesDB.GetDetects(tableName, gameID);
                bool found = false;
                if (detects != null)
                {
                    foreach (MyNesDetectEntryInfo inf in detects)
                    {
                        if (inf.Path == filesToAdd[j])
                        {
                            found = true; break;
                        }
                    }
                }
                if (!found)
                {
                    // Add it !
                    MyNesDetectEntryInfo newDetect = new MyNesDetectEntryInfo();
                    newDetect.GameID = gameID;
                    newDetect.Path = filesToAdd[j];
                    newDetect.Name = Path.GetFileNameWithoutExtension(filesToAdd[j]);
                    newDetect.FileInfo = "";
                    MyNesDB.AddDetect(tableName, newDetect);
                }
            }
        }
        private void AddOverviewConentToGame(string tabName, string folder, string file_content, string gameID)
        {
            // Get the files
            string fileToAdd = tabName + "-" + gameID + ".txt";
            fileToAdd = Path.Combine(folder, fileToAdd);
            int i = 1;
            while (File.Exists(fileToAdd))
            {
                i++;
                fileToAdd = tabName + "-" + gameID + "_" + i + ".txt";
                fileToAdd = Path.Combine(folder, fileToAdd);
            }
            try
            {
                status_sub_sub = string.Format("[Saving file at {0} for {1}]", fileToAdd, tabName);
                File.WriteAllText(fileToAdd, file_content);
                Trace.WriteLine(string.Format("->File saved for '{0}' at '{1}'", tabName, fileToAdd), "Detect And Download From TheGamesDB.net");

                // Add it as detect
                // Make sure this file isn;t exist for selected game
                MyNesDetectEntryInfo[] detects = MyNesDB.GetDetects("INFOS", gameID);
                bool found = false;
                if (detects != null)
                {
                    foreach (MyNesDetectEntryInfo inf in detects)
                    {
                        if (inf.Path == fileToAdd)
                        {
                            found = true; break;
                        }
                    }
                }
                if (!found)
                {
                    // Add it !
                    MyNesDetectEntryInfo newDetect = new MyNesDetectEntryInfo();
                    newDetect.GameID = gameID;
                    newDetect.Path = fileToAdd;
                    newDetect.Name = Path.GetFileNameWithoutExtension(fileToAdd);
                    newDetect.FileInfo = "";
                    MyNesDB.AddDetect("INFOS", newDetect);
                }
            }
            catch (Exception ex)
            {
                Trace.TraceError(string.Format("XXX Unable to save file for '{0}' at '{1}'; " + ex.Message, tabName, fileToAdd));
            }
        }
        private void ApplyRom(string gameName, string gameID, Game game)
        {
            if (_db_rename_rom_using_title)
            {
                MyNesDB.UpdateEntry(gameID, game.Title);
                Trace.WriteLine(string.Format("->Rom renamed from {0} to {1}", gameName, game.Title), "Detect And Download From TheGamesDB.net");
            }

            // Overview
            if (_db_add_overview_as_tab)
                AddOverviewConentToGame("Overview", _db_overview_folder, game.Overview, gameID);

            #region Banners
            if (_db_add_banners_as_tab)
            {
                if (game.Images.Banners != null)
                {
                    if (game.Images.Banners.Count > 0)
                    {
                        // Download the tabs for it !
                        List<string> links = new List<string>();
                        for (int i = 0; i < game.Images.Banners.Count; i++)
                        {
                            links.Add(GamesDB.BaseImgURL + game.Images.Banners[i].Path);
                            if (_db_banners_ic_limitdownload)
                                break;// one link added so far.
                        }
                        AddTabConentFilesToRom("Banners", _db_banners_folder, links, gameID, _db_banners_is_cover ? "COVERS" : "SNAPS");
                    }
                }
            }
            #endregion
            #region Screenshots
            if (_db_add_screenshots_as_tab)
            {
                if (game.Images.Screenshots != null)
                {
                    if (game.Images.Screenshots.Count > 0)
                    {
                        // Download the tabs for it !
                        List<string> links = new List<string>();
                        for (int i = 0; i < game.Images.Screenshots.Count; i++)
                        {
                            links.Add(GamesDB.BaseImgURL + game.Images.Screenshots[i].Path);
                            if (_db_screenshots_ic_limitdownload)
                                break;// one link added so far.
                        }
                        // Download for it !
                        AddTabConentFilesToRom("Screenshots", _db_screenshots_folder, links, gameID, _db_screenshots_is_cover ? "COVERS" : "SNAPS");
                    }
                }
            }
            #endregion
            #region Fanart
            if (_db_add_fanart_as_tab)
            {
                if (game.Images.Fanart != null)
                {
                    if (game.Images.Fanart.Count > 0)
                    {
                        // Download the tabs for it !
                        List<string> links = new List<string>();
                        for (int i = 0; i < game.Images.Fanart.Count; i++)
                        {
                            links.Add(GamesDB.BaseImgURL + game.Images.Fanart[i].Path);
                            if (_db_fanart_ic_limitdownload)
                                break;// one link added so far.
                        }
                        // Download the tabs for it !
                        AddTabConentFilesToRom("Fanart", _db_fanart_folder, links, gameID, _db_fanart_is_cover ? "COVERS" : "SNAPS");
                    }
                }
            }
            #endregion
            #region Boxart back
            if (_db_add_boxart_back_as_tab)
            {
                if (game.Images.BoxartBack != null)
                {
                    // Download the tabs for it !
                    List<string> links = new List<string>();
                    links.Add(GamesDB.BaseImgURL + game.Images.BoxartBack.Path);

                    // Download the tabs for it !
                    AddTabConentFilesToRom("Boxart Back", _db_boxart_back_folder, links, gameID, _db_boxart_back_is_cover ? "COVERS" : "SNAPS");
                }
            }
            #endregion
            #region Boxart Front
            if (_db_add_boxart_front_as_tab)
            {
                if (game.Images.BoxartFront != null)
                {
                    // Download the tabs for it !
                    List<string> links = new List<string>();
                    links.Add(GamesDB.BaseImgURL + game.Images.BoxartFront.Path);

                    // Download the tabs for it !
                    AddTabConentFilesToRom("Boxart Front", _db_boxart_front_folder, links, gameID, _db_boxart_front_is_cover ? "COVERS" : "SNAPS");
                }
            }
            #endregion
        }

        private void CloseAfterFinish()
        {
            if (!this.InvokeRequired)
                CloseAfterFinish1();
            else
                this.Invoke(new Action(CloseAfterFinish1));
        }
        private void CloseAfterFinish1()
        {
            finished = true;
            ManagedMessageBoxResult res = ManagedMessageBox.ShowMessage(
              Program.ResourceManager.GetString("Message_Done") + ", " +
              Program.ResourceManager.GetString("Message_LogFileSavedTo") + " '" + logPath + "'",
              Program.ResourceManager.GetString("MessageCaption_DetectAndDownloadFromTheGamesDB"), new string[] { 
              Program.ResourceManager.GetString("Button_Ok"),
              Program.ResourceManager.GetString("Button_OpenLog") },
              0, null, ManagedMessageBoxIcon.Info);
            if (res.ClickedButtonIndex == 1)
            {
                try { Process.Start(HelperTools.GetFullPath(logPath)); }
                catch (Exception ex)
                { ManagedMessageBox.ShowErrorMessage(ex.Message); }
            }

            this.Close();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.SelectedPath = textBox_overview_folder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_overview_folder.Text = fol.SelectedPath;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.SelectedPath = textBox_boxart_back_folder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_boxart_back_folder.Text = fol.SelectedPath;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.SelectedPath = textBox_boxart_front_folder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_boxart_front_folder.Text = fol.SelectedPath;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.SelectedPath = textBox_Fanart_folder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_Fanart_folder.Text = fol.SelectedPath;
            }
        }
        private void button_banners_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.SelectedPath = textBox_Banners_folder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_Banners_folder.Text = fol.SelectedPath;
            }
        }
        private void button8_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.SelectedPath = textBox_Screenshots_folder.Text;
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                textBox_Screenshots_folder.Text = fol.SelectedPath;
            }
        }
        private void button9_Click(object sender, EventArgs e)
        {
            checkBox_include_banners.Checked =
                checkBox_add_boxart_back.Checked =
                checkBox_include_boxart_front.Checked =
                checkBox_include_fanart.Checked =
                checkBox_add_overview.Checked =
                checkBox_include_screenshots.Checked =
                checkBox_rename_rom.Checked = true;
        }
        private void button10_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog();
            fol.ShowNewFolderButton = true;
            fol.Description = "Please select a master folder where to save the downloaded files (empty folder is recommended)";
            if (fol.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
            {
                ManagedMessageBoxResult res = ManagedMessageBox.ShowQuestionMessage("These folders will be created :"
                   + "\n" + fol.SelectedPath + "\\Overview\\"
                    + "\n" + fol.SelectedPath + "\\Banners\\"
                    + "\n" + fol.SelectedPath + "\\BoxartBack\\"
                    + "\n" + fol.SelectedPath + "\\BoxartFront\\"
                    + "\n" + fol.SelectedPath + "\\Fanart\\"
                    + "\n" + fol.SelectedPath + "\\Screenshots\\"
                    + "\n" + "\nConinue ?");
                if (res.ClickedButtonIndex == 0)
                {
                    textBox_overview_folder.Text = fol.SelectedPath + "\\Overview\\";
                    textBox_Banners_folder.Text = fol.SelectedPath + "\\Banners\\";
                    textBox_boxart_back_folder.Text = fol.SelectedPath + "\\BoxartBack\\";
                    textBox_boxart_front_folder.Text = fol.SelectedPath + "\\BoxartFront\\";
                    textBox_Fanart_folder.Text = fol.SelectedPath + "\\Fanart\\";
                    textBox_Screenshots_folder.Text = fol.SelectedPath + "\\Screenshots\\";
                    Directory.CreateDirectory(textBox_overview_folder.Text);
                    Directory.CreateDirectory(textBox_Banners_folder.Text);
                    Directory.CreateDirectory(textBox_boxart_back_folder.Text);
                    Directory.CreateDirectory(textBox_boxart_front_folder.Text);
                    Directory.CreateDirectory(textBox_Fanart_folder.Text);
                    Directory.CreateDirectory(textBox_Screenshots_folder.Text);
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.thegamesdb.net/");
            }
            catch { }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            label_status_master.Text = status_master;
            label_status_sub.Text = status_sub + " " + status_sub_sub;
            progressBar_master.Value = progress_master;
            progressBar_slave.Value = progress_sub;
        }
        private void Form_DetectAndDownloadFromTheGamesDB_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!finished)
            {
                if (mainThread != null)
                {
                    if (mainThread.IsAlive)
                    {
                        ManagedMessageBoxResult result =
                            ManagedMessageBox.ShowQuestionMessage(
                            Program.ResourceManager.GetString("Message_AreYouSureYouWantToStopCurrentProgress"),
                            Program.ResourceManager.GetString("MessageCaption_DetectAndDownloadFromTheGamesDB"));
                        if (result.ClickedButtonIndex == 0)
                        {
                            client.CancelAsync();
                            mainThread.Abort();
                            mainThread = null;
                            Trace.WriteLine("Database import operation finished at " + DateTime.Now.ToLocalTime(), "Detect And Download From TheGamesDB.net");
                            listner.Flush();
                            Trace.Listeners.Remove(listner);
                            CloseAfterFinish();
                        }
                        else
                        {
                            e.Cancel = true;
                        }
                    }
                }
            }
        }
        // START !!
        private void button2_Click(object sender, EventArgs e)
        {
            // Make checks
            if (comboBox_platforms.SelectedIndex < 0)
            {
                ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_PleaseSelectAPlatformFirst"));
                return;
            }
            if (checkBox_include_banners.Checked)
            {
                if (!Directory.Exists(textBox_Banners_folder.Text))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_TheFolderForBannersIsNotExist"));
                    button_banners_Click(null, null);
                    return;
                }
            }
            if (checkBox_add_boxart_back.Checked)
            {
                if (!Directory.Exists(textBox_boxart_back_folder.Text))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_TheFolderForBoxartBackIsNotExist"));
                    button4_Click(null, null);
                    return;
                }
            }
            if (checkBox_include_boxart_front.Checked)
            {
                if (!Directory.Exists(textBox_boxart_front_folder.Text))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_TheFolderForBoxartFrontIsNotExist"));
                    button5_Click(null, null);
                    return;
                }
            }
            if (checkBox_include_fanart.Checked)
            {
                if (!Directory.Exists(textBox_Fanart_folder.Text))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_TheFolderForFanartIsNotExist"));
                    button6_Click(null, null);
                    return;
                }
            }
            if (checkBox_add_overview.Checked)
            {
                if (!Directory.Exists(textBox_overview_folder.Text))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_TheFolderForOverviewIsNotExist"));
                    button1_Click_1(null, null);
                    return;
                }
            }
            if (checkBox_include_screenshots.Checked)
            {
                if (!Directory.Exists(textBox_overview_folder.Text))
                {
                    ManagedMessageBox.ShowErrorMessage(Program.ResourceManager.GetString("Message_TheFolderForScreenshotsIsNotExist"));
                    button8_Click(null, null);
                    return;
                }
            }
            // Poke options ...
            _clear_info_table = checkBox_clear_info_table.Checked;
            _clear_snaps_table = checkBox_clear_snapshots_table.Checked;
            _clear_covers_table = checkBox_clear_covers_table.Checked;

            matchCase = checkBox_matchCase.Checked;
            matchWord = checkBox_matchWord.Checked;
            useRomNameInsteadRomFileName = checkBox_useRomNameInstead.Checked;
            searchmode_FileInRom = radioButton_searchmode_fileinrom.Checked;
            searchmode_RomInFile = radioButton_searchmode_rominfile.Checked;
            searchmode_Both = radioButton_searchmode_both.Checked;
            startWith = radioButton_startWith.Checked;
            contains = radioButton_contains.Checked;
            endWith = radioButton_endwith.Checked;
            useNameWhenPathNotValid = checkBox_useNameWhenPathNotValid.Checked;

            _turbo_speed = checkBox_turboe.Checked;

            _db_selected_platform_id = ((PlatformSearchResult)comboBox_platforms.SelectedItem).ID;
            _db_rename_rom_using_title = checkBox_rename_rom.Checked;

            _db_banners_is_cover = radioButton_banners_to_covers.Checked;
            _db_boxart_front_is_cover = radioButton_boxart_front_to_covers.Checked;
            _db_boxart_back_is_cover = radioButton_boxart_back_to_covers.Checked;
            _db_fanart_is_cover = radioButton_fanart_to_covers.Checked;
            _db_screenshots_is_cover = radioButton_screenshots_to_covers.Checked;

            _db_add_overview_as_tab = checkBox_add_overview.Checked;
            _db_add_banners_as_tab = checkBox_include_banners.Checked;
            _db_add_boxart_front_as_tab = checkBox_include_boxart_front.Checked;
            _db_add_boxart_back_as_tab = checkBox_add_boxart_back.Checked;
            _db_add_fanart_as_tab = checkBox_include_fanart.Checked;
            _db_add_screenshots_as_tab = checkBox_include_screenshots.Checked;

            _db_overview_folder = textBox_overview_folder.Text;
            _db_banners_folder = textBox_Banners_folder.Text;
            _db_boxart_front_folder = textBox_boxart_front_folder.Text;
            _db_boxart_back_folder = textBox_boxart_back_folder.Text;
            _db_fanart_folder = textBox_Fanart_folder.Text;
            _db_screenshots_folder = textBox_Screenshots_folder.Text;

            _db_fanart_ic_limitdownload = checkBox_limit_download_fanart.Checked;
            _db_screenshots_ic_limitdownload = checkBox_limit_download_screenshots.Checked;
            _db_banners_ic_limitdownload = checkBox_limit_download_banners.Checked;
            // Disable everything
            groupBox1.Enabled = groupBox2.Enabled = groupBox3.Enabled = tabControl1.Enabled =
            groupBox_general.Enabled = button_set_all.Enabled = button_set_master_folder.Enabled = false;
            button_start.Enabled = false;
            // Start timer
            timer1.Start();
            finished = false;
            // Start thread !
            mainThread = new Thread(new ThreadStart(PROCESS));
            mainThread.CurrentUICulture = Thread.CurrentThread.CurrentUICulture;
            mainThread.Start();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
