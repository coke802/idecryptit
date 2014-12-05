﻿/* =============================================================================
 * File:   PlistDate.cs
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
using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace Hexware.Plist
{
    /// <summary>
    /// Represents a &lt;date /&gt; tag using a <see cref="System.DateTime"/>
    /// </summary>
    public partial class PlistDate
    {
        internal static DateTime AppleEpoch = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        /// <summary>
        /// Hexware.Plist.PlistDate constructor using a <see cref="System.DateTime"/>
        /// </summary>
        /// <param name="value">The value of this node</param>
        public PlistDate(DateTime value)
        {
            _value = value;
        }

        /// <summary>
        /// Hexware.Plist.PlistDate constructor using a <see cref="System.String"/>
        /// </summary>
        /// <param name="value">The value of this node</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        /// <exception cref="System.FormatException">Provided date is not in valid ISO 8601 standard</exception>
        public PlistDate(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            try
            {
                _value = DateTime.Parse(value, null, DateTimeStyles.AdjustToUniversal);
            }
            catch (FormatException)
            {
                throw new FormatException("Provided date is not in valid ISO 8601 standard");
            }
        }
    }
    public partial class PlistDate : IPlistElementInternal
    {
        internal static PlistDate ReadBinary(BinaryReader reader, byte firstbyte)
        {
            byte[] buf = reader.ReadBytes(8);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(buf);
            return new PlistDate(AppleEpoch.AddTicks((long)BitConverter.ToDouble(buf, 0)));
        }

        void IPlistElementInternal.WriteBinary(BinaryWriter writer)
        {
            writer.Write((byte)0x33);

            // could be optimized by writing the array backwards instead of reversing first
            TimeSpan val = _value - AppleEpoch;
            byte[] buf = BitConverter.GetBytes(val.TotalSeconds);
            Array.Reverse(buf);
            writer.Write(buf);
        }

        internal static PlistDate ReadXml(XmlNode node)
        {
            return new PlistDate(node.InnerText);
        }

        void IPlistElementInternal.WriteXml(XmlNode tree, XmlDocument writer)
        {
            XmlElement element = writer.CreateElement("date");
            element.InnerText = _value.ToString("s") + "Z";
            tree.AppendChild(element);
        }
    }
    public partial class PlistDate : IPlistElement<DateTime>
    {
        internal DateTime _value;

        /// <summary>
        /// Gets the Xml tag for this element
        /// </summary>
        public string XmlTag
        {
            get
            {
                return "date";
            }
        }

        /// <summary>
        /// Gets or sets the value of this element
        /// </summary>
        public DateTime Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        /// <summary>
        /// Gets the type of this element
        /// </summary>
        public PlistElementType ElementType
        {
            get
            {
                return PlistElementType.Date;
            }
        }
    }
}