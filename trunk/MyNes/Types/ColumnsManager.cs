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
