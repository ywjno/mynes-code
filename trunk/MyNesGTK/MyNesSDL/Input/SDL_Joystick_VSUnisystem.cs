//
//  SDL_Joystick_VSUnisystem.cs
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
    public class SDL_Joystick_VSUnisystem:IVSUnisystemDIPConnecter
    {
        public SDL_Joystick_VSUnisystem(int joystickIndex)
        {
            state = Joysticks.OpenJoystick(joystickIndex);
            LoadSettings();
            NesEmu.EMUShutdown += NesEmu_EMUShutdown;
        }

        private string CreditServiceButton;
        private string DIPSwitch1;
        private string DIPSwitch2;
        private string DIPSwitch3;
        private string DIPSwitch4;
        private string DIPSwitch5;
        private string DIPSwitch6;
        private string DIPSwitch7;
        private string DIPSwitch8;
        private string CreditLeftCoinSlot;
        private bool leftCoin = false;
        private string CreditRightCoinSlot;
        private bool rightCoin = false;
        private Joystick state;
        private byte data4016;
        private byte data4017;

        private void LoadSettings()
        {
            // Kill all
            CreditServiceButton = "";
            DIPSwitch1 = "";
            DIPSwitch2 = "";
            DIPSwitch3 = "";
            DIPSwitch4 = "";
            DIPSwitch5 = "";
            DIPSwitch6 = "";
            DIPSwitch7 = "";
            DIPSwitch8 = "";
            CreditLeftCoinSlot = "";
            CreditRightCoinSlot = "";

            this.CreditServiceButton = Settings.JoyKey_VS_CreditServiceButton;
            this.DIPSwitch1 = Settings.JoyKey_VS_DIPSwitch1;
            this.DIPSwitch2 = Settings.JoyKey_VS_DIPSwitch2;
            this.DIPSwitch3 = Settings.JoyKey_VS_DIPSwitch3;
            this.DIPSwitch4 = Settings.JoyKey_VS_DIPSwitch4;
            this.DIPSwitch5 = Settings.JoyKey_VS_DIPSwitch5;
            this.DIPSwitch6 = Settings.JoyKey_VS_DIPSwitch6;
            this.DIPSwitch7 = Settings.JoyKey_VS_DIPSwitch7;
            this.DIPSwitch8 = Settings.JoyKey_VS_DIPSwitch8;
            this.CreditLeftCoinSlot = Settings.JoyKey_VS_CreditLeftCoinSlot;
            this.CreditRightCoinSlot = Settings.JoyKey_VS_CreditRightCoinSlot;  
        }

        private void NesEmu_EMUShutdown(object sender, EventArgs e)
        {
            leftCoin = false;
            rightCoin = false;
        }

        public override void Update()
        {
            data4016 = 0;

            if (IsButtonPressed(CreditServiceButton))
                data4016 |= 0x04;
            if (IsButtonPressed(DIPSwitch1))
                data4016 |= 0x08;
            if (IsButtonPressed(DIPSwitch2))
                data4016 |= 0x10;
            if (IsButtonPressed(CreditLeftCoinSlot))
                leftCoin = true;
            if (leftCoin)
                data4016 |= 0x20;
            if (IsButtonPressed(CreditRightCoinSlot))
                rightCoin = true;
            if (rightCoin)
                data4016 |= 0x40;

            data4017 = 0;
            if (IsButtonPressed(DIPSwitch3))
                data4017 |= 0x04;
            if (IsButtonPressed(DIPSwitch4))
                data4017 |= 0x08;
            if (IsButtonPressed(DIPSwitch5))
                data4017 |= 0x10;
            if (IsButtonPressed(DIPSwitch6))
                data4017 |= 0x20;
            if (IsButtonPressed(DIPSwitch7))
                data4017 |= 0x40;
            if (IsButtonPressed(DIPSwitch8))
                data4017 |= 0x80;

        }

        public override byte GetData4016()
        {
            return data4016;
        }

        public override byte GetData4017()
        {
            return data4017;
        }

        public override void Write4020(ref byte data)
        {
            if ((data & 0x1) == 0x1)
            {
                leftCoin = false;
                rightCoin = false;
            }
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

