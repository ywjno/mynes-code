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
namespace MyNes.Core.PPU
{
    public partial class PPU2C02 : IProcesserBase
    {
        private static byte[] reverseLookup =
        {
            0x00, 0x80, 0x40, 0xC0, 0x20, 0xA0, 0x60, 0xE0, 0x10, 0x90, 0x50, 0xD0, 0x30, 0xB0, 0x70, 0xF0,
            0x08, 0x88, 0x48, 0xC8, 0x28, 0xA8, 0x68, 0xE8, 0x18, 0x98, 0x58, 0xD8, 0x38, 0xB8, 0x78, 0xF8,
            0x04, 0x84, 0x44, 0xC4, 0x24, 0xA4, 0x64, 0xE4, 0x14, 0x94, 0x54, 0xD4, 0x34, 0xB4, 0x74, 0xF4,
            0x0C, 0x8C, 0x4C, 0xCC, 0x2C, 0xAC, 0x6C, 0xEC, 0x1C, 0x9C, 0x5C, 0xDC, 0x3C, 0xBC, 0x7C, 0xFC,
            0x02, 0x82, 0x42, 0xC2, 0x22, 0xA2, 0x62, 0xE2, 0x12, 0x92, 0x52, 0xD2, 0x32, 0xB2, 0x72, 0xF2,
            0x0A, 0x8A, 0x4A, 0xCA, 0x2A, 0xAA, 0x6A, 0xEA, 0x1A, 0x9A, 0x5A, 0xDA, 0x3A, 0xBA, 0x7A, 0xFA,
            0x06, 0x86, 0x46, 0xC6, 0x26, 0xA6, 0x66, 0xE6, 0x16, 0x96, 0x56, 0xD6, 0x36, 0xB6, 0x76, 0xF6,
            0x0E, 0x8E, 0x4E, 0xCE, 0x2E, 0xAE, 0x6E, 0xEE, 0x1E, 0x9E, 0x5E, 0xDE, 0x3E, 0xBE, 0x7E, 0xFE,
            0x01, 0x81, 0x41, 0xC1, 0x21, 0xA1, 0x61, 0xE1, 0x11, 0x91, 0x51, 0xD1, 0x31, 0xB1, 0x71, 0xF1,
            0x09, 0x89, 0x49, 0xC9, 0x29, 0xA9, 0x69, 0xE9, 0x19, 0x99, 0x59, 0xD9, 0x39, 0xB9, 0x79, 0xF9,
            0x05, 0x85, 0x45, 0xC5, 0x25, 0xA5, 0x65, 0xE5, 0x15, 0x95, 0x55, 0xD5, 0x35, 0xB5, 0x75, 0xF5,
            0x0D, 0x8D, 0x4D, 0xCD, 0x2D, 0xAD, 0x6D, 0xED, 0x1D, 0x9D, 0x5D, 0xDD, 0x3D, 0xBD, 0x7D, 0xFD,
            0x03, 0x83, 0x43, 0xC3, 0x23, 0xA3, 0x63, 0xE3, 0x13, 0x93, 0x53, 0xD3, 0x33, 0xB3, 0x73, 0xF3,
            0x0B, 0x8B, 0x4B, 0xCB, 0x2B, 0xAB, 0x6B, 0xEB, 0x1B, 0x9B, 0x5B, 0xDB, 0x3B, 0xBB, 0x7B, 0xFB,
            0x07, 0x87, 0x47, 0xC7, 0x27, 0xA7, 0x67, 0xE7, 0x17, 0x97, 0x57, 0xD7, 0x37, 0xB7, 0x77, 0xF7,
            0x0F, 0x8F, 0x4F, 0xCF, 0x2F, 0xAF, 0x6F, 0xEF, 0x1F, 0x9F, 0x5F, 0xDF, 0x3F, 0xBF, 0x7F, 0xFF,
        };
        private int[] paletteIndexes =
        {
            0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F,
            0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16, 0x17, 0x18, 0x19, 0x1A, 0x1B, 0x1C, 0x1D, 0x1E, 0x1F,
            0x20, 0x21, 0x22, 0x23, 0x24, 0x25, 0x26, 0x27, 0x28, 0x29, 0x2A, 0x2B, 0x2C, 0x2D, 0x2E, 0x2F,
            0x30, 0x31, 0x32, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x3A, 0x3B, 0x3C, 0x3D, 0x3E, 0x3F,
            0x40, 0x41, 0x42, 0x43, 0x44, 0x45, 0x46, 0x47, 0x48, 0x49, 0x4A, 0x4B, 0x4C, 0x4D, 0x4E, 0x4F,
            0x50, 0x51, 0x52, 0x53, 0x54, 0x55, 0x56, 0x57, 0x58, 0x59, 0x5A, 0x5B, 0x5C, 0x5D, 0x5E, 0x5F,
            0x60, 0x61, 0x62, 0x63, 0x64, 0x65, 0x66, 0x67, 0x68, 0x69, 0x6A, 0x6B, 0x6C, 0x6D, 0x6E, 0x6F,
            0x70, 0x71, 0x72, 0x73, 0x74, 0x75, 0x76, 0x77, 0x78, 0x79, 0x7A, 0x7B, 0x7C, 0x7D, 0x7E, 0x7F,
        };
        struct Sprite
        {
            public Sprite(byte y, byte name, byte attr, byte x, bool zero)
            {
                this.y = y;
                this.x = x;
                this.name = name;
                this.attr = attr;
                this.zero = zero;
            }
            public byte y;
            public byte name;
            public byte attr;
            public byte x;
            public bool zero;

