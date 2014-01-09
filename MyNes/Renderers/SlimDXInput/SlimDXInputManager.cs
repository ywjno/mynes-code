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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SlimDX;
using SlimDX.DirectInput;
using MyNes.Core.IO;

namespace MyNes.Renderers
{
    public class SlimDXInputManager : IInputDevice
    {
        private IList<SlimDXInputDevice> _devices;

        public IList<SlimDXInputDevice> Devices { get { return _devices; } }

        public SlimDXInputManager(IntPtr handle)
        {
            _devices = new List<SlimDXInputDevice>();
            DirectInput di = new DirectInput();
            foreach (var device in di.GetDevices(DeviceClass.All, DeviceEnumerationFlags.AttachedOnly))
            {
                if ((device.Type & DeviceType.Keyboard) == DeviceType.Keyboard)
                {
                    Keyboard keyboard = new Keyboard(di);
                    keyboard.SetCooperativeLevel(handle, CooperativeLevel.Nonexclusive | CooperativeLevel.Foreground);
                    _devices.Add(new SlimDXInputDevice(keyboard));
                }
                else if ((device.Type & DeviceType.Joystick) == DeviceType.Joystick)
                {
                    Joystick joystick = new Joystick(di, device.InstanceGuid);
                    joystick.SetCooperativeLevel(handle, CooperativeLevel.Nonexclusive | CooperativeLevel.Foreground);
                    _devices.Add(new SlimDXInputDevice(joystick));
                }
            }
        }
        public override void Update()
        {
            for (int i = 0; i < _devices.Count; i++)
            {
                _devices[i].Update();
            }
        }
    }
}
