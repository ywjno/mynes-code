/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2013
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyNes
{
    [Serializable()]
    public class ColumnsManager
    {
        private List<ColumnItem> columns = new List<ColumnItem>();
        /// <summary>
        /// Get or set the columns collection
        /// </summary>
        public List<ColumnItem> Columns
        { get { return this.columns; } set { this.columns = value; } }

        /// <summary>
        /// Use this at first program start
        /// </summary>
        public void BuildDefaultCollection()
        {
            columns = new List<ColumnItem>();
            for (int i = 0; i < ColumnItem.DEFAULTCOLUMNS.Length / 2; i++)
            {
                ColumnItem item = new ColumnItem();
                item.ColumnName = ColumnItem.DEFAULTCOLUMNS[i, 0];
                item.ColumnID = ColumnItem.DEFAULTCOLUMNS[i, 1];
                item.Width = 60;
                item.Visible = true;
                columns.Add(item);
            }

            // Add some custom columns that's not visible.
            ColumnItem citem = new ColumnItem();
            citem.ColumnID = "snapshot";
            citem.ColumnName = "Has Snapshot";
            citem.Width = 60;
            citem.Visible = false;
            columns.Add(citem);

            citem = new ColumnItem();
            citem.ColumnID = "cover";
            citem.ColumnName = "Has Cover";
            citem.Width = 60;
            citem.Visible = false;
            columns.Add(citem);

            citem = new ColumnItem();
            citem.ColumnID = "info";
            citem.ColumnName = "Has Info Text";
            citem.Width = 60;
            citem.Visible = false;
            columns.Add(citem);
        }
    }
}