            public static Sprite Empty { get { return new Sprite(0, 0, 0, 0, false); } }
        }
        // Frame Timing
        private int vbl_vclock_Start = 241;
        private int vbl_vclock_End = 261;
        private int frameEnd = 262;
        private int VClock;
        private int HClock;
        private bool UseOddFrame = true;
        private bool oddSwap;
        // Screen oam_buffer
        private int[] screen = new int[256 * 240];
        private int[] palette;
        private int[] bkg_pixels;
        private int[] spr_pixels;
        private int bkg_fetch_address;
        private byte bkg_fetch_nametable;
        private byte bkg_fetch_attr;
        private byte bkg_fetch_bit0;
        private byte bkg_fetch_bit1;
        private int spr_fetch_address;
        private byte spr_fetch_bit0;
        private byte spr_fetch_bit1;
        private byte spr_fetch_attr;
        // oam_ram
        private byte[] oam_ram;// Accessed via $2004
        private Sprite[] oam_secondary;// The secondary oam...
        private byte oam_address;
        private int oam_dmaAddress;
        private byte oam_fetch_data;

        private byte oam_evaluate_slot;// current sprite that evaluated 
        private byte oam_evaluate_count;// How many sprites evaluated
        private Action oam_dofetch;
        private Action oam_dophase;

