//
//  SDL_Joystick_Joypad.cs
//
//  Author:
//       Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>
//
//  Copyright (c) 2009 - 2015 Ala Ibrahim Hadid
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using MyNes.Core;
using SdlDotNet.Input;
using SdlDotNet.Core;

namespace MyNesSDL
{
    public class SDL_Joystick_Joypad : IJoypadConnecter
    {
        public SDL_Joystick_Joypad(int joystickIndex, int playerIndex)
        {
            this.playerIndex = playerIndex; 
            LoadSettings();
            state = Joysticks.OpenJoystick(joystickIndex);
        }

        private int playerIndex;
        private Joystick state;
        private bool turbo;
        public string A;
        public string B;
        public string TurboA;
        public string TurboB;
        public string Start;
        public string Select;
        public string Up;
        public string Down;
        public string Left;
        public string Right;

        private void LoadSettings()
        {
            // Kill all
            this.A = "";
            this.B = "";
            this.TurboA = "";
            this.TurboB = "";
            this.Start = "";
            this.Select = "";
            this.Up = "";
            this.Down = "";
            this.Left = "";
            this.Right = "";

            switch (playerIndex)
            {
                case 0:
                    {
                        this.A = Settings.JoyKey_P1_ButtonA;
                        this.B = Settings.JoyKey_P1_ButtonB;
                        this.TurboA = Settings.JoyKey_P1_ButtonTurboA;
                        this.TurboB = Settings.JoyKey_P1_ButtonTurboB;
                        this.Start = Settings.JoyKey_P1_ButtonStart;
                        this.Select = Settings.JoyKey_P1_ButtonSelect;
                        this.Up = Settings.JoyKey_P1_ButtonUp;
                        this.Down = Settings.JoyKey_P1_ButtonDown;
                        this.Left = Settings.JoyKey_P1_ButtonLeft;
                        this.Right = Settings.JoyKey_P1_ButtonRight;
                        break;
                    }
                case 1:
                    {
                        this.A = Settings.JoyKey_P2_ButtonA;
                        this.B = Settings.JoyKey_P2_ButtonB;
                        this.TurboA = Settings.JoyKey_P2_ButtonTurboA;
                        this.TurboB = Settings.JoyKey_P2_ButtonTurboB;
                        this.Start = Settings.JoyKey_P2_ButtonStart;
                        this.Select = Settings.JoyKey_P2_ButtonSelect;
                        this.Up = Settings.JoyKey_P2_ButtonUp;
                        this.Down = Settings.JoyKey_P2_ButtonDown;
                        this.Left = Settings.JoyKey_P2_ButtonLeft;
                        this.Right = Settings.JoyKey_P2_ButtonRight;
                        break;
                    }
                case 2:
                    {
                        this.A = Settings.JoyKey_P3_ButtonA;
                        this.B = Settings.JoyKey_P3_ButtonB;
                        this.TurboA = Settings.JoyKey_P3_ButtonTurboA;
                        this.TurboB = Settings.JoyKey_P3_ButtonTurboB;
                        this.Start = Settings.JoyKey_P3_ButtonStart;
                        this.Select = Settings.JoyKey_P3_ButtonSelect;
                        this.Up = Settings.JoyKey_P3_ButtonUp;
                        this.Down = Settings.JoyKey_P3_ButtonDown;
                        this.Left = Settings.JoyKey_P3_ButtonLeft;
                        this.Right = Settings.JoyKey_P3_ButtonRight;
                        break;
                    }
                case 3:
                    {
                        this.A = Settings.JoyKey_P4_ButtonA;
                        this.B = Settings.JoyKey_P4_ButtonB;
                        this.TurboA = Settings.JoyKey_P4_ButtonTurboA;
                        this.TurboB = Settings.JoyKey_P4_ButtonTurboB;
                        this.Start = Settings.JoyKey_P4_ButtonStart;
                        this.Select = Settings.JoyKey_P4_ButtonSelect;
                        this.Up = Settings.JoyKey_P4_ButtonUp;
                        this.Down = Settings.JoyKey_P4_ButtonDown;
                        this.Left = Settings.JoyKey_P4_ButtonLeft;
                        this.Right = Settings.JoyKey_P4_ButtonRight;
                        break;
                    }
            }
        }

        public override void Update()
        {
            turbo = !turbo;

            DATA = 0;

            if (IsButtonPressed(A))
                DATA |= 1;

            if (IsButtonPressed(B))
                DATA |= 2;

            if (IsButtonPressed(TurboA) && turbo)
                DATA |= 1;

            if (IsButtonPressed(TurboB) && turbo)
                DATA |= 2;

            if (IsButtonPressed(Select))
                DATA |= 4;

            if (IsButtonPressed(Start))
                DATA |= 8;

            if (IsButtonPressed(Up))
                DATA |= 0x10;

            if (IsButtonPressed(Down))
                DATA |= 0x20;

            if (IsButtonPressed(Left))
                DATA |= 0x40;

            if (IsButtonPressed(Right))
                DATA |= 0x80;
        }

        private bool IsButtonPressed(string button)
        {
            if (button == "+X")
            {
                return state.GetAxisPosition(JoystickAxis.Horizontal) == 1;
            }
            else if (button == "-X")
            {
                return state.GetAxisPosition(JoystickAxis.Horizontal) == 0;
            }
            else if (button == "+Y")
            {
                return state.GetAxisPosition(JoystickAxis.Vertical) == 1;
            }
            else if (button == "-Y")
            {
                return state.GetAxisPosition(JoystickAxis.Vertical) == 0;
            }
            else
            {
                int value = -1;
                if (int.TryParse(button, out value))
                    return state.GetButtonState(value) == ButtonKeyState.Pressed;
            }
            return false;
        }
    }
}

