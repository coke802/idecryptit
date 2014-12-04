﻿/* =============================================================================
 * File:   IPlistElement.cs
 * Author: Cole Johnson
 * =============================================================================
 * Copyright (c) 2012, 2014 Cole Johnson
 * 
 * This file is part of Hexware.Plist
 * 
 * Hexware.Plist is free software: you can redistribute it and/or modify it
 *   under the terms of the GNU Lesser General Public License as published by
 *   the Free Software Foundation, either version 3 of the License, or (at your
 *   option) any later version.
 * 
 * Hexware.Plist is distributed in the hope that it will be useful, but WITHOUT
 *   ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or
 *   FITNESS FOR A PARTICULAR PURPOSE. See the GNU Lesser General Public
 *   License for more details.
 * 
 * You should have received a copy of the GNU Lesser General Public License
 *   along with Hexware.Plist. If not, see <http://www.gnu.org/licenses/>.
 * =============================================================================
 */
namespace Hexware.Plist
{
    /// <summary>
    /// Base interface for manipulating Plist elements
    /// </summary>
    public partial interface IPlistElement
    {
        /// <summary>
        /// Gets the Xml tag for this element
        /// </summary>
        string XmlTag
        {
            get;
        }

        /// <summary>
        /// Gets the length of this element when written in binary mode
        /// </summary>
        /// <returns>Containers return the amount inside while Primitives return the binary length</returns>
        int GetPlistElementBinaryLength();
    }

    /// <summary>
    /// Interface for manipulating Plist elements
    /// </summary>
    /// <typeparam name="TDotNetEquiv">The .NET equivalent of this Plist element</typeparam>
    /// <typeparam name="TElemType"><see cref="Hexware.Plist.Container"/> or <see cref="Hexware.Plist.Primitive"/></typeparam>
    public partial interface IPlistElement<TDotNetEquiv, TElemType> : IPlistElement
    {
        /// <summary>
        /// Gets the Xml tag for this element
        /// </summary>
        new string XmlTag
        {
            get;
        }

        /// <summary>
        /// Gets or sets the value of this element
        /// </summary>
        TDotNetEquiv Value
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the type of this element as one of <see cref="Hexware.Plist.Container"/> or <see cref="Hexware.Plist.Primitive"/>
        /// </summary>
        TElemType ElementType
        {
            get;
        }

        /// <summary>
        /// Gets the length of this element when written in binary mode
        /// </summary>
        /// <returns>Containers return the amount inside while Primitives return the binary length</returns>
        new int GetPlistElementBinaryLength();
    }
}