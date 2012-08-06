using System;
using System.Reflection;
using System.Windows.Forms;
using MyNes.Core;
using MyNes.Debug.ConsoleCommands;
using Console = MyNes.Core.Console;

namespace MyNes
{
    public partial class FormConsole : Form
    {
        public FormConsole()
        {
            InitializeComponent();
            LoadSettings();
            //add default commands
            ConsoleCommands.AddDefaultCommands();
            //add other commands
            ConsoleCommands.AddCommand(new CloseConsole(this));
            AddCommands();
        }
        void AddCommands()
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type tp in types)
            {
                if (tp.IsSubclassOf(typeof(ConsoleCommand)))
                {
                    if (tp != typeof(CloseConsole))
                    {
                        ConsoleCommand command = Activator.CreateInstance(tp) as ConsoleCommand;
                        ConsoleCommands.AddCommand(command);
                    }
                }
            }
        }
        void LoadSettings()
        {
            this.Location = Program.Settings.console_location;
            this.Size = Program.Settings.console_size;
        }
        void SaveSettings()
        {
            Program.Settings.console_location = this.Location;
            Program.Settings.console_size = this.Size;
        }
        void UpdateVscroll()
        {
            if (consolePanel.StringHeight < consolePanel.Height)
            {
                vScrollBar.Maximum = 1;
                vScrollBar.Value = 0;
                vScrollBar.Enabled = false;
                consolePanel.ScrollOffset = 0;
            }
            else
            {
                vScrollBar.Enabled = true;
                vScrollBar.Maximum = consolePanel.StringHeight - consolePanel.Height + 15;
                vScrollBar.Value = vScrollBar.Maximum - 1;
                consolePanel.ScrollOffset = vScrollBar.Value;
            }
            consolePanel.Invalidate();
        }

        void ExecuteCommand()
        {
            if (!this.InvokeRequired)
            {
                this.DoCommand();
            }
            else
            {
                this.Invoke(new Action(DoCommand));
            }
        }
        void DoCommand()
        {
            //refresh commands list
            if (!comboBoxHistory.Items.Contains(comboBoxHistory.Text))
                comboBoxHistory.Items.Add(comboBoxHistory.Text);
            comboBoxHistory.SelectAll();
            //detect command
            bool found = false;
            bool showCommandHelp = false;
            string[] code = comboBoxHistory.Text.Split(new char[] { ' ' });
            foreach (ConsoleCommand command in ConsoleCommands.AvailableCommands)
            {
                if (command.Method == code[0])
                {
                    if (command.Parameters.Length == 0 && code.Length > 1)
                    {
                        Console.WriteLine("] " + comboBoxHistory.Text + ": THIS COMAND HAS NO PARAMETER", DebugCode.Warning);
                        showCommandHelp = true;
                    }
                    else if (command.Parameters.Length > 0 && code.Length == 1)
                    {
                        Console.WriteLine("] " + comboBoxHistory.Text + ": THIS COMAND HAVE PARAMETERS AND NO PARAMETER PASSED", DebugCode.Error);
                        showCommandHelp = true;
                    }
                    else
                    {
                        Console.WriteLine("] " + comboBoxHistory.Text);
                        command.Execute(comboBoxHistory.Text);
                    }
                    found = true;
                    if (showCommandHelp)
                    {
                        string line = "> " + command.Method + " ";
                        foreach (string par in command.Parameters)
                            line += par + " ";
                        line += command.Description;
                        Console.WriteLine("HELP:" + line);
                    }
                    break;
                }
            }
            if (!found)
            {
                Console.WriteLine("] " + comboBoxHistory.Text + ": COMMAND NOT FOUND", DebugCode.Error);
            }
        }

        private void consolePanel1_DebugLinesUpdated(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        private void Frm_Console_Resize(object sender, EventArgs e)
        {
            UpdateVscroll();
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            consolePanel.ScrollOffset = vScrollBar.Value;
            consolePanel.Invalidate();
        }
        private void Frm_Console_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveSettings();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ExecuteCommand();
        }
        private void Frm_Console_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                ExecuteCommand();
        }
    }
}
