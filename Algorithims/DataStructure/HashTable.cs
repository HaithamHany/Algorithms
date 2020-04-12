using System;

namespace Algorithims.DataStructure
{
	public class HashTable<Key, Value>
	{
		//used to store array of chains
		private ArrayList<KeyValuePair<Key,Value>> _tableArray;
		//Capacity of the array list
		private int _capacity;
		private int _count;

		//for initializing capacity, size and empty chains
		public HashTable()
		{
			_tableArray = new ArrayList<KeyValuePair<Key, Value>>();
			_capacity = 10;
			_count = 0;

			//Create empty chains
			for (int i = 0; i < _capacity; i++)
			{
				_tableArray.Add(null);
			}
		}

		public int Count { get { return _count; } }
		
		public bool IsEmpty
		{
			get { return _count == 0; }
		}

		private int GetArrayIndex(Key key)
		{
			int hashCode = key.GetHashCode();
			int index = hashCode % _capacity;

			return index;
		}

		public Value Remove (Key key)
		{
			//Applying hash function to find index for a key
			int index = GetArrayIndex(key);

			//Get head of chain
			KeyValuePair<Key, Value> head = _tableArray[index];

			//Search fir the Key in its chain
			KeyValuePair<Key, Value> prev = null;

			while (head != null)
			{
				if (head.Key.Equals(key))
					break;

				prev = head;
				head = head.Next;
			}

			if (head == null)
				return default(Value);

			_count--;

			if (head != null)
				prev.Next = head.Next;
			else
				_tableArray[index] = head.Next;

			return head.Value;
		}

		/// <summary>
		/// Returns a value.
		/// </summary>
		/// <param name="key">Key used to map the value to be returned</param>
		/// <returns></returns>
		public Value Get(Key key)
		{
			int index = GetArrayIndex(key);
			KeyValuePair<Key, Value> head = _tableArray[index];

			while (head != null)
			{
				if (head.Key.Equals(key))
				{
					head = head.Next;
				}
			}

			return default(Value);
		}

		public void Add( Key key, Value value)
		{
			//find head of chain for given key
			int index = GetArrayIndex(key);
			KeyValuePair<Key, Value> head = _tableArray[index];

			//Check if key is already present
			while(head !=null)
			{
				if(head.Key.Equals(key))
				{
					head.Value = value;
				}

				head = head.Next;
			}

			//insert key in the chain
			_count++;
			head = _tableArray[index];
			KeyValuePair<Key, Value> newNode = new KeyValuePair<Key, Value>(key, value);
			newNode.Next = head;
			_tableArray[index] = newNode;

			//double hash table size if load factor goes beyond threshold which is 0.7
			if((1.0*_count)/_capacity >= 0.7)
			{
				ArrayList<KeyValuePair<Key, Value>> temp = _tableArray;
				_tableArray = new ArrayList<KeyValuePair<Key, Value>>();
				_capacity = 2 * _capacity;
				_count = 0;

				for (int i = 0; i < _capacity; i++)
				{
					_tableArray.Add(null);
				}

				while (head!=null)
				{
					while (head!=null)
					{
						Add(head.Key, head.Value);
						head = head.Next;
					}
					head = head.Next;
				}
			}
		}
	}
}
