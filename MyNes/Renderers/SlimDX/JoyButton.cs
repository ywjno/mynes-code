using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;
using myNES.Core.IO.Input;
namespace myNES
{
    public class JoyButton
    {
        private InputManager _manager;
        private int _device;
        private int _code;
        private string _input;

        public string Input
        {
            get
            {
                return _input;
            }
            set
            {
                _input = value;
                if (_input.StartsWith("Keyboard"))
                {
                    string keyName = _input.Substring(9, _input.Length - 9);
                    _device = 0;
                    _code = (int)Enum.Parse(typeof(Key), keyName);
                }
                else if (_input.StartsWith("Joystick"))
                {
                    string buttonNumber = _input.Substring(10, _input.Length - 10);
                    _device = Convert.ToInt32(_input.Substring(8, 1));

                    if (buttonNumber == "X+")
                        _code = -1;
                    else if (buttonNumber == "X-")
                        _code = -2;
                    else if (buttonNumber == "Y+")
                        _code = -3;
                    else if (buttonNumber == "Y-")
                        _code = -4;
                    else
                        _code = Convert.ToInt32(buttonNumber);
                }
            }
        }

        public JoyButton(InputManager manager)
        {
            _manager = manager;
        }

        public bool IsPressed()
        {
            if (_device >= _manager.Devices.Count)
            { return false; }

            InputDevice device = _manager.Devices[_device];

            if (device.Type == DeviceType.Keyboard)
            {
                if (device.KeyboardState != null)
                    return device.KeyboardState.IsPressed((Key)_code);
            }
            else if (device.Type == DeviceType.Joystick)
            {
                if (_code < 0)
                {
                    if (_code == -1)
                        return device.JoystickState.X > 0xC000;
                    else if (_code == -2)
                        return device.JoystickState.X < 0x4000;
                    else if (_code == -3)
                        return device.JoystickState.Y > 0xC000;
                    else if (_code == -4)
                        return device.JoystickState.Y < 0x4000;
                }
                else
                {
                    return device.JoystickState.IsPressed(_code);
                }
            }

            return false;
        }
    }
}
