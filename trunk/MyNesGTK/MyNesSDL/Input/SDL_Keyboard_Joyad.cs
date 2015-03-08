//  
//  SDL_Keyboard_Joyad.cs
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
    public class SDL_Keyboard_Joyad : IJoypadConnecter
    {
        public SDL_Keyboard_Joyad(int playerIndex)
        {
            this.playerIndex = playerIndex;
            LoadSettings();
            state = new KeyboardState();
        }

        private int playerIndex;
        private KeyboardState state;
        private bool turbo;
        public Key A;
        public Key B;
        public Key TurboA;
        public Key TurboB;
        public Key Start;
        public Key Select;
        public Key Up;
        public Key Down;
        public Key Left;
        public Key Right;

        private void LoadSettings()
        {
            // Kill all
            this.A = Key.Unknown;
            this.B = Key.Unknown;
            this.TurboA = Key.Unknown;
            this.TurboB = Key.Unknown;
            this.Start = Key.Unknown;
            this.Select = Key.Unknown;
            this.Up = Key.Unknown;
            this.Down = Key.Unknown;
            this.Left = Key.Unknown;
            this.Right = Key.Unknown;
            switch (playerIndex)
            {
                case 0:
                    {
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonA, out this.A);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonB, out this.B);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonTurboA, out this.TurboA);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonTurboB, out this.TurboB);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonStart, out this.Start);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonSelect, out this.Select);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonUp, out this.Up);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonDown, out this.Down);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonLeft, out this.Left);
                        Enum.TryParse<Key>(Settings.Key_P1_ButtonRight, out this.Right);
                        break;
                    }
                case 1:
                    {
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonA, out this.A);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonB, out this.B);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonTurboA, out this.TurboA);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonTurboB, out this.TurboB);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonStart, out this.Start);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonSelect, out this.Select);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonUp, out this.Up);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonDown, out this.Down);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonLeft, out this.Left);
                        Enum.TryParse<Key>(Settings.Key_P2_ButtonRight, out this.Right);
                        break;
                    }
                case 2:
                    {
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonA, out this.A);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonB, out this.B);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonTurboA, out this.TurboA);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonTurboB, out this.TurboB);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonStart, out this.Start);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonSelect, out this.Select);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonUp, out this.Up);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonDown, out this.Down);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonLeft, out this.Left);
                        Enum.TryParse<Key>(Settings.Key_P3_ButtonRight, out this.Right);
                        break;
                    }
                case 3:
                    {
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonA, out this.A);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonB, out this.B);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonTurboA, out this.TurboA);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonTurboB, out this.TurboB);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonStart, out this.Start);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonSelect, out this.Select);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonUp, out this.Up);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonDown, out this.Down);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonLeft, out this.Left);
                        Enum.TryParse<Key>(Settings.Key_P4_ButtonRight, out this.Right);
                        break;
                    }
            }
        }

        public override void Update()
        {
            turbo = !turbo;

            state.Update();
            DATA = 0;

            if (state.IsKeyPressed(A))
                DATA |= 1;

            if (state.IsKeyPressed(B))
                DATA |= 2;

            if (state.IsKeyPressed(TurboA) && turbo)
                DATA |= 1;

            if (state.IsKeyPressed(TurboB) && turbo)
                DATA |= 2;

            if (state.IsKeyPressed(Select))
                DATA |= 4;

            if (state.IsKeyPressed(Start))
                DATA |= 8;

            if (state.IsKeyPressed(Up))
                DATA |= 0x10;

            if (state.IsKeyPressed(Down))
                DATA |= 0x20;

            if (state.IsKeyPressed(Left))
                DATA |= 0x40;

            if (state.IsKeyPressed(Right))
                DATA |= 0x80;
        }
    }
}

