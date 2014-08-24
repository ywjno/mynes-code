﻿/* This file is part of My Nes
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
namespace MyNes.Core
{
    class Eprom
    {
        public Eprom(int memorySize)
        {
            Console.WriteLine("Initializing Eprom ...");
            data = new byte[memorySize];
            device = memorySize == 256 ? EpromDevice.X24C02 : EpromDevice.X24C01;
            Console.WriteLine("Eprom memory size = " + memorySize);
            Console.WriteLine("Eprom device = " + device);
        }
        private enum EpromDevice { X24C01, X24C02 }
        private enum EpromMode : int
        {
            Data = 0,
            Addressing = 1,
            Idle = 2,
            Read = 3,
            Write = 4,
            Ack = 5,
            NotAck = 6,
            AckWait = 7
        }

        private byte[] data;
        private EpromMode mode = EpromMode.Data;
        private EpromMode nextmode = EpromMode.Data;
        private EpromDevice device = EpromDevice.X24C01;
        private bool psda;
        private bool pscl;
        private int output = 0;
        private int cbit = 0;
        private int caddress = 0;
        private int cdata = 0;
        private bool isRead;
        private bool cSCL;
        private bool cSDA;

        public void HardReset()
        {
            pscl = false;
            psda = false;
            mode = EpromMode.Idle;
            nextmode = EpromMode.Idle;
            cbit = 0;
            caddress = 0;
            cdata = 0;
            isRead = false;
            output = 0x10;
        }
        public void Write(int address, byte data)
        {
            cSCL = (data & 0x20) == 0x20;
            cSDA = (data & 0x40) == 0x40;
            if (pscl && !cSDA & psda)
            {
                Start();
            }
            else if (pscl && cSDA & !psda)
            {
                Stop();
            }
            else if (cSCL & !pscl)
            {
                switch (device)
                {
                    case EpromDevice.X24C01: RiseX24C01((data >> 6) & 1); break;
                    case EpromDevice.X24C02: RiseX24C02((data >> 6) & 1); break;
                }
            }
            else if (!cSCL & pscl)
            {
                switch (device)
                {
                    case EpromDevice.X24C01: FallX24C01(); break;
                    case EpromDevice.X24C02: FallX24C02(); break;
                }
            }

            pscl = cSCL;
            psda = cSDA;
        }
        public byte Read(int address)
        {
            return (byte)output;
        }

        private void Start()
        {
            switch (device)
            {
                case EpromDevice.X24C01:
                    mode = EpromMode.Addressing;
                    cbit = 0;
                    caddress = 0;
                    output = 0x10;
                    break;
                case EpromDevice.X24C02:
                    mode = EpromMode.Data;
                    cbit = 0;
                    output = 0x10;
                    break;
            }
        }
        private void Stop()
        {
            mode = EpromMode.Idle;
            output = 0x10;
        }
        private void RiseX24C01(int bit)
        {
            switch (mode)
            {
                case EpromMode.Addressing:

                    if (cbit < 7)
                    {
                        caddress &= ~(1 << cbit);
                        caddress |= bit << cbit++;
                    }
                    else if (cbit < 8)
                    {
                        cbit = 8;

                        if (bit != 0)
                        {
                            nextmode = EpromMode.Read;
                            cdata = data[caddress];
                        }
                        else
                        {
                            nextmode = EpromMode.Write;
                        }
                    }
                    break;

                case EpromMode.Ack:

                    output = 0x00;
                    break;

                case EpromMode.Read:

                    if (cbit < 8)
                        output = (cdata & 1 << cbit++) != 0 ? 0x10 : 0x00;

                    break;

                case EpromMode.Write:

                    if (cbit < 8)
                    {
                        cdata &= ~(1 << cbit);
                        cdata |= bit << cbit++;
                    }
                    break;

                case EpromMode.AckWait:

                    if (bit == 0)
                        nextmode = EpromMode.Idle;

                    break;
            }
        }
        private void RiseX24C02(int bit)
        {
            switch (mode)
            {
                case EpromMode.Data:
                    if (cbit < 8)
                    {
                        cdata &= ~(1 << (7 - cbit));
                        cdata |= bit << (7 - cbit++);
                    }
                    break;
                case EpromMode.Addressing:
                    if (cbit < 8)
                    {
                        caddress &= ~(1 << (7 - cbit));
                        caddress |= bit << (7 - cbit++);
                    }
                    break;
                case EpromMode.Read:
                    if (cbit < 8)
                        output = (cdata & 1 << (7 - cbit++)) != 0 ? 0x10 : 0x00;
                    break;
                case EpromMode.Write:
                    if (cbit < 8)
                    {
                        cdata &= ~(1 << (7 - cbit));
                        cdata |= bit << (7 - cbit++);
                    }
                    break;
                case EpromMode.NotAck: output = 0x10; break;
                case EpromMode.Ack: output = 0x00; break;
                case EpromMode.AckWait:
                    if (bit == 0)
                    {
                        nextmode = EpromMode.Read;
                        cdata = data[caddress];
                    }
                    break;
            }
        }
        private void FallX24C01()
        {
            switch (mode)
            {
                case EpromMode.Addressing:

                    if (cbit == 8)
                    {
                        mode = EpromMode.Ack;
                        output = 0x10;
                    }
                    break;

                case EpromMode.Ack:

                    mode = nextmode;
                    cbit = 0;
                    output = 0x10;
                    break;

                case EpromMode.Read:

                    if (cbit == 8)
                    {
                        mode = EpromMode.AckWait;
                        caddress = (caddress + 1) & 0x7F;
                    }
                    break;

                case EpromMode.Write:

                    if (cbit == 8)
                    {
                        mode = EpromMode.Ack;
                        nextmode = EpromMode.Idle;
                        data[caddress] = (byte)cdata;
                        caddress = (caddress + 1) & 0x7F;
                    }
                    break;
            }
        }
        private void FallX24C02()
        {
            switch (mode)
            {
                case EpromMode.Data:

                    if (cbit == 8)
                    {
                        if ((cdata & 0xA0) == 0xA0)
                        {
                            cbit = 0;
                            mode = EpromMode.Ack;
                            isRead = (cdata & 0x01) == 1;
                            output = 0x10;

                            if (isRead)
                            {
                                nextmode = EpromMode.Read;
                                cdata = data[caddress];
                            }
                            else
                            {
                                nextmode = EpromMode.Addressing;
                            }
                        }
                        else
                        {
                            mode = EpromMode.NotAck;
                            nextmode = EpromMode.Idle;
                            output = 0x10;
                        }
                    }
                    break;

                case EpromMode.Addressing:

                    if (cbit == 8)
                    {
                        cbit = 0;
                        mode = EpromMode.Ack;
                        nextmode = (isRead ? EpromMode.Idle : EpromMode.Write);
                        output = 0x10;
                    }
                    break;

                case EpromMode.Read:

                    if (cbit == 8)
                    {
                        mode = EpromMode.AckWait;
                        caddress = (caddress + 1) & 0xFF;
                    }
                    break;

                case EpromMode.Write:

                    if (cbit == 8)
                    {
                        cbit = 0;
                        mode = EpromMode.Ack;
                        nextmode = EpromMode.Write;
                        data[caddress] = (byte)cdata;
                        caddress = (caddress + 1) & 0xFF;
                    }
                    break;

                case EpromMode.NotAck:

                    mode = EpromMode.Idle;
                    cbit = 0;
                    output = 0x10;
                    break;

                case EpromMode.Ack:
                case EpromMode.AckWait:

                    mode = nextmode;
                    cbit = 0;
                    output = 0x10;
                    break;
            }
        }

        public void SaveState(System.IO.BinaryWriter stream)
        {
            stream.Write(data);
            stream.Write((int)mode);
            stream.Write((int)nextmode);
            stream.Write(psda);
            stream.Write(pscl);
            stream.Write(output);
            stream.Write(cbit);
            stream.Write(caddress);
            stream.Write(cdata);
            stream.Write(isRead);
        }
        public void LoadState(System.IO.BinaryReader stream)
        {
            stream.Read(data, 0, data.Length);
            mode = (EpromMode)stream.ReadInt32();
            nextmode = (EpromMode)stream.ReadInt32();
            psda = stream.ReadBoolean();
            pscl = stream.ReadBoolean();
            output = stream.ReadInt32();
            cbit = stream.ReadInt32();
            caddress = stream.ReadInt32();
            cdata = stream.ReadInt32();
            isRead = stream.ReadBoolean();
        }
    }
}
