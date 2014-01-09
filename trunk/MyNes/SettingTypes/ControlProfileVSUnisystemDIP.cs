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
namespace MyNes
{
    [System.Serializable()]
    public class ControlProfileVSUnisystemDIP
    {
        private string _CreditServiceButton;
        private string _DIPSwitch1;
        private string _DIPSwitch2;
        private string _DIPSwitch3;
        private string _DIPSwitch4;
        private string _DIPSwitch5;
        private string _DIPSwitch6;
        private string _DIPSwitch7;
        private string _DIPSwitch8;
        private string _CreditLeftCoinSlot;
        private string _CreditRightCoinSlot;

        public string CreditServiceButton { get { return _CreditServiceButton; } set { _CreditServiceButton = value; } }
        public string DIPSwitch1 { get { return _DIPSwitch1; } set { _DIPSwitch1 = value; } }
        public string DIPSwitch2 { get { return _DIPSwitch2; } set { _DIPSwitch2 = value; } }
        public string DIPSwitch3 { get { return _DIPSwitch3; } set { _DIPSwitch3 = value; } }
        public string DIPSwitch4 { get { return _DIPSwitch4; } set { _DIPSwitch4 = value; } }
        public string DIPSwitch5 { get { return _DIPSwitch5; } set { _DIPSwitch5 = value; } }
        public string DIPSwitch6 { get { return _DIPSwitch6; } set { _DIPSwitch6 = value; } }
        public string DIPSwitch7 { get { return _DIPSwitch7; } set { _DIPSwitch7 = value; } }
        public string DIPSwitch8 { get { return _DIPSwitch8; } set { _DIPSwitch8 = value; } }
        public string CreditLeftCoinSlot { get { return _CreditLeftCoinSlot; } set { _CreditLeftCoinSlot = value; } }
        public string CreditRightCoinSlot { get { return _CreditRightCoinSlot; } set { _CreditRightCoinSlot = value; } }
    }
}
