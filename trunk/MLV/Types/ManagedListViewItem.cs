﻿/* This file is part of MLV "Managed ListView" project.
   A custom control which provide advanced list view.

   Copyright © Ala Ibrahim Hadid 2013

   This program is free software: you can redistribute it and/or modify
   it under the terms of the GNU General Public License as published by
   the Free Software Foundation, either version 3 of the License, or
   (at your option) any later version.

   This program is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
   GNU General Public License for more details.

   You should have received a copy of the GNU General Public License
   along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
namespace MLV
{
    /// <summary>
    /// Advanced ListView item.
    /// </summary>
    [DefaultProperty("Text"), ToolboxItem(false), DesignTimeVisible(false)]
    [Serializable]
    public class ManagedListViewItem : IManagedListViewItem
    {
        private List<ManagedListViewSubItem> subItems = new List<ManagedListViewSubItem>();
        private bool selected = false;
        private bool specialItem = false;

        /// <summary>
        /// Get subitem using column id
        /// </summary>
        /// <param name="id">The column id</param>
        /// <returns>The target subitem if found otherwise null.</returns>
        public ManagedListViewSubItem GetSubItemByID(string id)
        {
            foreach (ManagedListViewSubItem subItem in this.subItems)
            {
                if (subItem.ColumnID == id)
                    return subItem;
            }
            return null;
        }
        /// <summary>
        /// Get or set the subitems collection.
        /// </summary>
        [Description("The subitems collection. You must add subitems in order to display this item with details view."), Category("Items")]
        [Editor(typeof(MLVSubItemsEditor), typeof(UITypeEditor)), DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ManagedListViewSubItem> SubItems
        { get { return subItems; } set { subItems = value; } }
        /// <summary>
        /// Get or set a value indicate whether this item is selected.
        /// </summary>
        [Browsable(false)]
        public bool Selected
        { get { return selected; } set { selected = value; } }
        /// <summary>
        /// Get or set a value indicate whether this item is special. Special items always colored with special color.
        /// </summary>
        [Description("If set, the control will consider this item as special item and will get highlighted with special color"), Category("Style")]
        public bool IsSpecialItem
        { get { return specialItem; } set { specialItem = value; } }
        /// <summary>
        /// Rises the "on mouse leave" event.
        /// </summary>
        public override void OnMouseLeave()
        {
            base.OnMouseLeave();
            foreach (IManagedListViewItem subitem in subItems)
                subitem.OnMouseLeave();
        }
        /// <summary>
        /// Create an exact clone of this item
        /// </summary>
        /// <returns>An exact clone of this item</returns>
        public ManagedListViewItem Clone()
        {
            ManagedListViewItem newItem = new ManagedListViewItem();
            newItem.Color = this.Color;
            newItem.CustomFont = this.CustomFont;
            newItem.CustomFontEnabled = this.CustomFontEnabled;
            newItem.DrawMode = this.DrawMode;
            newItem.ImageIndex = this.ImageIndex;
            newItem.IsSpecialItem = this.IsSpecialItem;
            newItem.Selected = this.Selected;
            newItem.Tag = this.Tag;
            newItem.Text = this.Text;
            newItem.SubItems = new List<ManagedListViewSubItem>();
            foreach (ManagedListViewSubItem sub in this.SubItems)
                newItem.SubItems.Add(sub.Clone());
            return newItem;
        }
    }
}
