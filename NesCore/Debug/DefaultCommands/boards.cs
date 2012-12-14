/* This file is part of My Nes
 * A Nintendo Entertainment System Emulator.
 *
 * Copyright © Ala I Hadid 2009 - 2012
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
using MyNes.Core.Boards;
using System.Collections.Generic;

namespace MyNes.Core.Debug.DefaultCommands
{
    class boards : ConsoleCommand
    {
        public override string Method
        {
            get { return "boards"; }
        }

        public override string Description
        {
            get { return "Show supported boards sorted in boards name"; }
        }

        public override void Execute(string parameters)
        {
            List<Board> brds = new List<Board>(BoardsManager.AvailableBoards);
            brds.Sort(new BoardSorter(true, false));
            int count = 0;
            foreach (Board brd in brds)
            {
                Console.WriteLine(brd.Name + " [Mapper # " + brd.INESMapperNumber + "]");
                count++;
            }
            Console.WriteLine(count + " Total");
        }
    }
    class mappers : ConsoleCommand
    {

        public override string Method
        {
            get { return "mappers"; }
        }

        public override string Description
        {
            get { return "Show supported mappers sorted in mapper numbers"; }
        }

        public override void Execute(string parameters)
        {
            List<Board> brds = new List<Board>(BoardsManager.AvailableBoards);
            brds.Sort(new BoardSorter(true, true)); 
            int count = 0;
            foreach (Board brd in brds)
            {
                Console.WriteLine("Mapper # " + brd.INESMapperNumber + " [Board: " + brd.Name + "]"); count++;
            }

            Console.WriteLine(count + " Total");
        }
    }
}