        public override void Clock()
        {
            NesCore.BOARD.OnPPUClock();
            if (VClock < 240 || VClock == vbl_vclock_End)
            {
                if (IsRenderingOn())
                {
                    if (HClock < 256)
                    {
                        // 0 - 255
                        // BKG FETCHES
                        // UNUSED AT 248-255
                        switch (HClock & 7)
                        {
                            case 0: bkg_fetch0(); break;
                            case 1: bkg_fetch1(); break;
                            case 2: bkg_fetch2(); break;
                            case 3: bkg_fetch3(); break;
                            case 4: bkg_fetch4(); break;
                            case 5: bkg_fetch5(); break;
                            case 6: bkg_fetch6(); break;
                            case 7: bkg_fetch7(); if (HClock == 255) IncrementY(); else IncrementX(); bkg_renderTile(); break;
                        }
                        if (VClock < 240) RenderPixel();
                        // OAM EVALUATION RESET
                        switch (HClock & 1)
                        {
                            case 0: oam_dofetch(); break;
                            case 1: oam_dophase(); break;
                        }
                        if (HClock == 63)
                            EvaluationBegin();

                        if (HClock == 255)
                            EvaluationReset();
                    }
                    else if (HClock < 320)
                    {
                        // 256 - 319
                        // SPRITE FETCHES + GARBAGE BKG FETCHES
                        switch (HClock & 7)
                        {
                            case 0: bkg_fetch0(); break;
                            case 1: bkg_fetch1(); break;
                            case 2: bkg_fetch2(); break;
                            case 3: bkg_fetch3(); break;
                            case 4: spr_fetch0(); break;
                            case 5: spr_fetch1(); break;
                            case 6: spr_fetch2(); break;
                            case 7: spr_fetch3(); spr_renderTile(); break;
                        }
                        if (HClock == 256)
                        {
                            vram_address = (vram_address & 0x7BE0) | (vram_temp & 0x041F);

                        }

                        if (VClock == vbl_vclock_End && HClock >= 279 && HClock <= 303)
                        {
                            vram_address = (vram_address & 0x041F) | (vram_temp & 0x7BE0);
                        }
                    }
                    else if (HClock < 336)
                    {
                        // 320 - 335
                        // FIRST 2 BKG TILES FOR 1ST SCANLINE
                        switch (HClock & 7)
                        {
                            case 0: bkg_fetch0(); break;
                            case 1: bkg_fetch1(); break;
                            case 2: bkg_fetch2(); break;
                            case 3: bkg_fetch3(); break;
                            case 4: bkg_fetch4(); break;
                            case 5: bkg_fetch5(); break;
                            case 6: bkg_fetch6(); break;
                            case 7: bkg_fetch7(); IncrementX(); bkg_renderTile(); break;
                        }
                    }
                    else if (HClock < 340)
                    {
                        // 336 - 339
                        // DUMMY FETCHES
                        switch (HClock & 7)
                        {
                            case 0: bkg_fetch0(); break;
                            case 1: bkg_fetch1(); break;
                            case 2: bkg_fetch2(); break;
                            case 3: bkg_fetch3(); break;
                        }
                    }
                    else
                    {
                        // Idle cycle
                    }
                }
                else
                {
                    // Rendering is off, draw color at vram address if it in range 0x3F00 - 0x3FFF
                    if (HClock < 255 & VClock < 240)
                    {
                        int pixel = 0;//this will clear the previous line
                        if ((vram_address & 0x3F00) == 0x3F00)
                            pixel = GetRGBPixel(Read(vram_address & 0x3FFF) & grayscale | emphasis);
                        else
                            pixel = GetRGBPixel(Read(0x3F00) & grayscale | emphasis);
                        screen[(VClock * 256) + HClock] = pixel;
                    }
                }
            }
            vbl_flag = vbl_flag_temp;
            HClock++;
            // odd frame
            if (HClock == 338)
            {
                if (UseOddFrame)
                {
                    if (VClock == vbl_vclock_End)
                    {
                        oddSwap = !oddSwap;
                        if (!oddSwap & bkg_enabled)
                        {
                            HClock++;
                        }
                    }
                }
            }
            CheckNMI();

            // VBLANK, NMI and frame end
            if (HClock == 341)
            {
                HClock = 0;
                VClock++;
                //set vbl
                if (VClock == vbl_vclock_Start)
                {
                    vbl_flag_temp = true;
                }
                //clear vbl
                else if (VClock == vbl_vclock_End)
                {
                    spr_0Hit = false;
                    vbl_flag_temp = false;
                    spr_overflow = false;
                }
                else if (VClock == frameEnd)
                {
                    VClock = 0;
                    NesCore.FinishFrame(screen);
                }
            }
        }
        private void IncrementX()
        {
            if ((vram_address & 0x001F) == 0x001F)
                vram_address ^= 0x041F;
            else
                vram_address++;
        }
        private void IncrementY()
        {
            if ((vram_address & 0x7000) != 0x7000)
            {
                vram_address += 0x1000;
            }
            else
            {
                vram_address ^= 0x7000;

                switch (vram_address & 0x3E0)
                {
                    case 0x3A0: vram_address ^= 0xBA0; break;
                    case 0x3E0: vram_address ^= 0x3E0; break;
                    default: vram_address += 0x20; break;
                }
            }
        }
        private int spr_getpixel()
        {
            if (!spr_enabled || (spr_clipped && HClock < 8))
                return 0;

            return spr_pixels[HClock];
        }
        #region BKG Fetches
        private void bkg_fetch0()
        {
            // Fetch address of nametable
            bkg_fetch_address = 0x2000 | (vram_address & 0x0FFF);
            NesCore.BOARD.OnPPUAddressUpdate(bkg_fetch_address);
        }
        private void bkg_fetch1()
        {
            // Fetch nametable
            bkg_fetch_nametable = Read(bkg_fetch_address);
        }
        private void bkg_fetch2()
        {
            // Fetch address for attr byte
            bkg_fetch_address = 0x23C0 | (vram_address & 0xC00) | (vram_address >> 4 & 0x38) | (vram_address >> 2 & 0x7);
            NesCore.BOARD.OnPPUAddressUpdate(bkg_fetch_address);
        }
        private void bkg_fetch3()
        {
            // Fetch attr byte
            bkg_fetch_attr = (byte)(Read(bkg_fetch_address) >> ((vram_address >> 4 & 0x04) | (vram_address & 0x02)));
        }
        private void bkg_fetch4()
        {
            // Fetch bit 0 address
            bkg_fetch_address = bkg_patternAddress | (bkg_fetch_nametable << 4) | 0 | (vram_address >> 12 & 7);
            NesCore.BOARD.OnPPUAddressUpdate(bkg_fetch_address);
        }
        private void bkg_fetch5()
        {
            // Fetch bit 0
            bkg_fetch_bit0 = Read(bkg_fetch_address);
        }
        private void bkg_fetch6()
        {
            // Fetch bit 1 address
            bkg_fetch_address = bkg_patternAddress | (bkg_fetch_nametable << 4) | 8 | (vram_address >> 12 & 7);
            NesCore.BOARD.OnPPUAddressUpdate(bkg_fetch_address);
        }
        private void bkg_fetch7()
        {
            // Fetch bit 1
            bkg_fetch_bit1 = Read(bkg_fetch_address);
        }
        #endregion
        #region SPR FETCHES
        private void spr_fetch0()
        {
            int index = HClock >> 3 & 7;
            int comparator = (VClock - oam_secondary[index].y) ^ ((oam_secondary[index].attr & 0x80) != 0 ? 0x0F : 0x00);
            if (spr_size16 == 0x10)
            {
                spr_fetch_address = (oam_secondary[index].name << 0x0C & 0x1000) | (oam_secondary[index].name << 0x04 & 0x0FE0) |
                             (comparator << 0x01 & 0x0010) | (comparator & 0x0007);
            }
            else
            {
                spr_fetch_address = spr_patternAddress | (oam_secondary[index].name << 0x04) | (comparator & 0x0007);
            }
            NesCore.BOARD.OnPPUAddressUpdate(spr_fetch_address);
        }
        private void spr_fetch1()
        {
            spr_fetch_bit0 = Read(spr_fetch_address);
            if ((oam_secondary[HClock >> 3 & 7].attr & 0x40) != 0)
                spr_fetch_bit0 = reverseLookup[spr_fetch_bit0];
        }
        private void spr_fetch2()
        {
            spr_fetch_address = spr_fetch_address | 0x08;
            NesCore.BOARD.OnPPUAddressUpdate(spr_fetch_address);
        }
        private void spr_fetch3()
        {
            spr_fetch_bit1 = Read(spr_fetch_address);

            if ((oam_secondary[HClock >> 3 & 7].attr & 0x40) != 0)
                spr_fetch_bit1 = reverseLookup[spr_fetch_bit1];

            spr_fetch_attr = oam_secondary[HClock >> 3 & 7].attr;
        }
        #endregion
        #region Sprites Evaluation
        private void EvaluateFetch()
        {
            oam_fetch_data = oam_ram[oam_address];
        }
        private void EvaluateReset()
        {
            oam_fetch_data = 0xFF;
        }

