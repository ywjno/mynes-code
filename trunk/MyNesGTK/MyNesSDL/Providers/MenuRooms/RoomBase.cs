//
//  RoomBase.cs
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
using System.Collections.Generic;
using System.Drawing;
using SdlDotNet;
using SdlDotNet.Graphics;
using SdlDotNet.Graphics.Sprites;
using SdlDotNet.Core;

namespace MyNesSDL
{
    /// <summary>
    /// Room base.
    /// </summary>
    public  abstract class RoomBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.RoomBase"/> class.
        /// </summary>
        public RoomBase()
        {
            this.Name = "";
            this.Items = new List<MenuItem>();
            LoadAttributes();
            InitializeDrawing();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.RoomBase"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="items">Items.</param>
        public RoomBase(string name, List<MenuItem> items)
        {
            this.Name = name;
            this.Items = items;
            LoadAttributes();
            InitializeDrawing();
        }

        protected TextSprite titleTextSprite;
        protected TextSprite itemTextSprite;
        protected TextSprite optionTextSprite;
        protected  const int _BaseY = 40;
        protected  const int _SpaceBetweenItems = 15;

        protected virtual void LoadAttributes()
        {
            foreach (Attribute attr in Attribute.GetCustomAttributes(this.GetType()))
            {
                if (attr.GetType() == typeof(RoomBaseAttributes))
                {
                    RoomBaseAttributes inf = (RoomBaseAttributes)attr;
                    this.Name = inf.Name;
                }
            }
        }

        protected virtual void InitializeDrawing()
        {
            titleTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(Program.VIDEO.fontPath, 15));
            titleTextSprite.BackgroundColor = Color.Black;
            itemTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(Program.VIDEO.fontPath, 10));
            itemTextSprite.BackgroundColor = Color.Black;
            optionTextSprite = new TextSprite(new SdlDotNet.Graphics.Font(Program.VIDEO.fontPath, 10));
            optionTextSprite.BackgroundColor = Color.Black;
        }

        protected virtual void OnMenuOptionChanged()
        {

        }

        /// <summary>
        /// Gets the name of this rom.
        /// </summary>
        public string Name{ get; protected set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public List<MenuItem> Items{ get; set; }

        /// <summary>
        /// Gets or sets the index of the selected menu.
        /// </summary>
        /// <value>The index of the selected menu.</value>
        public int SelectedMenuIndex{ get; set; }

        /// <summary>
        /// Called when this page is opened !
        /// </summary>
        public virtual void OnOpen()
        {
            SelectedMenuIndex = 0;
        }

        /// <summary>
        /// Called when user use tab to quit this room page.
        /// </summary>
        public virtual void OnTabResume()
        {

        }

        /// <summary>
        /// Do the key down.
        /// </summary>
        /// <param name="e">Event args.</param>
        public virtual void DoKeyDown(SdlDotNet.Input.KeyboardEventArgs e)
        {
            if (e.Key == SdlDotNet.Input.Key.DownArrow)
            {
                // Change menu item (go down)
                if (SelectedMenuIndex + 1 < Items.Count)
                    SelectedMenuIndex++;
            }
            else if (e.Key == SdlDotNet.Input.Key.UpArrow)
            {
                // Change menu item (go up)
                if (SelectedMenuIndex - 1 >= 0)
                    SelectedMenuIndex--;
            }
            else if (e.Key == SdlDotNet.Input.Key.RightArrow)
            {
                // Change menu item option (right)
                if (Items[SelectedMenuIndex].HasOptions)
                {
                    if (Items[SelectedMenuIndex].SelectedOptionIndex + 1 <
                        Items[SelectedMenuIndex].Options.Count)
                    {
                        Items[SelectedMenuIndex].SelectedOptionIndex++;
                        OnMenuOptionChanged();
                    }
                }
            }
            else if (e.Key == SdlDotNet.Input.Key.LeftArrow)
            {
                // Change menu item option (left)
                if (Items[SelectedMenuIndex].HasOptions)
                {
                    if (Items[SelectedMenuIndex].SelectedOptionIndex - 1 >= 0)
                    {
                        Items[SelectedMenuIndex].SelectedOptionIndex--;
                        OnMenuOptionChanged();
                    }
                }
            }
            else if (e.Key == SdlDotNet.Input.Key.Return)
            {
                // Do execute the selected menu
                Items[SelectedMenuIndex].Execute();
            }
        }

        /// <summary>
        /// Do the joystick button down.
        /// </summary>
        /// <param name="e">Event args.</param>
        public virtual void DoJoystickButtonDown(SdlDotNet.Input.JoystickButtonEventArgs e)
        {
        }

        /// <summary>
        /// Dos the joystick axis move.
        /// </summary>
        /// <param name="e">Event args.</param>
        public virtual void DoJoystickAxisMove(SdlDotNet.Input.JoystickAxisEventArgs e)
        {
        }

        /// <summary>
        /// Draw this room !
        /// </summary>
        /// <param name="screen">Screen.</param>
        public virtual void Draw(Surface screen)
        {
            // Draw the title
            titleTextSprite.X = 20;
            titleTextSprite.Y = _BaseY;
            titleTextSprite.Color = Color.Yellow;
            titleTextSprite.Text = this.Name;
            screen.Blit(titleTextSprite);

            int item_y = _BaseY + _SpaceBetweenItems + 15;
            // Draw the items
            for (int i = 0; i < Items.Count; i++)
            {
                itemTextSprite.X = 20;
                itemTextSprite.Y = item_y;
                if (SelectedMenuIndex != i)
                {
                    itemTextSprite.Color = Color.Lime;
                    optionTextSprite.Color = Color.Lime;
                }
                else
                {
                    itemTextSprite.Color = Color.LightGoldenrodYellow;
                    optionTextSprite.Color = Color.LightGoldenrodYellow; 
                }
                itemTextSprite.Text = Items[i].Text;
                // if (Items[i].HasOptions)
                //    itemTextSprite.Text = Items[i].Text + ": " + Items[i].Options[Items[i].SelectedOptionIndex];
                // else
                //     itemTextSprite.Text = Items[i].Text;
                if (Items[i].HasOptions)
                {
                    if (SelectedMenuIndex == i)
                    {
                        if (Items[i].Options.Count == 1)
                            optionTextSprite.Text = "  " + Items[i].Options[Items[i].SelectedOptionIndex] + "  ";
                        else
                        {
                            if (Items[i].SelectedOptionIndex == 0)
                                optionTextSprite.Text = "  " + Items[i].Options[Items[i].SelectedOptionIndex] + " >";
                            else if (Items[i].SelectedOptionIndex == Items[i].Options.Count - 1)
                                optionTextSprite.Text = "< " + Items[i].Options[Items[i].SelectedOptionIndex] + "  ";
                            else
                                optionTextSprite.Text = "< " + Items[i].Options[Items[i].SelectedOptionIndex] + " >";
                        }
                    }
                    else
                    {
                        optionTextSprite.Text = "  " + Items[i].Options[Items[i].SelectedOptionIndex] + "  ";
                    }
                    optionTextSprite.X = 380;
                    optionTextSprite.Y = item_y;
                    screen.Blit(itemTextSprite);
                    screen.Blit(optionTextSprite);
                }
                else
                {
                    screen.Blit(itemTextSprite);
                }
                item_y += _SpaceBetweenItems;

                if (Items[i].SpaceAfter)
                    item_y += 10;
            }
        }
    }

    /// <summary>
    /// Room base attributes.
    /// </summary>
    public class RoomBaseAttributes:Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.RoomBaseAttributes"/> class.
        /// </summary>
        /// <param name="name">Name.</param>
        public RoomBaseAttributes(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name{ get; private set; }
    }
}

