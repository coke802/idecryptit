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
    public partial class PlistDate
    {
        internal static PlistDate ReadBinary(BinaryReader reader, byte firstbyte)
        {
            firstbyte = (byte)(firstbyte & 0x0F); // get lower nibble
            int numofbytes = (1 << firstbyte); // how many bytes are contained in this date
            if (reader.BaseStream.Length < (reader.BaseStream.Position + numofbytes))
                throw new PlistFormatException("Length of element passes end of stream");

            byte[] buf = reader.ReadBytes(numofbytes);
            Array.Reverse(buf);
            DateTime epoch = new DateTime(2011, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            if (firstbyte == 0x02)
                return new PlistDate(epoch.AddTicks((long)BitConverter.ToSingle(buf, 0)));
            if (firstbyte == 0x03)
                return new PlistDate(epoch.AddTicks((long)BitConverter.ToDouble(buf, 0)));

            throw new PlistFormatException("Node is not a single (float) or double");
        }

        internal byte[] WriteBinary()
        {
            DateTime start = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            TimeSpan ts = _value - start;
            
            byte[] tag = new byte[1]
            {
                0x33
            };
            byte[] buf = BitConverter.GetBytes(ts.TotalSeconds);
            Array.Reverse(buf);
            PlistInternal.Merge(ref tag, ref buf);
            return tag;
        }

        internal static PlistDate ReadXml(XmlDocument reader, int index)
        {
            return new PlistDate(reader.ChildNodes[index].InnerText);
        }

        internal void WriteXml(XmlNode tree, XmlDocument writer)
        {
            XmlElement element = writer.CreateElement("date");
            element.InnerText = _value.ToString("s") + "Z";
            tree.AppendChild(element);
        }
    }
    public partial class PlistDate : IPlistElement<DateTime, Primitive>
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
        /// Gets the type of this element as one of <see cref="Hexware.Plist.Container"/> or <see cref="Hexware.Plist.Primitive"/>
        /// </summary>
        public Primitive ElementType
        {
            get
            {
                return Primitive.Date;
            }
        }

        /// <summary>
        /// Gets the length of this element when written in binary mode
        /// </summary>
        /// <returns>Containers return the amount inside while Primitives return the binary length</returns>
        public int GetPlistElementBinaryLength()
        {
            return WriteBinary().Length;
        }
    }
}