        private void EvaluatePhase0()
        {
            if (HClock <= 64)
            {
                switch (HClock >> 1 & 0x03)
                {
                    case 0: oam_secondary[HClock >> 3].y = 0xFF; break;
                    case 1: oam_secondary[HClock >> 3].name = 0xFF; break;
                    case 2: oam_secondary[HClock >> 3].attr = 0xFF; break;
                    case 3: oam_secondary[HClock >> 3].x = 0xFF; oam_secondary[HClock >> 3].zero = false; break;
                }
            }
        }
        private void EvaluatePhase1()
        {
            if (VClock == vbl_vclock_End)
                return;
            oam_evaluate_count++;
            int comparator = (VClock - oam_fetch_data) & int.MaxValue;

            if (comparator >= spr_size16)
            {
                if (oam_evaluate_count != 64)
                {
                    oam_address = (byte)(oam_evaluate_count != 2 ? oam_address + 4 : 8);
                }
                else
                {
                    oam_address = 0;
                    oam_dophase = EvaluatePhase9;
                }
            }
            else
            {
                oam_address++;
                oam_dophase = EvaluatePhase2;
                oam_secondary[oam_evaluate_slot].y = oam_fetch_data;
                oam_secondary[oam_evaluate_slot].zero = oam_evaluate_count == 1;
            }
        }
        private void EvaluatePhase2()
        {
            oam_address++;
            oam_dophase = EvaluatePhase3;
            oam_secondary[oam_evaluate_slot].name = oam_fetch_data;
        }
        private void EvaluatePhase3()
        {
            oam_address++;
            oam_dophase = EvaluatePhase4;
            oam_secondary[oam_evaluate_slot].attr = oam_fetch_data;
        }
        private void EvaluatePhase4()
        {
            oam_secondary[oam_evaluate_slot].x = oam_fetch_data;
            oam_evaluate_slot++;

            if (oam_evaluate_count != 64)
            {
                oam_dophase = (oam_evaluate_slot != 8 ? new Action(EvaluatePhase1) : new Action(EvaluatePhase5));
                if (oam_evaluate_count != 2)
                {
                    oam_address++;
                }
                else
                {
                    oam_address = 8;
                }
            }
            else
            {
                oam_address = 0;
                oam_dophase = EvaluatePhase9;
            }
        }
        private void EvaluatePhase5()
        {
            if (VClock == vbl_vclock_End)
                return;
            int comparator = (VClock - oam_fetch_data) & int.MaxValue;

            if (comparator >= spr_size16)
            {
                oam_address = (byte)(((oam_address + 4) & 0xFC) +
                    ((oam_address + 1) & 0x03));

                if (oam_address <= 5)
                {
                    oam_dophase = EvaluatePhase9;
                    oam_address &= 0xFC;
                }
            }
            else
            {
                oam_dophase = EvaluatePhase6;
                oam_address += (0x01) & 0xFF;
                spr_overflow = true;
            }
        }
        private void EvaluatePhase6()
        {
            oam_dophase = EvaluatePhase7;
            oam_address += (0x01);
        }
        private void EvaluatePhase7()
        {
            oam_dophase = EvaluatePhase8;
            oam_address += (0x01);
        }
        private void EvaluatePhase8()
        {
            oam_dophase = EvaluatePhase9;
            oam_address += (0x01);

            if ((oam_address & 0x03) == 0x03)
                oam_address += (0x01);

            oam_address &= 0xFC;
        }
        private void EvaluatePhase9()
        {
            oam_address += 0x4;
        }

