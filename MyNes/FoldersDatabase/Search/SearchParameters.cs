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

namespace MyNes
{
    [Serializable]
    public class SearchParameters : EventArgs
    {
        /// <summary>
        /// The search parameters. Can be used as an event arguments as well.
        /// </summary>
        public SearchParameters()
        { }
        /// <summary>
        /// The search parameters. Can be used as an event arguments as well.
        /// </summary>
        /// <param name="searchWhat"></param>
        /// <param name="mode"></param>
        /// <param name="conditionForText"></param>
        /// <param name="conditionForNumber"></param>
        /// <param name="caseSensitive"></param>
        /// <param name="matchWord"></param>
        public SearchParameters(string searchWhat, SearchMode mode, TextSearchCondition conditionForText,
            NumberSearchCondition conditionForNumber, bool caseSensitive)
        {
            this.searchWhat = searchWhat;
            this.mode = mode;
            this.conditionForText = conditionForText;
            this.conditionForNumber = conditionForNumber;
            this.caseSensitive = caseSensitive;
        }

        private string searchWhat;
        private SearchMode mode;
        private TextSearchCondition conditionForText;
        private NumberSearchCondition conditionForNumber;
        private bool caseSensitive;

        /// <summary>
        /// The search word
        /// </summary>
        public string SearchWhat
        { get { return searchWhat; } }

        /// <summary>
        /// The search mode
        /// </summary>
        public SearchMode SearchMode
        { get { return mode; } }
        /// <summary>
        /// The condition if the search is for text
        /// </summary>
        public TextSearchCondition ConditionForText
        { get { return conditionForText; } }
        /// <summary>
        /// The condition if the search is for number
        /// </summary>
        public NumberSearchCondition ConditionForNumber
        { get { return conditionForNumber; } }
        /// <summary>
        /// Indicates case sensitive for text search
        /// </summary>
        public bool CaseSensitive
        { get { return caseSensitive; } }
        /// <summary>
        /// Create an exact clone of this args object
        /// </summary>
        /// <returns></returns>
        public SearchParameters Clone()
        {
            SearchParameters newArgs = new SearchParameters();
            newArgs.caseSensitive = this.caseSensitive;
            newArgs.conditionForNumber = this.conditionForNumber;
            newArgs.conditionForText = this.conditionForText;
            newArgs.mode = this.mode;
            newArgs.searchWhat = this.searchWhat;
            return newArgs;
        }
    }
}
