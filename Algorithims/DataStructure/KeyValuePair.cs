using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	/// <summary>
	/// Key-Value pair Node for HashTable
	/// </summary>
	/// <typeparam name="TKey"></typeparam>
	/// <typeparam name="TValue"></typeparam>
	public class KeyValuePair<TKey, TValue>
	{
		public TKey Key { get;  set; }

		public TValue Value { get;  set; }

		//for chaining collisions
		public KeyValuePair<TKey, TValue> Next;

		public KeyValuePair(TKey key, TValue value)
		{
			this.Key = key;
			this.Value = value;
		}

	}
}
