//
//  SDL_Keyboard_VSUnisystem.cs
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
    public class SDL_Keyboard_VSUnisystem:IVSUnisystemDIPConnecter
    {
        public SDL_Keyboard_VSUnisystem()
        {
            state = new KeyboardState();
            LoadSettings();
            NesEmu.EMUShutdown += NesEmu_EMUShutdown;
        }

        private Key CreditServiceButton = Key.Unknown;
        private Key DIPSwitch1 = Key.Unknown;
        private Key DIPSwitch2 = Key.Unknown;
        private Key DIPSwitch3 = Key.Unknown;
        private Key DIPSwitch4 = Key.Unknown;
        private Key DIPSwitch5 = Key.Unknown;
        private Key DIPSwitch6 = Key.Unknown;
        private Key DIPSwitch7 = Key.Unknown;
        private Key DIPSwitch8 = Key.Unknown;
        private Key CreditLeftCoinSlot = Key.Unknown;
        private bool leftCoin = false;
        private Key CreditRightCoinSlot = Key.Unknown;
        private bool rightCoin = false;
        private KeyboardState state;
        private byte data4016;
        private byte data4017;

        private void LoadSettings()
        {
            // Kill all
            CreditServiceButton = Key.Unknown;
            DIPSwitch1 = Key.Unknown;
            DIPSwitch2 = Key.Unknown;
            DIPSwitch3 = Key.Unknown;
            DIPSwitch4 = Key.Unknown;
            DIPSwitch5 = Key.Unknown;
            DIPSwitch6 = Key.Unknown;
            DIPSwitch7 = Key.Unknown;
            DIPSwitch8 = Key.Unknown;
            CreditLeftCoinSlot = Key.Unknown;
            CreditRightCoinSlot = Key.Unknown;

            Enum.TryParse<Key>(Settings.Key_VS_CreditServiceButton, out this.CreditServiceButton);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch1, out this.DIPSwitch1);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch2, out this.DIPSwitch2);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch3, out this.DIPSwitch3);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch4, out this.DIPSwitch4);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch5, out this.DIPSwitch5);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch6, out this.DIPSwitch6);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch7, out this.DIPSwitch7);
            Enum.TryParse<Key>(Settings.Key_VS_DIPSwitch8, out this.DIPSwitch8);
            Enum.TryParse<Key>(Settings.Key_VS_CreditLeftCoinSlot, out this.CreditLeftCoinSlot);
            Enum.TryParse<Key>(Settings.Key_VS_CreditRightCoinSlot, out this.CreditRightCoinSlot);  
        }

        private void NesEmu_EMUShutdown(object sender, EventArgs e)
        {
            leftCoin = false;
            rightCoin = false;
        }

        public override void Update()
        {
            state.Update();
            data4016 = 0;

            if (state.IsKeyPressed(CreditServiceButton))
                data4016 |= 0x04;
            if (state.IsKeyPressed(DIPSwitch1))
                data4016 |= 0x08;
            if (state.IsKeyPressed(DIPSwitch2))
                data4016 |= 0x10;
            if (state.IsKeyPressed(CreditLeftCoinSlot))
                leftCoin = true;
            if (leftCoin)
                data4016 |= 0x20;
            if (state.IsKeyPressed(CreditRightCoinSlot))
                rightCoin = true;
            if (rightCoin)
                data4016 |= 0x40;

            data4017 = 0;
            if (state.IsKeyPressed(DIPSwitch3))
                data4017 |= 0x04;
            if (state.IsKeyPressed(DIPSwitch4))
                data4017 |= 0x08;
            if (state.IsKeyPressed(DIPSwitch5))
                data4017 |= 0x10;
            if (state.IsKeyPressed(DIPSwitch6))
                data4017 |= 0x20;
            if (state.IsKeyPressed(DIPSwitch7))
                data4017 |= 0x40;
            if (state.IsKeyPressed(DIPSwitch8))
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
    }
}

