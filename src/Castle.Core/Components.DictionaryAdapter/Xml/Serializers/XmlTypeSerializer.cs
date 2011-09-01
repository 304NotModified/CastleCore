﻿// Copyright 2004-2011 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.f
// See the License for the specific language governing permissions and
// limitations under the License.

#if !SILVERLIGHT
namespace Castle.Components.DictionaryAdapter.Xml
{
	using System;
	using System.Xml.XPath;
	using System.Xml.Serialization;

	public abstract class XmlTypeSerializer
	{
		protected XmlTypeSerializer() { }

		public virtual bool IsCollection
		{
			get { return false; }
		}

		public virtual bool CanSerializeAsAttribute
		{
			get { return true; }
		}

		public virtual bool CanGetStub
		{
			get { return false; }
		}

		public virtual void SetValue(XmlIterator iterator, IXmlAccessor accessor, object value)
		{
			if (!iterator.MoveNext())
				iterator.Create(value.GetType());
			SetValue(iterator.Current, accessor, value);
		}

		public virtual  object GetStub (XmlIterator iterator, IDictionaryAdapter parent, IXmlAccessor accessor) { throw Error.NotSupported(); }
		public abstract object GetValue(XmlTypedNode node,    IDictionaryAdapter parent, IXmlAccessor accessor);
		public abstract void   SetValue(XmlTypedNode node,                               IXmlAccessor accessor, object value);

		public static XmlTypeSerializer For(Type type)
		{
			return XmlTypeSerializerCache.Instance[type];
		}
	}
}
#endif