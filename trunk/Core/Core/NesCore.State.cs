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
using System.IO;
using MyNes.Core.State;
namespace MyNes.Core
{
    public partial class NesCore
    {
        private static bool saveStateRequest;
        private static bool saveMemoryStateRequest;
        private static bool loadStateRequest;
        private static bool loadMemoryStateRequest;
        private static string requestStatePath;
        private static byte[] memoryState;
        public static int StateSlot = 0;

        public static void SaveState(string folder)
        { SaveStateAs(Path.Combine(folder, Path.GetFileNameWithoutExtension(RomInfo.RomPath) + "_" + StateSlot + ".msn")); }
        public static void SaveStateAs(string fileName)
        {
            TogglePauseAtFrameFinish = true;
            requestStatePath = fileName;
            saveStateRequest = true;
        }
        public static void LoadState(string folder)
        { LoadStateAs(Path.Combine(folder, Path.GetFileNameWithoutExtension(RomInfo.RomPath) + "_" + StateSlot + ".msn")); }
        public static void LoadStateAs(string fileName)
        {
            TogglePauseAtFrameFinish = true;
            requestStatePath = fileName;
            loadStateRequest = true;
        }
        private static void _saveState()
        {
            // Create the state stream
            SaveStateStream stream = new SaveStateStream(requestStatePath);
            stream.WriteHeader(6, RomInfo.SHA1);
            Console.WriteLine("Saving state at slot " + StateSlot);

            // Save !
            CPU.SaveState(stream);
            PPU.SaveState(stream);
            APU.SaveState(stream);
            BOARD.SaveState(stream);
            ControlsUnit.SaveState(stream);

            stream.Close();

            //save snap
            VideoOutput.TakeSnapshot(Path.GetDirectoryName(requestStatePath), Path.GetFileNameWithoutExtension(requestStatePath),
                ".png", true);
            //save text info
            File.WriteAllText(Path.Combine(Path.GetDirectoryName(requestStatePath),
                Path.GetFileNameWithoutExtension(requestStatePath) + ".txt"), RomInfo.RomPath);
            if (VideoOutput != null)
                VideoOutput.DrawNotification("State saved at slot " + StateSlot, 120, System.Drawing.Color.Green.ToArgb());
            Console.WriteLine("State saved at slot " + StateSlot, DebugCode.Good);
            saveStateRequest = false;
            PAUSED = false;
        }
        private static void _loadState()
        {
            Console.WriteLine("Loading state at slot " + StateSlot);
            ReadStateStream stream = null;
            if (!File.Exists(requestStatePath))
            {
                if (VideoOutput != null)
                    VideoOutput.DrawNotification("No state found at slot " + StateSlot, 120, System.Drawing.Color.Red.ToArgb());
                Console.WriteLine("No state found at slot " + StateSlot, DebugCode.Error);
                goto Finish;
            }
            // Decompress
            try
            {
                Stream dstream = new FileStream(requestStatePath, FileMode.Open, FileAccess.Read);
                // read buffer
                byte[] buffer = new byte[dstream.Length];
                dstream.Read(buffer, 0, buffer.Length);
                dstream.Close();
                dstream.Dispose();
                // decompress
                byte[] tb;
                ZLIBWrapper.DecompressData(buffer, out tb);
                MemoryStream memoryStream = new MemoryStream(tb);
                stream = new ReadStateStream(memoryStream);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unable to open state file: " + ex.Message, DebugCode.Error);
                if (NesCore.VideoOutput != null)
                    NesCore.VideoOutput.DrawNotification("Unable to open state file: " + ex.Message, 120, System.Drawing.Color.Red.ToArgb());
                goto Finish;
            }
            if (!stream.ReadHeader(6, RomInfo.SHA1))
            {
                if (VideoOutput != null)
                    VideoOutput.DrawNotification("Unable to load state from slot " + StateSlot + ", corrupted header or incompatible version !!", 120, System.Drawing.Color.Red.ToArgb());
                Console.WriteLine("Unable to load state, corrupted header or incompatible version !!", DebugCode.Error);
                goto Finish;
            }
            // Load
            CPU.LoadState(stream);
            PPU.LoadState(stream);
            APU.LoadState(stream);
            BOARD.LoadState(stream);
            ControlsUnit.LoadState(stream);
            if (VideoOutput != null)
                VideoOutput.DrawNotification("State loaded from slot " + StateSlot, 120, System.Drawing.Color.Green.ToArgb());
            Console.WriteLine("State loaded from slot " + StateSlot, DebugCode.Good);
        Finish:
            if (stream != null)
                stream.Close();
            loadStateRequest = false;
            PAUSED = false;
        }

        /*Memory State*/
        public static void SaveMemoryState()
        {
            TogglePauseAtFrameFinish = true;
            saveMemoryStateRequest = true;
        }
        private static void _saveMemoryState()
        {
            SaveStateStream stream = new SaveStateStream();

            //save
            CPU.SaveState(stream);
            PPU.SaveState(stream);
            APU.SaveState(stream);
            BOARD.SaveState(stream);
            ControlsUnit.SaveState(stream);

            memoryState = stream.GetBufferCompressed();
            stream.Close();
            stream.Dispose();
            saveMemoryStateRequest = false;
            PAUSED = false;
            Console.WriteLine("Quick state saved", DebugCode.Good);
            if (VideoOutput != null)
                VideoOutput.DrawNotification("Quick state saved !", 120, System.Drawing.Color.Green.ToArgb());
        }
        public static void LoadMemoryState()
        {
            TogglePauseAtFrameFinish = true;
            loadMemoryStateRequest = true;
        }
        private static void _loadMemoryState()
        {
            if (memoryState != null)
            {
                ReadStateStream stream = null;
                // Decompress
                try
                {
                    Stream dstream = new MemoryStream(memoryState);
                    // read buffer
                    byte[] buffer = new byte[dstream.Length];
                    dstream.Read(buffer, 0, buffer.Length);
                    dstream.Close();
                    dstream.Dispose();
                    // decompress
                    byte[] tb;
                    ZLIBWrapper.DecompressData(buffer, out tb);
                    stream = new ReadStateStream(new MemoryStream(tb));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Unable to load quick state save", DebugCode.Error);
                    if (NesCore.VideoOutput != null)
                        NesCore.VideoOutput.DrawNotification("Unable to load quick state save", 120, System.Drawing.Color.Red.ToArgb());
                    goto Finish;
                }
                // Load
                CPU.LoadState(stream);
                PPU.LoadState(stream);
                APU.LoadState(stream);
                BOARD.LoadState(stream);
                ControlsUnit.LoadState(stream);
                if (VideoOutput != null)
                    VideoOutput.DrawNotification("Quick state loaded !", 120, System.Drawing.Color.Green.ToArgb());
                Console.WriteLine("Quick state loaded !", DebugCode.Good);
            Finish:
                if (stream != null)
                    stream.Close();
                loadStateRequest = false;
                PAUSED = false;
            }
            loadMemoryStateRequest = false;
        }
        public static byte[] GetMemoryState()
        {
            return memoryState;
        }
        public static void SetMemoryState(byte[] state)
        {
            memoryState = state;
        }
    }
}
