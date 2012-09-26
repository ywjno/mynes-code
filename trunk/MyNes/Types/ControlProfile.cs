﻿using System.Collections.Generic;
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
        private ControlsProfileMyNesShortcut shortcuts = new ControlsProfileMyNesShortcut();
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
        public ControlsProfileMyNesShortcut Shortcuts
        { get { return shortcuts; } set { shortcuts = value; } }
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
            if (Program.Settings.ControlProfiles == null)
                Program.Settings.ControlProfiles = new ControlProfilesCollection();
            if (Program.Settings.ControlProfiles.Count == 0)
            {
                ControlProfile profile = new ControlProfile();
                profile.Name = "<Default>";

                profile.Player1.A = "Keyboard.X";
                profile.Player1.B = "Keyboard.Z";
                profile.Player1.Left = "Keyboard.LeftArrow";
                profile.Player1.Right = "Keyboard.RightArrow";
                profile.Player1.Up = "Keyboard.UpArrow";
                profile.Player1.Down = "Keyboard.DownArrow";
                profile.Player1.Start = "Keyboard.V";
                profile.Player1.Select = "Keyboard.C";

                profile.Player2.A = "Keyboard.K";
                profile.Player2.B = "Keyboard.J";
                profile.Player2.Left = "Keyboard.A";
                profile.Player2.Right = "Keyboard.D";
                profile.Player2.Up = "Keyboard.W";
                profile.Player2.Down = "Keyboard.S";
                profile.Player2.Start = "Keyboard.E";
                profile.Player2.Select = "Keyboard.Q";

                profile.Player3.A = "Keyboard.M";
                profile.Player3.B = "Keyboard.N";
                profile.Player3.Left = "Keyboard.F";
                profile.Player3.Right = "Keyboard.H";
                profile.Player3.Up = "Keyboard.T";
                profile.Player3.Down = "Keyboard.G";
                profile.Player3.Start = "Keyboard.Y";
                profile.Player3.Select = "Keyboard.U";

                profile.Player4.A = "Keyboard.I";
                profile.Player4.B = "Keyboard.O";
                profile.Player4.Left = "Keyboard.P";
                profile.Player4.Right = "Keyboard.L";
                profile.Player4.Up = "Keyboard.B";
                profile.Player4.Down = "Keyboard.G";
                profile.Player4.Start = "Keyboard.R";
                profile.Player4.Select = "Keyboard.F11";

                profile.Shortcuts.ResumeEmulation = "Keyboard.F1";
                profile.Shortcuts.PauseEmulation = "Keyboard.F2";
                profile.Shortcuts.SoftReset = "Keyboard.F3";
                profile.Shortcuts.HardReset = "Keyboard.F4";
                profile.Shortcuts.TakeSnapshot = "Keyboard.F5";
                profile.Shortcuts.SaveState = "Keyboard.F6";
                profile.Shortcuts.ToggleLimiter = "Keyboard.F7";
                profile.Shortcuts.LoadState = "Keyboard.F9";
                profile.shortcuts.Fullscreen = "Keyboard.F12";
                profile.Shortcuts.SelecteSlot0 = "Keyboard.D0";
                profile.Shortcuts.SelecteSlot1 = "Keyboard.D1";
                profile.Shortcuts.SelecteSlot2 = "Keyboard.D2";
                profile.Shortcuts.SelecteSlot3 = "Keyboard.D3";
                profile.Shortcuts.SelecteSlot4 = "Keyboard.D4";
                profile.Shortcuts.SelecteSlot5 = "Keyboard.D5";
                profile.Shortcuts.SelecteSlot6 = "Keyboard.D6";
                profile.Shortcuts.SelecteSlot7 = "Keyboard.D7";
                profile.Shortcuts.SelecteSlot8 = "Keyboard.D8";
                profile.Shortcuts.SelecteSlot9 = "Keyboard.D9";
                profile.Shortcuts.ShutdownEmulation = "Keyboard.Escape";

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

                Program.Settings.ControlProfiles.Add(profile);
            }
        }
    }
    public class ControlProfilesCollection : List<ControlProfile>//For settings
    {
    }
}