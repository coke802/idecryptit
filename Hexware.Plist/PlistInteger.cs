﻿/* =============================================================================
 * File:   PlistInteger.cs
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
using System.Xml;

namespace Hexware.Plist
{
    public partial class PlistInteger
    {
        public PlistInteger(string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentNullException("value");

            try
            {
                _value = Convert.ToInt64(value);
            }
            catch (FormatException)
            {
                throw new FormatException("\"" + value + "\" is not an integer");
            }
        }
        public PlistInteger(float value)
        {
            try
            {
                _value = Convert.ToInt64(value);
            }
            catch (FormatException)
            {
                throw new FormatException("\"" + value + "\" cannot be converted to an long");
            }
        }
        public PlistInteger(double value)
        {
            try
            {
                _value = Convert.ToInt64(value);
            }
            catch (FormatException)
            {
                throw new FormatException("\"" + value + "\" cannot be converted to an long");
            }
        }
        public PlistInteger(sbyte value)
        {
            _value = value;
        }
        public PlistInteger(byte value)
        {
            _value = value;
        }
        public PlistInteger(short value)
        {
            _value = value;
        }
        public PlistInteger(ushort value)
        {
            _value = value;
        }
        public PlistInteger(int value)
        {
            _value = value;
        }
        public PlistInteger(uint value)
        {
            _value = value;
        }
        public PlistInteger(long value)
        {
            _value = value;
        }
        public PlistInteger(ulong value)
        {
            try
            {
                _value = Convert.ToInt64(value);
            }
            catch (FormatException)
            {
                throw new FormatException("\"" + value + "\" cannot be converted to an long");
            }
        }
    }
    public partial class PlistInteger : IPlistElement<long>
    {
        internal long _value;

        public long Value
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
        public PlistElementType ElementType
        {
            get
            {
                return PlistElementType.Integer;
            }
        }
    }
    public partial class PlistInteger : IPlistElementInternal
    {
        internal static PlistInteger ReadBinary(BinaryReader reader, byte firstbyte)
        {
            int numofbytes = 1 << (firstbyte & 0x08);
            byte[] buf = reader.ReadBytes(numofbytes);
            if (BitConverter.IsLittleEndian)
                Array.Reverse(buf);

            if (numofbytes == 1) // 000
                return new PlistInteger(buf[0]);
            if (numofbytes == 2) // 001
                return new PlistInteger(BitConverter.ToUInt16(buf, 0));
            if (numofbytes == 4) // 010
                return new PlistInteger(BitConverter.ToUInt32(buf, 0));
            if (numofbytes == 8) // 011
                return new PlistInteger(BitConverter.ToInt64(buf, 0));

            // The specification uses the 3 bits to store the size,
            // allowing for integers up to 512 bits long. However,
            // CoreFoundation only implements support up to 128 bits.
            throw new PlistFormatException("Support does not exist for integers greater than 64 bits");
        }
        void IPlistElementInternal.WriteBinary(BinaryWriter writer)
        {
            byte[] buf;

            // 8, 16, and 32 bit integers have to be interpreted as unsigned,
            // whereas 64 bit integers are signed (and 16-byte when available).
            // Negative 8, 16, and 32 bit integers are always emitted as 8 bytes.
            // Integers are not required to be in the most compact possible
            // representation, but only the last 64 bits are significant.
            if (_value > UInt32.MaxValue || _value < 0) {
                writer.Write((byte)0x13);
                buf = BitConverter.GetBytes(_value);
            } else if (_value > UInt16.MaxValue) {
                writer.Write((byte)0x12);
                buf =  BitConverter.GetBytes((uint)_value);
            } else if (_value > Byte.MaxValue) {
                writer.Write((byte)0x11);
                buf = BitConverter.GetBytes((ushort)_value);
            } else {
                writer.Write((byte)0x10);
                writer.Write((byte)_value);
                return;
            }

            if (BitConverter.IsLittleEndian)
                Array.Reverse(buf);
            writer.Write(buf);
        }
        internal static PlistInteger ReadXml(XmlNode node)
        {
            return new PlistInteger(node.InnerText);
        }
        void IPlistElementInternal.WriteXml(XmlNode tree, XmlDocument writer)
        {
            XmlElement element = writer.CreateElement("integer");
            element.InnerText = _value.ToString();
            tree.AppendChild(element);
        }
    }
}