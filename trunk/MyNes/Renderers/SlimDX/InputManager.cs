using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;
using myNES.Core.IO.Input;

namespace myNES
{
    public class InputManager : IInputDevice
    {
        private IList<InputDevice> _devices;

        public IList<InputDevice> Devices { get { return _devices; } }

        public InputManager(IntPtr handle)
        {
            _devices = new List<InputDevice>();
            DirectInput di = new DirectInput();
            foreach (var device in di.GetDevices(DeviceClass.All, DeviceEnumerationFlags.AttachedOnly))
            {
                if ((device.Type & DeviceType.Keyboard) == DeviceType.Keyboard)
                {
                    Keyboard keyboard = new Keyboard(di);
                    keyboard.SetCooperativeLevel(handle, CooperativeLevel.Nonexclusive | CooperativeLevel.Foreground);
                    _devices.Add(new InputDevice(keyboard));
                }
                else if ((device.Type & DeviceType.Joystick) == DeviceType.Joystick)
                {
                    Joystick joystick = new Joystick(di, device.InstanceGuid);
                    joystick.SetCooperativeLevel(handle, CooperativeLevel.Nonexclusive | CooperativeLevel.Foreground);
                    _devices.Add(new InputDevice(joystick));
                }
            }
        }
        public void Update()
        {
            for (int i = 0; i < _devices.Count; i++)
            {
                _devices[i].Update();
            }
        }
    }
}
