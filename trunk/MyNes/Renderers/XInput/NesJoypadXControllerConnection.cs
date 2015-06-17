/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2015
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
using MyNes.Core;
using SlimDX;
using SlimDX.XInput;

namespace MyNes
{
    class NesJoypadXControllerConnection : IJoypadConnecter
    {
        public NesJoypadXControllerConnection(string guid, IInputSettingsJoypad settings)
        {
            switch (guid)
            {
                case "x-controller-1": x_controller = new Controller(UserIndex.One); break;
                case "x-controller-2": x_controller = new Controller(UserIndex.Two); break;
                case "x-controller-3": x_controller = new Controller(UserIndex.Three); break;
                case "x-controller-4": x_controller = new Controller(UserIndex.Four); break;
            }
            if (settings.ButtonUp != "")
                KeyUp = ParseKey(settings.ButtonUp);
            if (settings.ButtonDown != "")
                KeyDown = ParseKey(settings.ButtonDown);
            if (settings.ButtonLeft != "")
                KeyLeft = ParseKey(settings.ButtonLeft);
            if (settings.ButtonRight != "")
                KeyRight = ParseKey(settings.ButtonRight);
            if (settings.ButtonStart != "")
                KeyStart = ParseKey(settings.ButtonStart);
            if (settings.ButtonSelect != "")
                KeySelect = ParseKey(settings.ButtonSelect);
            if (settings.ButtonA != "")
                KeyA = ParseKey(settings.ButtonA);
            if (settings.ButtonB != "")
                KeyB = ParseKey(settings.ButtonB);
            if (settings.ButtonTurboA != "")
                KeyTurboA = ParseKey(settings.ButtonTurboA);
            if (settings.ButtonTurboB != "")
                KeyTurboB = ParseKey(settings.ButtonTurboB);
        }
        private Controller x_controller;
        private int KeyUp = 0;
        private int KeyDown = 0;
        private int KeyLeft = 0;
        private int KeyRight = 0;
        private int KeyStart = 0;
        private int KeySelect = 0;
        private int KeyA = 0;
        private int KeyB = 0;
        private int KeyTurboA = 0;
        private int KeyTurboB = 0;
        private bool turbo;
        public override void Update()
        {
            turbo = !turbo;
            if (x_controller.GetState().Gamepad.Buttons != GamepadButtonFlags.None)
            {
                DATA = 0;

                if (IsPressed(KeyA))
                    DATA |= 1;

                if (IsPressed(KeyB))
                    DATA |= 2;

                if (IsPressed(KeyTurboA) && turbo)
                    DATA |= 1;

                if (IsPressed(KeyTurboB) && turbo)
                    DATA |= 2;

                if (IsPressed(KeySelect))
                    DATA |= 4;

                if (IsPressed(KeyStart))
                    DATA |= 8;

                if (IsPressed(KeyUp))
                    DATA |= 0x10;

                if (IsPressed(KeyDown))
                    DATA |= 0x20;

                if (IsPressed(KeyLeft))
                    DATA |= 0x40;

                if (IsPressed(KeyRight))
                    DATA |= 0x80;
            }
        }
        private bool IsPressed(int key)
        {
            GamepadButtonFlags k = (GamepadButtonFlags)key;
            return (x_controller.GetState().Gamepad.Buttons & k) == k;
        }
        private int ParseKey(string key)
        {
            if (key.Contains(GamepadButtonFlags.A.ToString()))
                return (int)GamepadButtonFlags.A;
            if (key.Contains(GamepadButtonFlags.B.ToString()))
                return (int)GamepadButtonFlags.B;
            if (key.Contains(GamepadButtonFlags.Back.ToString()))
                return (int)GamepadButtonFlags.Back;
            if (key.Contains(GamepadButtonFlags.DPadDown.ToString()))
                return (int)GamepadButtonFlags.DPadDown;
            if (key.Contains(GamepadButtonFlags.DPadLeft.ToString()))
                return (int)GamepadButtonFlags.DPadLeft;
            if (key.Contains(GamepadButtonFlags.DPadRight.ToString()))
                return (int)GamepadButtonFlags.DPadRight;
            if (key.Contains(GamepadButtonFlags.DPadUp.ToString()))
                return (int)GamepadButtonFlags.DPadUp;
            if (key.Contains(GamepadButtonFlags.LeftShoulder.ToString()))
                return (int)GamepadButtonFlags.LeftShoulder;
            if (key.Contains(GamepadButtonFlags.LeftThumb.ToString()))
                return (int)GamepadButtonFlags.LeftThumb;
            if (key.Contains(GamepadButtonFlags.RightShoulder.ToString()))
                return (int)GamepadButtonFlags.RightShoulder;
            if (key.Contains(GamepadButtonFlags.RightThumb.ToString()))
                return (int)GamepadButtonFlags.RightThumb;
            if (key.Contains(GamepadButtonFlags.Start.ToString()))
                return (int)GamepadButtonFlags.Start;
            if (key.Contains(GamepadButtonFlags.X.ToString()))
                return (int)GamepadButtonFlags.X;
            if (key.Contains(GamepadButtonFlags.Y.ToString()))
                return (int)GamepadButtonFlags.Y;
            return 0;
        }
    }
}
