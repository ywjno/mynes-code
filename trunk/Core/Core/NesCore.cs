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
using System.Threading;
using MyNes.Core.Database;
using MyNes.Core.CPU;
using MyNes.Core.PPU;
using MyNes.Core.APU;
using MyNes.Core.Boards;
using MyNes.Core.ROM;

using MyNes.Core.Controls;
using MyNes.Core.IO;
using MyNes.Core.State;
namespace MyNes.Core
{
    /// <summary>
    /// The nes core. All members are static.
    /// </summary>
    public partial class NesCore
    {
        /// <summary>
        /// Call this at program start up
        /// </summary>
        public static void StartUp()
        {
            ConsoleCommands.AddDefaultCommands();
            BoardsManager.LoadAvailableBoards();
            //load database
            if (File.Exists(Path.Combine(Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]), "database.xml")))
                NesDatabase.LoadDatabase(Path.Combine(Path.GetDirectoryName(System.Environment.GetCommandLineArgs()[0]), "database.xml"));
        }
        /// <summary>
        /// Apply core settings ....
        /// </summary>
        /// <param name="settings">The struct that contain settings ...</param>
        public static void ApplySettings(NesCoreSettings settings)
        {
            SRAMFolder = settings.SRAMFolder;
            SaveSRAMOnShutdown = settings.SaveSRAMOnShutdown;
            SoundEnabled = settings.SoundEnabled;
        }

        /*Setup*/
        /// <summary>
        /// Setup output devices
        /// </summary>
        /// <param name="videoDevice">The video device</param>
        /// <param name="audioDevice">The audio device</param>
        /// <param name="audio_frequency">The sound playback frequency.</param>
        public static void SetupOutput(IVideoDevice videoDevice, IAudioDevice audioDevice, int audio_frequency)
        {
            VideoOutput = videoDevice;
            AudioOutput = audioDevice;
            APU.SetupPlayback(audio_frequency);
        }
        /// <summary>
        /// Setup input
        /// </summary>
        /// <param name="inputDevice">The input device</param>
        /// <param name="joypad1">The player 1 joypad</param>
        /// <param name="joypad2">The player 2 joypad</param>
        public static void SetupInput(IInputDevice inputDevice, IJoypad joypad1, IJoypad joypad2)
        {
            SetupInput(inputDevice, joypad1, joypad2, null, null, false);
        }
        /// <summary>
        /// Setup input
        /// </summary>
        /// <param name="inputDevice">The input device</param>
        /// <param name="joypad1">The player 1 joypad</param>
        /// <param name="joypad2">The player 2 joypad</param>
        /// <param name="joypad3">The player 3 joypad</param>
        /// <param name="joypad4">The player 4 joypad</param>
        /// <param name="is4Players">Is 4 players enabled</param>
        public static void SetupInput(IInputDevice inputDevice, IJoypad joypad1, IJoypad joypad2, IJoypad joypad3, IJoypad joypad4, bool is4Players)
        {
            ControlsUnit.InputDevice = inputDevice;
            ControlsUnit.IsFourPlayers = is4Players;
            ControlsUnit.Joypad1 = joypad1;
            ControlsUnit.Joypad2 = joypad2;
            ControlsUnit.Joypad3 = joypad3;
            ControlsUnit.Joypad4 = joypad4;
        }
        public static void SetupPalette()
        {
            // Assuming palette generators settings already loaded ...
            switch (TV)
            {
                case TVSystem.NTSC: PPU.SetupPalette(NTSCPaletteGenerator.GeneratePalette()); break;
                case TVSystem.PALB: PPU.SetupPalette(PALBPaletteGenerator.GeneratePalette()); break;
                case TVSystem.DENDY: PPU.SetupPalette(DENDYPaletteGenerator.GeneratePalette()); break;
            }
        }
    }
}
