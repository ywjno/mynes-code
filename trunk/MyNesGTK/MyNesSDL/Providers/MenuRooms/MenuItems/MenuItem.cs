//
//  MenuItem.cs
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

namespace MyNesSDL
{
    /// <summary>
    /// Menu item.
    /// </summary>
    public abstract class MenuItem
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.MenuItem"/> class.
        /// </summary>
        public MenuItem()
        {
            this.Text = "";
            this.HasOptions = false;
            this.SelectedOptionIndex = 0;
            this.Options = new List<string>();
            this.SpaceAfter = false;
            LoadAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.MenuItem"/> class.
        /// </summary>
        /// <param name="text">Text.</param>
        public MenuItem(string text)
        {
            this.Text = text;
            this.HasOptions = false;
            this.SelectedOptionIndex = 0;
            this.Options = new List<string>();
            this.SpaceAfter = false;
            LoadAttributes();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.MenuItem"/> class.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="hasoptions">If set to <c>true</c> has options.</param>
        /// <param name="selectedOptionIndex">Selected option index.</param>
        /// <param name="options">Options.</param>
        /// <param name="spaceAfter">If set to <c>true</c> space after.</param>
        public MenuItem(string text, bool hasoptions, int selectedOptionIndex, string[] options, bool spaceAfter)
        {
            this.Text = text;
            this.HasOptions = hasoptions;
            this.SelectedOptionIndex = selectedOptionIndex;
            this.Options = new List<string>(options);
            this.SpaceAfter = spaceAfter;
            LoadAttributes();
        }

        /// <summary>
        /// Loads the attributes.
        /// </summary>
        protected virtual void LoadAttributes()
        {
            foreach (Attribute attr in Attribute.GetCustomAttributes(this.GetType()))
            {
                if (attr.GetType() == typeof(MenuItemAttribute))
                {
                    MenuItemAttribute inf = (MenuItemAttribute)attr;
                    this.Text = inf.Text;
                    this.HasOptions = inf.HasOptions;
                    this.SelectedOptionIndex = inf.SelectedOptionIndex;
                    this.Options = inf.Options;
                }
            }
        }

        /// <summary>
        /// Gets or sets the text of this menu item.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; protected set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has options.
        /// </summary>
        /// <value><c>true</c> if this instance has options; otherwise, <c>false</c>.</value>
        public bool HasOptions{ get; protected set; }

        /// <summary>
        /// Gets or sets the index of the selected option.
        /// </summary>
        /// <value>The index of the selected option.</value>
        public int SelectedOptionIndex{ get; set; }

        /// <summary>
        /// Gets or sets the options.
        /// </summary>
        /// <value>The options.</value>
        public List<string> Options{ get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MyNesSDL.MenuItem"/> has space after.
        /// </summary>
        /// <value><c>true</c> if space after; otherwise, <c>false</c>.</value>
        public bool SpaceAfter{ get; set; }

        /// <summary>
        /// Execute the command of this menu item.
        /// </summary>
        public abstract void Execute();
    }

    /// <summary>
    /// Menu item attribute.
    /// </summary>
    class MenuItemAttribute:Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyNesSDL.MenuItemAttribute"/> class.
        /// </summary>
        /// <param name="text">Text.</param>
        /// <param name="hasoptions">If set to <c>true</c> has options.</param>
        /// <param name="selectedOptionIndex">Selected option index.</param>
        /// <param name="options">Options.</param>
        /// <param name="spaceAfter">If set to <c>true</c> space after.</param>
        public MenuItemAttribute(string text, bool hasoptions, int selectedOptionIndex, 
                                 string[] options, bool spaceAfter)
        {
            this.Text = text;
            this.HasOptions = hasoptions;
            this.SelectedOptionIndex = selectedOptionIndex;
            this.Options = new List<string>(options);
            this.SpaceAfter = spaceAfter;
        }

        /// <summary>
        /// Gets or sets the text of this menu item.
        /// </summary>
        /// <value>The text.</value>
        public string Text { get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance has options.
        /// </summary>
        /// <value><c>true</c> if this instance has options; otherwise, <c>false</c>.</value>
        public bool HasOptions{ get; private set; }

        /// <summary>
        /// Gets or sets the index of the selected option.
        /// </summary>
        /// <value>The index of the selected option.</value>
        public int SelectedOptionIndex{ get; private set; }

        /// <summary>
        /// Gets the options.
        /// </summary>
        /// <value>The options.</value>
        public List<string> Options{ get; private set; }

        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="MyNesSDL.MenuItem"/> has space after.
        /// </summary>
        /// <value><c>true</c> if space after; otherwise, <c>false</c>.</value>
        public bool SpaceAfter{ get; set; }
    }
}

