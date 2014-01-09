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
using System.Collections.Generic;
namespace MyNes
{
    [System.Serializable()]
    public class ControlProfile
    {
        private string name = "<Default>";
        private bool connect4Players = false;
        private bool connectZapper = false;
        private ControlsProfilePlayer player1 = new ControlsProfilePlayer();
        private ControlsProfilePlayer player2 = new ControlsProfilePlayer();
        private ControlsProfilePlayer player3 = new ControlsProfilePlayer();
        private ControlsProfilePlayer player4 = new ControlsProfilePlayer();
        private ControlProfileVSUnisystemDIP vsunisystem = new ControlProfileVSUnisystemDIP();

        public string Name
        { get { return name; } set { name = value; } }
        public ControlsProfilePlayer Player1
        { get { return player1; } set { player1 = value; } }
        public ControlsProfilePlayer Player2
        { get { return player2; } set { player2 = value; } }
        public ControlsProfilePlayer Player3
        { get { return player3; } set { player3 = value; } }
        public ControlsProfilePlayer Player4
        { get { return player4; } set { player4 = value; } }
        public ControlProfileVSUnisystemDIP VSunisystemDIP
        { get { return vsunisystem; } set { vsunisystem = value; } }
        public bool Connect4Players
        { get { return connect4Players; } set { connect4Players = value; } }
        public bool ConnectZapper
        { get { return connectZapper; } set { connectZapper = value; } }
        public override string ToString()
        {
            return name;
        }

        public static void BuildDefaultProfile()
        {
            if (Program.Settings.InputProfiles == null)
                Program.Settings.InputProfiles = new ControlProfilesCollection();
            if (Program.Settings.InputProfiles.Count == 0)
            {
                ControlProfile profile = new ControlProfile();
                profile.Name = "<Default>";

                profile.Player1.A = "Keyboard.X";
                profile.Player1.B = "Keyboard.Z";
                profile.Player1.TurboA = "Keyboard.S";
                profile.Player1.TurboB = "Keyboard.A";
                profile.Player1.Left = "Keyboard.LeftArrow";
                profile.Player1.Right = "Keyboard.RightArrow";
                profile.Player1.Up = "Keyboard.UpArrow";
                profile.Player1.Down = "Keyboard.DownArrow";
                profile.Player1.Start = "Keyboard.V";
                profile.Player1.Select = "Keyboard.C";

                profile.Player2.A = "Keyboard.K";
                profile.Player2.B = "Keyboard.J";
                profile.Player2.TurboA = "Keyboard.I";
                profile.Player2.TurboB = "Keyboard.U";
                profile.Player2.Left = "Keyboard.A";
                profile.Player2.Right = "Keyboard.D";
                profile.Player2.Up = "Keyboard.W";
                profile.Player2.Down = "Keyboard.S";
                profile.Player2.Start = "Keyboard.E";
                profile.Player2.Select = "Keyboard.Q";

                profile.player3.A = "Keyboard.Unknown";
                profile.Player3.B = "Keyboard.Unknown";
                profile.Player3.TurboA = "Keyboard.Unknown";
                profile.Player3.TurboB = "Keyboard.Unknown";
                profile.Player3.Left = "Keyboard.Unknown";
                profile.Player3.Right = "Keyboard.Unknown";
                profile.Player3.Up = "Keyboard.Unknown";
                profile.Player3.Down = "Keyboard.Unknown";
                profile.Player3.Start = "Keyboard.Unknown";
                profile.Player3.Select = "Keyboard.Unknown";

                profile.player4.A = "Keyboard.Unknown";
                profile.Player4.B = "Keyboard.Unknown";
                profile.Player4.TurboA = "Keyboard.Unknown";
                profile.Player4.TurboB = "Keyboard.Unknown";
                profile.Player4.Left = "Keyboard.Unknown";
                profile.Player4.Right = "Keyboard.Unknown";
                profile.Player4.Up = "Keyboard.Unknown";
                profile.Player4.Down = "Keyboard.Unknown";
                profile.Player4.Start = "Keyboard.Unknown";
                profile.Player4.Select = "Keyboard.Unknown";

                profile.VSunisystemDIP.CreditServiceButton = "Keyboard.End";
                profile.VSunisystemDIP.DIPSwitch1 = "Keyboard.NumberPad1";
                profile.VSunisystemDIP.DIPSwitch2 = "Keyboard.NumberPad2";
                profile.VSunisystemDIP.DIPSwitch3 = "Keyboard.NumberPad3";
                profile.VSunisystemDIP.DIPSwitch4 = "Keyboard.NumberPad4";
                profile.VSunisystemDIP.DIPSwitch5 = "Keyboard.NumberPad5";
                profile.VSunisystemDIP.DIPSwitch6 = "Keyboard.NumberPad6";
                profile.VSunisystemDIP.DIPSwitch7 = "Keyboard.NumberPad7";
                profile.VSunisystemDIP.DIPSwitch8 = "Keyboard.NumberPad8";
                profile.VSunisystemDIP.CreditLeftCoinSlot = "Keyboard.Insert";
                profile.VSunisystemDIP.CreditRightCoinSlot = "Keyboard.Home";

                // Add the profile
                Program.Settings.InputProfiles.Add(profile);
            }
        }
    }
    [System.Serializable()]
    public class ControlProfilesCollection : List<ControlProfile>//For settings
    {
    }
}
