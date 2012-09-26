/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
using MyNes.Core.IO.Input;
namespace MyNes
{
   public  class VSUnisystemDIP : IVSunisystemDIP
   {
       private JoyButton[] _buttons;

       public JoyButton CreditServiceButton { get { return _buttons[0]; } }
       public JoyButton DIPSwitch1 { get { return _buttons[1]; } }
       public JoyButton DIPSwitch2 { get { return _buttons[2]; } }
       public JoyButton DIPSwitch3 { get { return _buttons[3]; } }
       public JoyButton DIPSwitch4 { get { return _buttons[4]; } }
       public JoyButton DIPSwitch5 { get { return _buttons[5]; } }
       public JoyButton DIPSwitch6 { get { return _buttons[6]; } }
       public JoyButton DIPSwitch7 { get { return _buttons[7]; } }
       public JoyButton DIPSwitch8 { get { return _buttons[8]; } }
       public JoyButton CreditLeftCoinSlot { get { return _buttons[9]; } }
       public JoyButton CreditRightCoinSlot { get { return _buttons[10]; } }

       public VSUnisystemDIP(InputManager manager)
       {
           _buttons = new JoyButton[11];
           for (int i = 0; i < 11; i++)
           {
               _buttons[i] = new JoyButton(manager);
           }
       }

       public byte GetData4016()
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
       public byte GetData4017()
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
