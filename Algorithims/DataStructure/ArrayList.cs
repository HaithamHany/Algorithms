using System;

namespace Algorithims.DataStructure
{
	public class ArrayList<T>
	{
		private T[] _arr;
		private int _count;
		private const int INITIAL_CAPACITY = 4;

		/// <summary>
		/// Returns the length of the ArrayList
		/// </summary>
		public int Count
		{
			get { return _count; }
		}

		/// <summary>
		/// Initialising the Array based list 
		/// </summary>
		/// <param name="capacity">The capacity for the initial array. Default is 4 when capacity is not specified</param>
		public ArrayList(int capacity = INITIAL_CAPACITY)
		{
			this._arr = new T[capacity];
			this._count = 0;
		}

		/// <summary>
		/// Adding Element to the end of the list.
		/// Operation time Complixty is O(1). It takes only 1 step since its inserting in the end.
		/// O(N) Worst case if the base array needed to be grown
		/// </summary>
		/// <param name="item">The item to be added</param>
		public void Add(T item)
		{
			IncreaseArrIfFull();
			this._arr[this._count] = item;
			this._count++;
		}

		/// <summary>
		/// Insert element at a specific index. Operation time Complixty is O(N) for searching each element in the array.
		/// </summary>
		/// <param name="index">The index to be inserted in</param>
		/// <param name="item"> The item to be inserted</param>
		public void Insert(int index, T item)
		{
			if(index >this._count || index <0)
			{
				throw new IndexOutOfRangeException("invalid index: index does not index" + index);
			}

			IncreaseArrIfFull();
			Array.Copy(this._arr, index,this._arr, index+1 , this._count - index);
			this._arr[index] = item;
			this._count++;
		}

		/// <summary>
		/// Remove all elements in the ArrayList
		/// </summary>
		public void Clear()
		{
			//resetting everything 
			this._arr = new T[INITIAL_CAPACITY];
			this._count = 0;
		}


		/// <summary>
		/// Returns index of the first occurrence of the item
		/// Returns -1 if not found.
		/// Time Complexity is O(N) since its searching each element in the base array
		/// </summary>
		/// <param name="item">Item to return index of</param>
		/// <returns></returns>
		public int IndexOf(T item)
		{
			for (int i = 0; i < this._arr.Length; i++)
			{
				if(object.Equals(item, this._arr[i]))
				{
					return i;
				}
			}

			return -1;
		}

		/// <summary>
		/// Checks of the list contains item.
		/// Time complexity is O(N). Since its searching each item
		/// </summary>
		/// <param name="item">Item to check on</param>
		/// <returns></returns>
		public bool Contains(T item)
		{
			int index = IndexOf(item);
			bool found = (index != -1);

			return found;
		}

		/// <summary>
		/// Double base array size if full.
		/// If called(Rarley) complexity will be O(N)
		/// </summary>
		private void IncreaseArrIfFull()
		{
			//check if current count bigger than the base array length
			if(this._count + 1 > this._arr.Length)
			{
				//creating a new array double the original size
				T[] extendedArr = new T[this._arr.Length * 2];
				Array.Copy(this._arr, extendedArr, this._count);
				this._arr = extendedArr;
			}
		}

		/// <summary>
		/// Indexer to access list element by index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T this[int index]
		{
			get 
			{
				if(index >= this._count || index<0)
				{
					throw new ArgumentOutOfRangeException("Invalid index: " + index);
				}

				return this._arr[index];
			}
			set
			{
				if(index>= this._count || index <0)
				{
					throw new ArgumentOutOfRangeException("Invalid index " + index);
				}
				this._arr[index] = value;
			}
		}


		/// <summary>
		/// Removing at a specific Index
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T RemoveAt(int index)
		{
			if(index>= this._count || index <0)
			{
				throw new ArgumentOutOfRangeException("Invalid index: " + index);
			}

			T item = this._arr[index];
			Array.Copy(this._arr, index +1, this._arr, index, this._count - index - 1);
			this._arr[this._count - 1] = default(T);
			this._count--;

			return item;
		}

		/// <summary>
		/// Removing specific element
		/// </summary>
		/// <param name="item">element to be removed</param>
		/// <returns></returns>
		public int Remove(T item)
		{
			int index = IndexOf(item);
			if(index != -1)
			{
				this.RemoveAt(index);
			}

			return index;
		}

	}
}
