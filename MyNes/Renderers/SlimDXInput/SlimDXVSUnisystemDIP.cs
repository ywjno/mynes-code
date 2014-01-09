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
using MyNes.Core.IO;

namespace MyNes.Renderers
{
   public  class SlimDXVSUnisystemDIP : IVSunisystemDIP
   {
       private SlimDXJoyButton[] _buttons;

       public SlimDXJoyButton CreditServiceButton { get { return _buttons[0]; } }
       public SlimDXJoyButton DIPSwitch1 { get { return _buttons[1]; } }
       public SlimDXJoyButton DIPSwitch2 { get { return _buttons[2]; } }
       public SlimDXJoyButton DIPSwitch3 { get { return _buttons[3]; } }
       public SlimDXJoyButton DIPSwitch4 { get { return _buttons[4]; } }
       public SlimDXJoyButton DIPSwitch5 { get { return _buttons[5]; } }
       public SlimDXJoyButton DIPSwitch6 { get { return _buttons[6]; } }
       public SlimDXJoyButton DIPSwitch7 { get { return _buttons[7]; } }
       public SlimDXJoyButton DIPSwitch8 { get { return _buttons[8]; } }
       public SlimDXJoyButton CreditLeftCoinSlot { get { return _buttons[9]; } }
       public SlimDXJoyButton CreditRightCoinSlot { get { return _buttons[10]; } }

       public SlimDXVSUnisystemDIP(SlimDXInputManager manager)
       {
           _buttons = new SlimDXJoyButton[11];
           for (int i = 0; i < 11; i++)
           {
               _buttons[i] = new SlimDXJoyButton(manager);
           }
       }

       public override byte GetData4016()
       {
           byte data = 0;
           if (CreditServiceButton.IsPressed())
               data |= 0x04;
           if (DIPSwitch1.IsPressed())
               data |= 0x08;
           if (DIPSwitch2.IsPressed())
               data |= 0x10;
           if (CreditLeftCoinSlot.IsPressed())
               data |= 0x20;
           if (CreditRightCoinSlot.IsPressed())
               data |= 0x40;
           return data;
       }
       public override byte GetData4017()
       {
           byte data = 0;
           if (DIPSwitch3.IsPressed())
               data |= 0x04;
           if (DIPSwitch4.IsPressed())
               data |= 0x08;
           if (DIPSwitch5.IsPressed())
               data |= 0x10;
           if (DIPSwitch6.IsPressed())
               data |= 0x20;
           if (DIPSwitch7.IsPressed())
               data |= 0x40;
           if (DIPSwitch8.IsPressed())
               data |= 0x80;
           return data;
       }
    }
}
