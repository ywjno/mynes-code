/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;
using MyNes.Core.IO.Input;

namespace MyNes.WinRenderers
{
    public class InputManager : IInputDevice
    {
        private IList<InputDevice> _devices;
        private MyNesShortcuts _shortcuts;

        public IList<InputDevice> Devices { get { return _devices; } }
        public MyNesShortcuts MyNesShortcuts { get { return _shortcuts; } }

        public InputManager(IntPtr handle)
        {
            _devices = new List<InputDevice>();
            _shortcuts = new MyNesShortcuts(this);
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
        public void UpdateEvents()
        {
            Update();
            _shortcuts.Update();
        }
    }
}
