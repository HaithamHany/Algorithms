using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	/// <summary>
	/// Represents Tree data structure
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class Tree<T>
	{
		private TreeNode<T> _root;
		public TreeNode<T> Root { get { return _root; } }
		
		public Tree(T value)
		{
			if (value == null)
				throw new ArgumentException("Cannot insert null value!");

			this._root = new TreeNode<T>(value);
		}

		
		private void PrintDFS(TreeNode<T> root, string spaces)
		{
			if(this._root == null)
			{
				return;
			}

			Console.WriteLine(spaces + root.Value);

			TreeNode<T> child = null;

			for (int i = 0; i < root.ChildrenCount; i++)
			{
				child = root.GetChild(i);
				PrintDFS(child, spaces + "   ");
			}
		}

		
	}
}
