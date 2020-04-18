using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	public class TreeNode<T>
	{
		private T _value;
		private bool _hasParent;
		private List<TreeNode<T>> _children;

		public T Value { get { return this._value; } set { this._value = value; } }

		public int ChildrenCount { get { return this._children.Count; } }

		/// <summary>
		/// Constructing a Node
		/// </summary>
		/// <param name="value"></param>
		public TreeNode(T value)
		{
			if(value == null)
			{
				throw new ArgumentNullException("Cannot insert null value!");
			}
			this._value = value;
			this._children = new List<TreeNode<T>>();
		}

		/// <summary>
		/// Adds a child to the node
		/// </summary>
		/// <param name="child">Child to be added</param>
		public void AddChild(TreeNode<T> child)
		{
			if(child == null)
				throw new ArgumentException("Cannot insert null value");

			if (child._hasParent)
				throw new ArgumentException("The node already has a parent!");

			child._hasParent = true;
			this._children.Add(child);
		}

		public void AddChild(T value)
		{
			TreeNode<T> newNode = new TreeNode<T>(value);

			newNode._hasParent = true;
			this._children.Add(newNode);
		}

		/// <summary>
		/// Get a child on a specific position
		/// </summary>
		/// <param name="index">Index of child</param>
		/// <returns></returns>
		public TreeNode<T> GetChild(int index)
		{
			return this._children[index];
		}

	}
}
