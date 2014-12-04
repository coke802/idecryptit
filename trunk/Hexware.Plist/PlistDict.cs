﻿/* =============================================================================
 * File:   PlistDict.cs
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
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace Hexware.Plist
{
    /// <summary>
    /// Represents a &lt;dict /&gt; tag using a <see cref="System.Collections.Generic.Dictionary{System.String, Hexware.Plist.IPlistElement}"/>
    /// </summary>
    public partial class PlistDict
    {
        /// <summary>
        /// Hexware.Plist.PlistDict constructor using a <see cref="System.Collections.Generic.Dictionary&lt;TKey, TValue&gt;"/>&lt;<see cref="System.String"/>, <see cref="Hexware.Plist.IPlistElement"/>&gt;
        /// </summary>
        /// <param name="value">The value of this node containing <see cref="Hexware.Plist.IPlistElement"/> objects</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        public PlistDict(Dictionary<string, IPlistElement> value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            _value = value;
        }

        /// <summary>
        /// Hexware.Plist.PlistArray constructor using a <see cref="System.Xml.XmlNodeList"/>
        /// </summary>
        /// <param name="value">A <see cref="System.Xml.XmlNodeList"/> containing the current array</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        /// <exception cref="Hexware.Plist.PlistFormatException">A node is invalid</exception>
        public PlistDict(XmlNodeList value)
        {
            if (value == null)
                throw new ArgumentNullException("value");

            Parse(value);
        }

        /// <summary>
        /// Adds an element to the array
        /// </summary>
        /// <param name="key">The key of the value to add</param>
        /// <param name="value">The value to add</param>
        /// <exception cref="System.ArgumentNullException">The provided key or value is null or empty</exception>
        /// <exception cref="System.StackOverflowException">The stack is too small</exception>
        /// <returns>The array after adding</returns>
        public PlistDict Add(string key, IPlistElement value)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key", "The specified key is null or empty");
            if (value == null)
                throw new ArgumentNullException("value", "The specified value is null");

            if (_value.ContainsKey(key))
                _value[key] = value;
            else
                _value.Add(key, value);

            return this;
        }

        /// <summary>
        /// Deletes an element from the array based on the index
        /// </summary>
        /// <param name="key">A zero-based index of the element to delete</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="key"/> is null or empty</exception>
        /// <exception cref="System.MissingFieldException"><paramref name="key"/> does not exist</exception>
        /// <returns>The array after deletion</returns>
        public PlistDict Delete(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key", "The specified key is null or empty");

            if (!_value.ContainsKey(key))
                throw new MissingFieldException("The specified key does not exist");

            _value.Remove(key);

            return this;
        }

        /// <summary>
        /// Determines if a provided key exists in the current dictionary
        /// </summary>
        /// <param name="key">The key to check for</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="key"/> is null or empty</exception>
        /// <returns><c>true</c> if the specified key exists; otherwise <c>false</c></returns>
        public bool Exists(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key", "The specified key is null or empty");

            return _value.ContainsKey(key);
        }

        /// <summary>
        /// Retrieves an element from the array based on a key
        /// </summary>
        /// <param name="key">The key of the element to retrieve</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="key"/> is null or empty</exception>
        /// <exception cref="System.IndexOutOfRangeException"><paramref name="key"/> does not exist in the array</exception>
        /// <returns>The value from the array</returns>
        public IPlistElement Get(string key)
        {
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key", "The specified key is null or empty");

            if (!_value.ContainsKey(key))
                throw new IndexOutOfRangeException("The specified key does not exist in the array");

            IPlistElement temp;
            _value.TryGetValue(key, out temp);
            return temp;
        }

        /// <summary>
        /// Retrieves an element from the array based on a key
        /// </summary>
        /// <typeparam name="T">The type to return of <see cref="Hexware.Plist.IPlistElement"/></typeparam>
        /// <param name="key">The key of the element to retrieve</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="key"/> is null or empty</exception>
        /// <exception cref="System.IndexOutOfRangeException"><paramref name="key"/> does not exist in the array</exception>
        /// <returns>The value from the array after casting</returns>
        public T Get<T>(string key) where T : IPlistElement
        {
            return (T)Get(key);
        }
        
        internal void Parse(XmlNodeList list)
        {
            if (list.Count % 2 == 1)
                throw new PlistFormatException("Plist dictionary is not valid");

            _value = new Dictionary<string, IPlistElement>(list.Count);

            for (int i = 0; i < list.Count; i = i + 2)
            {
                string key = list[i].InnerText;
                string valueType = list[i + 1].Name;

                if (list[i].Name != "key" ||
                    key.Contains("<") ||
                    key.Contains(">"))
                {
                    throw new PlistFormatException("\"" + list[i].InnerXml + "\" is not a valid Plist key");
                }

                if (valueType == "array")
                    _value.Add(key, new PlistArray(list[i + 1].ChildNodes));
                else if (valueType == "true")
                    _value.Add(key, new PlistBool(true));
                else if (valueType == "false")
                    _value.Add(key, new PlistBool(false));
                else if (valueType == "data")
                    _value.Add(key, new PlistData(list[i + 1].InnerText));
                else if (valueType == "date")
                    _value.Add(key, new PlistDate(list[i + 1].InnerText));
                else if (valueType == "dict")
                    _value.Add(key, new PlistDict(list[i + 1].ChildNodes));
                else if (valueType == "fill")
                    _value.Add(key, new PlistFill());
                else if (valueType == "integer")
                    _value.Add(key, new PlistInteger(list[i + 1].InnerText));
                else if (valueType == "null")
                    _value.Add(key, new PlistNull());
                else if (valueType == "real")
                    _value.Add(key, new PlistReal(list[i + 1].InnerText));
                else if (valueType == "string" || valueType == "ustring")
                    _value.Add(key, new PlistString(list[i + 1].InnerText));
                else if (valueType == "uid")
                    _value.Add(key, new PlistUid(Encoding.ASCII.GetBytes(list[i + 1].InnerText)));
                else if (valueType == "ustring")
                    _value.Add(key, new PlistString(list[i + 1].InnerText));
                else
                    throw new PlistFormatException("Plist element is not a valid element");
            }
        }

        /// <summary>
        /// Gets a <see cref="System.Collections.Generic.ICollection&lt;T&gt;"/>&lt;<see cref="System.String"/>&gt; collection of the keys
        /// </summary>
        public ICollection<string> Keys
        {
            get
            {
                return _value.Keys;
            }
        }

        /// <summary>
        /// Gets a <see cref="System.Collections.Generic.ICollection&lt;T&gt;"/>&lt;<see cref="Hexware.Plist.IPlistElement"/>&gt; collection of the values
        /// </summary>
        public ICollection<IPlistElement> Values
        {
            get
            {
                return _value.Values;
            }
        }

        /// <summary>
        /// Gets or sets a value in this element
        /// </summary>
        /// <param name="key">The key for the element to retrieve or set</param>
        /// <exception cref="System.ArgumentNullException">A value is null</exception>
        /// <exception cref="System.IndexOutOfRangeException"><paramref name="key"/> does not exist in the array</exception>
        /// <returns>The value at the specified key</returns>
        public IPlistElement this[string key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Gets the number of nodes underneath this element
        /// </summary>
        /// <returns>Amount of elements inside</returns>
        public int GetPlistElementLength()
        {
            return _value.Count;
        }
    }
    public partial class PlistDict
    {
        internal static PlistDict ReadBinary(BinaryReader reader, byte firstbyte)
        {
            throw new NotImplementedException();
        }

        internal byte[] WriteBinary()
        {
            throw new NotImplementedException();
        }

        internal static PlistDict ReadXml(XmlDocument reader, int index)
        {
            throw new NotImplementedException();
        }

        internal void WriteXml(XmlNode tree, XmlDocument writer)
        {
            throw new NotImplementedException();
        }
    }
    public partial class PlistDict : IPlistElement<Dictionary<string, IPlistElement>, Container>
    {
        internal Dictionary<string, IPlistElement> _value;

        /// <summary>
        /// Gets the Xml tag for this element
        /// </summary>
        public string XmlTag
        {
            get
            {
                return "dict";
            }
        }

        /// <summary>
        /// Gets or sets the value of this element
        /// </summary>
        /// <param name="value">The value of this node</param>
        /// <exception cref="System.ArgumentNullException"><paramref name="value"/> is null</exception>
        public Dictionary<string, IPlistElement> Value
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
        /// Gets the type of this element as one of <see cref="Hexware.Plist.Container"/> or <see cref="Hexware.Plist.Primitive"/>
        /// </summary>
        public Container ElementType
        {
            get
            {
                return Container.Dict;
            }
        }

        /// <summary>
        /// Gets the length of this element when written in binary mode
        /// </summary>
        /// <returns>Containers return the amount inside while Primitives return the binary length</returns>
        public int GetPlistElementBinaryLength()
        {
            throw new NotImplementedException();
        }
    }
}