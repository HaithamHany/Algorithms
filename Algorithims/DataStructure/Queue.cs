using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	public class Queue<T>
	{
		private QueueNode _first;
		private QueueNode _last;

		private  class QueueNode
		{
			private T _data;
			private QueueNode _next;

			public T Data { get { return _data; } set { _data = value; } }
			public QueueNode Next { get { return _next; } set { _next = value; } } 

			public QueueNode(T data)
			{
				this._data = data;
			}
		}

		/// <summary>
		/// Adding new item to the queue
		/// Time Complexity is O(1)
		/// </summary>
		/// <param name="item">Item to be added</param>
		public void Enqueue(T item)
		{
			QueueNode newNode = new QueueNode(item);
			if(_last != null)
			{
				_last.Next = newNode;
			}
			_last = newNode;
			if (_first == null)
				_first = _last;
		}

		/// <summary>
		/// Removing the last element and returning it
		/// Time Complexity is O(1)
		/// </summary>
		/// <returns></returns>
		public T Dequeue()
		{
			if (_first == null)
				throw new Exception("Queue is empty");

			T data = _first.Data;
			_first = _first.Next;

			if (_first == null)
				_last = null;

			return data;
		}

		/// <summary>
		/// Returning First item without removing it
		/// Time Complexity is O(1)
		/// </summary>
		/// <returns></returns>
		public T peek()
		{
			if (_first == null)
				throw new Exception("Queue is empty");
			return _first.Data;
		}

		/// <summary>
		/// Checking if Queue is Empty
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			return _first == null;
		}
	}
}
