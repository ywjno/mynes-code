using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SlimDX;
using SlimDX.DirectInput;
using MyNes.Core.IO.Input;

namespace MyNes
{
    public partial class FormKey : Form
    {
        public FormKey()
        {
            InitializeComponent();
            _manager = new InputManager(Handle);
            timer1.Interval = 1000 / 30;
            timer1.Enabled = true;
            this.Select();
        }

        private InputManager _manager;
        private string _inputName;

        public string InputName { get { return _inputName; } }

        private void timer1_Tick(object sender, EventArgs e)
        {
            _manager.Update();

            for (int i = 0; i < _manager.Devices.Count; i++)
            {
                InputDevice device = _manager.Devices[i];

                bool pressed = false;

                if (device.Type == DeviceType.Keyboard)
                {
                    pressed = CheckInput(device.KeyboardState, i);
                }
                else if (device.Type == DeviceType.Joystick)
                {
                    pressed = CheckInput(device.JoystickState, i);
                }

                if (pressed)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    timer1.Enabled = false;
                    this.Close();
                    return;
                }
            }
        }
        bool CheckInput(KeyboardState state, int index)
        {
            if (state == null)
                return false;

            if (state.PressedKeys.Count > 0)
            {
                _inputName = "Keyboard." + state.PressedKeys[0].ToString();
                return true;
            }
            return false;
        }
        private bool CheckInput(JoystickState state, int index)
        {
            if (state == null)
                return false;

            bool[] buttons = state.GetButtons();
            for (int button = 0; button < buttons.Length; button++)
            {
                if (buttons[button])
                {
                    _inputName = "Joystick" + index + "." + button;
                    return true;
                }

                if (state.X > 0xC000)
                {
                    _inputName = "Joystick" + index + ".X+";
                    return true;
                }
                else if (state.X < 0x4000)
                {
                    _inputName = "Joystick" + index + ".X-";
                    return true;
                }
                else if (state.Y > 0xC000)
                {
                    _inputName = "Joystick" + index + ".Y+";
                    return true;
                }
                else if (state.Y < 0x4000)
                {
                    _inputName = "Joystick" + index + ".Y-";
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
