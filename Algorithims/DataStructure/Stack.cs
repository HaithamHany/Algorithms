using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	/// <summary>
	/// Linked-List based Stack
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Stack<T>
	{

		private StackNode _top;
		private StackNode Top { get; set; }

		private  class StackNode
		{
			private T _data;
			private StackNode _next;

			public StackNode(T data)
			{
				this._data = data;
			}

			public T Data { get { return _data; } }

			public StackNode Next { get { return _next; } set { _next = value; } }
		}

		/// <summary>
		/// Popping last Top element
		/// Time Complixity is O(1)
		/// </summary>
		/// <returns></returns>
		public T Pop()
		{
			if(_top == null )
				throw new Exception("Stack Is Empty");

			T item = _top.Data;
			_top = _top.Next;

			return item;
		}

		/// <summary>
		/// Inserting Element in the top of the Stack
		/// Time Complexity is O(1)
		/// </summary>
		/// <param name="item">Item to be added</param>
		public void Push( T item)
		{
			StackNode newNode = new StackNode(item);
			newNode.Next = _top;
			_top = newNode;
		}

		/// <summary>
		/// Returning the top element without removing it
		/// Time Complexity is O(1)
		/// </summary>
		/// <returns></returns>
		public T Peek()
		{
			if (_top == null)
				throw new Exception(" Stack is EMpty");

			return _top.Data;
		}

		/// <summary>
		/// Checking if Stack is Empty
		/// </summary>
		/// <returns></returns>
		public bool IsEmpty()
		{
			return _top == null;
		}
		
	}
}
