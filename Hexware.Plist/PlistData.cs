﻿/* =============================================================================
 * File:   PlistData.cs
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
using System.IO;
using System.Text;
using System.Xml;

namespace Hexware.Plist
{
    /// <summary>
    /// Represents a &lt;data /&gt; tag using a one-dimensional <see cref="System.Byte"/> array
    /// </summary>
    public partial class PlistData
    {
        /// <summary>
        /// Hexware.Plist.PlistData constructor using a one dimensional <see cref="System.Byte"/> array
        /// </summary>
        /// <param name="value">The value of this node</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        public PlistData(byte[] value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            _value = value;
        }

        /// <summary>
        /// Hexware.Plist.PlistData constructor using a base64 encoded <see cref="System.String"/>
        /// </summary>
        /// <param name="value">The value of this node</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        /// <exception cref="System.FormatException"><paramref name="value"/> is not a valid base64 encoded string</exception>
        public PlistData(string value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            // FIXME: Proper decoding
            value = value
                .Replace("\n", "")
                .Replace("\r", "")
                .Replace("\t", "")
                .Replace(" ", "");

            try
            {
                _value = Convert.FromBase64String(value);
            }
            catch (FormatException)
            {
                throw new FormatException("Not a valid base64 encoded string");
            }
        }

        /// <summary>
        /// Gets the length of the data
        /// </summary>
        public int Length
        {
            get
            {
                return _value.Length;
            }
        }
    }
    public partial class PlistData : IPlistElementInternal
    {
        internal static PlistData ReadBinary(BinaryReader reader, byte firstbyte)
        {
            int length = firstbyte & 0x0F;
            if (length == 0x0F)
                length = (int)PlistInteger.ReadBinary(reader, reader.ReadByte()).Value;

            return new PlistData(reader.ReadBytes(length));
        }

        void IPlistElementInternal.WriteBinary(BinaryWriter writer)
        {
            if (_value.Length < 0x0F) {
                writer.Write((byte)(0x40 | _value.Length));
                return;
            }
            writer.Write((byte)0x4F);
            ((IPlistElementInternal)new PlistInteger(_value.Length)).WriteBinary(writer);
        }

        internal static PlistData ReadXml(XmlNode node)
        {
            return new PlistData(node.InnerText);
        }

        void IPlistElementInternal.WriteXml(XmlNode tree, XmlDocument writer)
        {
            // Build indentations
            int depth = 0;
            XmlNode clone = tree.Clone();
            while (clone.ParentNode != null)
            {
                clone = clone.ParentNode;
                depth++;
            }
            StringBuilder sb = new StringBuilder();
            while (depth != 0)
            {
                sb.Append("\t");
                depth--;
            }
            string indent = sb.ToString();

            XmlElement element = writer.CreateElement("data");
            string buf = Convert.ToBase64String(_value);
            sb = new StringBuilder();
            sb.AppendLine();
            for (int i = 0; i < buf.Length; i++)
            {
                sb.Append(buf[i]);
                if (i % 64 == 0)
                    sb.AppendLine();
                else if (i % 65 == 1)
                    sb.Append(indent);
            }
            sb.AppendLine();
            element.InnerText = sb.ToString();
            tree.AppendChild(element);
        }
    }
    public partial class PlistData : IPlistElement<byte[]>
    {
        internal byte[] _value;

        /// <summary>
        /// Gets the Xml tag for this element
        /// </summary>
        public string XmlTag
        {
            get
            {
                return "data";
            }
        }

        /// <summary>
        /// Gets or sets the value of this element
        /// </summary>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        public byte[] Value
        {
            get
            {
                return _value;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("value");
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
                return PlistElementType.Data;
            }
        }
    }
}