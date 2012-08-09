using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;

namespace myNES
{
    public class InputDevice
    {
        private Device _device;
        private DeviceType _type;
        private KeyboardState _keyboardState;
        private JoystickState _joystickState;

        public DeviceType Type { get { return _type; } }
        public KeyboardState KeyboardState { get { return _keyboardState; } }
        public JoystickState JoystickState { get { return _joystickState; } }

        public InputDevice(Device device)
        {
            _device = device;
            if ((device.Information.Type & DeviceType.Keyboard) == DeviceType.Keyboard)
                _type = DeviceType.Keyboard;
            else if ((device.Information.Type & DeviceType.Joystick) == DeviceType.Joystick)
                _type = DeviceType.Joystick;
            else
                _type = DeviceType.Other;
        }

        public void Update()
        {
            if (_device.Acquire().IsFailure)
                return;

            if (_device.Poll().IsFailure)
                return;

            if (_device.Acquire().IsSuccess)
            {
                if (_type == DeviceType.Keyboard)
                    _keyboardState = ((Keyboard)_device).GetCurrentState();
                else if (_type == DeviceType.Joystick)
                    _joystickState = ((Joystick)_device).GetCurrentState();
            }
        }
    }
}
