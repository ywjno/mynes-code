using System;
using System.Collections.Generic;

namespace MyNes.Core.Boards
{
    class BoardSorter : IComparer<Board>
    {
        bool AtoZ = true;
        bool isMappers = false;
        public BoardSorter(bool AtoZ, bool isMappers)
        {
            this.AtoZ = AtoZ;
            this.isMappers = isMappers;
        }
        public int Compare(Board x, Board y)
        {
            if (!isMappers)
            {
                if (AtoZ)
                    return (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.Name, y.Name);
                else
                    return (-1 * (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.Name, y.Name));
            }
            else
            {
                if (AtoZ)
                    return (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.INESMapperNumber, y.INESMapperNumber);
                else
                    return (-1 * (StringComparer.Create(System.Threading.Thread.CurrentThread.CurrentCulture, false)).Compare(x.INESMapperNumber, y.INESMapperNumber));
            }
        }
    }
}
