//
//  Room_About.cs
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
using System.Drawing;
using SdlDotNet;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Core;

namespace MyNesSDL
{
    [RoomBaseAttributes("About My Nes SDL")]
    public class Room_About:RoomBase
    {
        public Room_About()
            : base()
        {     
            lineTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(Program.VIDEO.fontPath, 10));
            lineTextSprite.BackgroundColor = Color.Black;
            Items.Add(new MenuItem_BackToMainMenu());
        }

        protected TextSprite lineTextSprite;
        private string[] Lines =
            {
            "My Nes SDL Edition",
            "http://sourceforge.net/projects/mynes/",
            "",
            "Written by Ala Ibrahim Hadid <ahdsoftwares@hotmail.com>",
            "Copyright (c) 2009 - 2015 Ala Ibrahim Hadid",
            "",
            "This program is free software: you can redistribute it and/or modify",
            "it under the terms of the GNU General Public License as published by",
            "the Free Software Foundation, either version 3 of the License, or",
            "(at your option) any later version.",
            "",
            "This program is distributed in the hope that it will be useful,",
            "but WITHOUT ANY WARRANTY; without even the implied warranty of",
            "MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the",
            "GNU General Public License for more details.",
            "",
            "You should have received a copy of the GNU General Public License",
            "along with this program.  If not, see http://www.gnu.org/licenses/.",
            "",
            "NES is either a trademark or registered trademark of Nintendo of America Inc.",
            "Famicom is either a trademark or registered trademark of Nintendo Co., LTD.",
            "All other trademarks are property of their respective owners.",
            "My Nes is not affiliated with or endorsed by any of the companies mentioned.",
            "For more info about copyrighted components, please read Copyright Notice.txt file",
            "or visit the main website mensioned above."
        };

        public override void Draw(SdlDotNet.Graphics.Surface screen)
        {
            // Draw the title
            titleTextSprite.X = 20;
            titleTextSprite.Y = _BaseY;
            titleTextSprite.Color = Color.Yellow;
            titleTextSprite.Text = this.Name;
            screen.Blit(titleTextSprite);

            int item_y = _BaseY + _SpaceBetweenItems + 20;
            // Draw the lines
            for (int i = 0; i < Lines.Length; i++)
            {
                lineTextSprite.X = 20;
                lineTextSprite.Y = item_y;
                lineTextSprite.Color = Color.White; 
                lineTextSprite.Text = Lines[i];
                screen.Blit(lineTextSprite);

                item_y += 15;
            }

            // Draw the item
            itemTextSprite.X = 20;
            itemTextSprite.Y = screen.Height - 40;
            itemTextSprite.Color = Color.LightYellow;
            itemTextSprite.Text = Items[0].Text;
            screen.Blit(itemTextSprite);
        }
    }
}