        private void EvaluationBegin()
        {
            this.oam_dofetch = this.EvaluateFetch;
            this.oam_dophase = this.EvaluatePhase1;
            this.oam_evaluate_slot = 0;
            this.oam_evaluate_count = 0;
        }
        private void EvaluationReset()
        {
            this.oam_dofetch = this.EvaluateReset;
            this.oam_dophase = this.EvaluatePhase0;
            this.oam_evaluate_slot = 0;
            this.oam_address = 0;
            this.oam_evaluate_count = 0;

            spr_pixels = new int[256];
        }
        #endregion
        private void bkg_renderTile()
        {
            var pos = (HClock + 9) % 336;

            for (int i = 0; i < 8 && pos < 272; i++, pos++, bkg_fetch_bit0 <<= 1, bkg_fetch_bit1 <<= 1)
                bkg_pixels[pos] = (bkg_fetch_attr << 2 & 12) | (bkg_fetch_bit0 >> 7 & 1) | (bkg_fetch_bit1 >> 6 & 2);
        }
        private void spr_renderTile()
        {
            int index = HClock >> 3 & 7;

            if (oam_secondary[index].x == 255)
                return;

            int pos = oam_secondary[index].x;
            int object0 = oam_secondary[index].zero ? 0x4000 : 0x0000;
            int infront = ((oam_secondary[index].attr & 0x20) == 0) ? 0x8000 : 0x0000;

            for (int i = 0; i < 8 && pos < 256; i++, pos++, spr_fetch_bit0 <<= 1, spr_fetch_bit1 <<= 1)
            {
                if (pos > 255)
                    return;

                int pixel = (spr_fetch_attr << 2 & 12) | (spr_fetch_bit0 >> 7 & 1) | (spr_fetch_bit1 >> 6 & 2) | object0 | infront;
                if ((spr_pixels[pos] & 0x03) == 0 && (pixel & 0x03) != 0)
                    spr_pixels[pos] = pixel;
            }
        }
        private int bkg_getpixel()
        {
            if (!bkg_enabled || (bkg_clipped && HClock < 8))
                return 0;

            return bkg_pixels[HClock + vram_fine];
        }
        private void RenderPixel()
        {
            //Render is enabled here, draw background color at 0x3F00
            //byte bkgc = NesCore.PPUMemory[0x3F00];

            //screen[(VClock * 256) + HClock] = GetRGBPixel(bkgc & (grayscale | emphasis));

            int bkgPixel = 0x3F00 | bkg_getpixel();
            int sprPixel = 0x3F10 | spr_getpixel();
            int pixel = 0;

            //Priority *******************************
            if ((sprPixel & 0x8000) != 0)
                pixel = sprPixel;
            else
                pixel = bkgPixel;
            //****************************************

            // Transparency **************************
            if ((bkgPixel & 0x03) == 0)
            {
                pixel = sprPixel;
                goto render;
            }

            if ((sprPixel & 0x03) == 0)
            {
                pixel = bkgPixel;
                goto render;
            }
            //****************************************

            //Sprite 0 Hit
            if ((sprPixel & 0x4000) != 0 & HClock < 255)
                spr_0Hit = true;

        render:
            //if ((pixel & 0x03) != 0)
            screen[(VClock * 256) + HClock] = GetRGBPixel(Read(pixel) & (grayscale | emphasis));
        }
        public bool IsRenderingOn()
        {
            return (bkg_enabled || spr_enabled);
        }
        public int GetPixel(int x, int y)
        { return screen[(y * 256) + x]; }
        private int GetRGBPixel(int value)
        {
            return palette[paletteIndexes[value]];
        }
    }
}
