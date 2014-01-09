/* This file is part of My Nes
 * 
 * A Nintendo Entertainment System / Family Computer (Nes/Famicom) 
 * Emulator written in C#.
 *
 * Copyright © Ala Ibrahim Hadid 2009 - 2014
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
using System.ComponentModel;
using System.Collections.Generic;
using System.Reflection;
namespace MyNes.Core.Boards
{
    public class BoardsManager
    {
        private static Board[] boards;
        /// <summary>
        /// Indicates whether an ines mapper number is available as board (supported)
        /// </summary>
        /// <param name="INESMapper"></param>
        /// <returns></returns>
        public static bool IsBoardSupported(int INESMapper)
        {
            foreach (Board board in boards)
            {
                if (board.INESMapperNumber == INESMapper)
                {
                    return true;
                }
            }
            return false;
        } 
        //Methods
        public static void LoadAvailableBoards()
        {
            List<Board> availableBoards = new List<Board>();
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type tp in types)
            {
                if (tp.IsSubclassOf(typeof(Board)))
                {
                    if (!tp.IsAbstract)
                    {
                        Board board = Activator.CreateInstance(tp) as Board;
                        availableBoards.Add(board);
                    }
                }
            }
            availableBoards.Sort(new BoardSorter(true, false));
            boards = availableBoards.ToArray();
        }
        public static Board GetBoard(int INESMapperNumber, bool isVram, byte[] chr, byte[] prg, byte[] trainer)
        {
            foreach (Board board in boards)
            {
                if (board.INESMapperNumber == INESMapperNumber)
                {
                    Type boardType = board.GetType();
                    return ((Board)Activator.CreateInstance(boardType, new object[] { chr, prg, trainer, isVram }));
                }
            }
            return null;
        }

        //Properties
        public static Board[] AvailableBoards { get { return boards; } }
    }
}
