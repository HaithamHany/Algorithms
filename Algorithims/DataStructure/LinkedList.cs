using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	public class LinkedList<T>
	{
		private class ListNode
		{
			public T Element { get; set; }
			public ListNode Next { get; set; }
			public ListNode Prev { get; set; }
			public int Count { get; set; }

			public ListNode(T element)
			{
				this.Element = element;
				Next = null;
			}

			public ListNode(T element, ListNode prevNode)
			{
				this.Element = element;
				prevNode.Next = this;
			}
		}

		private ListNode _head;
		private ListNode _tail;
		private int _count;

		public LinkedList()
		{
			this._head = null;
			this._tail = null;
			this._count = 0;
		}

		/// <summary>
		/// Adding Element at the end of list.
		/// Time Complexity is O(1)
		/// </summary>
		/// <param name="item"></param>
		public void Add(T item)
		{
			ListNode newNode = new ListNode(item);
			if (this._head == null)
			{
				this._head = newNode;
				this._tail = this._head;
			}
			else
			{
				newNode.Prev = this._tail;
				this._tail.Next = newNode;
				this._tail = newNode;
			}

			_count++;
		}

		/// <summary>
		/// Removing element at a specific Index.
		/// Time Complexity is O(N) since its iterating through every element. Time increases linerly with the size of the input
		/// </summary>
		/// <param name="index"></param>
		/// <returns></returns>
		public T RemoveAt(int index)
		{
			if(index>= _count || index <0)
			{
				throw new ArgumentOutOfRangeException("Invalid index: " + index);
			}

			//find element at a specific index
			int currentIndex = 0;
			ListNode currNode = this._head;
			ListNode prevNode = null;

			while (currentIndex<index)
			{
				prevNode = currNode;
				currNode = currNode.Next;
				currentIndex++;
			}

			return currNode.Element;

		}

		public int Remove(T item)
		{
			int currentIndex = 0;
			ListNode currNode = this._head;
			ListNode prevNode = null;

			while (currNode != null)
			{
				if (object.Equals(currNode.Element, item))
					break;

				prevNode = currNode;
				currNode = currNode.Next;
				currentIndex++;
			}

			if(currNode!=null)
			{
				RemoveListNode(currNode, prevNode);
				return currentIndex;
			}
			else
			{
				return -1;
			}

		}

		/// <summary>
		/// Removing a specified node from the list of nodes
		/// </summary>
		/// <param name="node">current node</param>
		/// <param name="prevNode">previous node</param>
		private void RemoveListNode(ListNode node, ListNode prevNode)
		{
			_count--;
			//if list is empty
			if(_count ==0)
			{
				this._head = null;
				this._tail = null;
			}
			else if(prevNode == null)
			{
				//if the head node was removed, update the head
				this._head = node.Next;
			}
			else
			{
				prevNode.Next = node.Next;
			}

			if (object.ReferenceEquals(this._tail, node)) 
			{ 
				this._tail = prevNode;
			}
		}

		/// <summary>
		/// Returning index of item
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public int IndexOf(T item)
		{
			int index = 0;
			ListNode currNode = this._head;

			while (currNode!=null)
			{
				if(object.Equals(currNode.Element, item))
				{
					return index;
				}

				currNode = currNode.Next;
				index++;
			}

			return -1;
		}

		/// <summary>
		/// Checks if item is contained in the lineked list
		/// </summary>
		/// <param name="item"></param>
		/// <returns></returns>
		public bool Contains(T item)
		{
			int index = IndexOf(item);
			bool found = (index != -1);

			return found;
		}

	}
}
