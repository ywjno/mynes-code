using System;
namespace MyNes
{
    [Serializable()]
    public class ColumnItem
    {
        public string ColumnID = "";
        public string ColumnName = "";
        public bool Visible = true;
        public int Width = 60;

        public static string[,] DEFAULTCOLUMNS
        {
            get
            {
                return new string[,]  {
          { "Name",              "name" } ,
          { "Size",              "size" } ,
          { "File Type",         "file type" } ,
          { "Played Times",      "played times" } ,
          { "Rating",            "rating" } ,
          { "Mapper #",          "mapper" } ,
          { "Board",             "board" } ,
          { "Mirroring",         "mirroring" } ,
          { "Has Trainer",       "trainer" } ,
          { "Is Battery Packed", "battery" } ,
          { "Is PC10",           "pc10" } ,
          { "Is VsUnisystem",    "vs" } ,
          { "Path",              "path" } , 
                                      };
            }
        }

        public static bool IsDefaultColumn(string id)
        {
            for (int i = 0; i < DEFAULTCOLUMNS.Length / 2; i++)
            {
                if (DEFAULTCOLUMNS[i, 1] == id)
                    return true;
            }
            return false;
        }
    }
}
