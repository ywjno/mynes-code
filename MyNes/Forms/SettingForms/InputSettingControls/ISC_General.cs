using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MyNes
{
    public partial class ISC_General : InputSettingsControl
    {
        public ISC_General()
        {
            InitializeComponent();
            checkBox_4players.Checked = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Connect4Players;
            checkBox_zapper.Checked = Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].ConnectZapper;
        }
        public override void SaveSettings()
        {
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].Connect4Players = checkBox_4players.Checked;
            Program.Settings.ControlProfiles[Program.Settings.ControlProfileIndex].ConnectZapper = checkBox_zapper.Checked;
        }
        public override void DefaultSettings()
        {
            checkBox_4players.Checked = false;
            checkBox_zapper.Checked = false;
        }
    }
}
