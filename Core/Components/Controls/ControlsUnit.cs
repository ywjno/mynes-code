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

namespace MyNes.Core.Controls
{
    /// <summary>
    /// Represents controls unit.
    /// </summary>
    public class ControlsUnit : INesComponent
    {
        private uint inputData1;
        private uint inputData2;
        private byte inputData3;
        private byte inputData4;
        private byte inputStrobe;
        public IInputDevice InputDevice;
        public IJoypad Joypad1;
        public IJoypad Joypad2;
        public IJoypad Joypad3;
        public IJoypad Joypad4;
        public IZapper Zapper;
        public IVSunisystemDIP VSunisystemDIP;
        private bool isVsunisystem = false;
        public bool IsZapperConnected = false;
        public bool IsFourPlayers = true;

        public byte Read4016()
        {
            byte data = (byte)(inputData1 & 1);
            inputData1 >>= 1;
            data |= (byte)((inputData3 & 1) << 1);
            inputData3 >>= 1;

            if (isVsunisystem)
            {
                data |= VSunisystemDIP.GetData4016();
            }

            return data;
        }
        public byte Read4017()
        {
            byte data = (byte)(inputData2 & 1);
            inputData2 >>= 1;
            data |= (byte)((inputData4 & 1) << 1);
            inputData4 >>= 1;
            //zapper (is it possible to connect both zapper and vsunisystem ?)
            if (IsZapperConnected)
            {
                data |= (byte)(Zapper.LightDetected ? 0x08 : 0);
                data |= (byte)(Zapper.Trigger ? 0x10 : 0);
            }
            if (isVsunisystem)
            {
                data |= VSunisystemDIP.GetData4017();
            }

            return data;
        }
        public void Write4016(byte data)
        {
            if (inputStrobe > (data & 0x01))
            {
                InputDevice.Update();
                if (IsFourPlayers)
                {
                    inputData1 = (uint)(Joypad1.GetData() | (Joypad3.GetData() << 8) | 0x00080000);
                    inputData2 = (uint)(Joypad2.GetData() | (Joypad4.GetData() << 8) | 0x00040000);
                }
                else
                {
                    inputData1 = (uint)Joypad1.GetData();
                    inputData2 = (uint)Joypad2.GetData();
                }
            }

            inputStrobe = (byte)(data & 0x01);

            if (isVsunisystem)
            {
                NesCore.BOARD.Switch08kCHR(((data & 0x4) >> 2));
            }
        }
        /// <summary>
        /// Call this at the end of a frame
        /// </summary>
        public void FinishFrame()
        {
            Joypad1.Turbo = !Joypad1.Turbo;
            Joypad2.Turbo = !Joypad2.Turbo;
            if (IsFourPlayers)
            {
                Joypad3.Turbo = !Joypad3.Turbo;
                Joypad4.Turbo = !Joypad4.Turbo;
            }
        }
        public override void HardReset()
        {
            base.HardReset();
            inputData1 = 0;
            inputData2 = 0;
            inputData3 = 0;
            inputData4 = 0;
            inputStrobe = 0;
        }
        public override void SoftReset()
        {
            base.SoftReset();
            inputData1 = 0;
            inputData2 = 0;
            inputData3 = 0;
            inputData4 = 0;
            inputStrobe = 0;
        }

        public override void SaveState(State.SaveStateStream stream)
        {
            base.SaveState(stream);
            stream.Write(inputData1);
            stream.Write(inputData2);
            stream.Write(inputData3);
            stream.Write(inputData4);
            stream.Write(inputStrobe);
        }
        public override void LoadState(State.ReadStateStream stream)
        {
            base.LoadState(stream);
            inputData1 = stream.ReadUInt32();
            inputData2 = stream.ReadUInt32();
            inputData3 = stream.ReadByte();
            inputData4 = stream.ReadByte();
            inputStrobe = stream.ReadByte();
        }
    }
}
