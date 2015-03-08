#region LICENSE
/*
 * Copyright (C) 2004 - 2007 David Hudson (jendave@yahoo.com)
 *
 * This library is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * 
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 */
#endregion LICENSE

using System;
using System.Runtime.Serialization;

using SdlDotNet.Core;

namespace SdlDotNet.Graphics
{
    /// <summary>
    /// Represents an error resulting from a surface being lost, 
    /// usually as a result of the user changing the input focus 
    /// away from a full-screen application.
    /// </summary>
    [Serializable()]
    public class SurfaceLostException : SdlException
    {
        #region Constructors

        /// <summary>
        /// Basic exception.
        /// </summary>
        public SurfaceLostException()
        {
            SurfaceLostException.Generate();
        }

        /// <summary>
        /// Exception with specified string
        /// </summary>
        /// <param name="message">Exception message</param>
        public SurfaceLostException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        public SurfaceLostException(string message, Exception exception)
            : base(message, exception)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="context"></param>
        protected SurfaceLostException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}
