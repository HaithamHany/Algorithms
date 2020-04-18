using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	/// <summary>
	/// Implementation for Binary Search Tree
	/// </summary>
	public class BST
	{
		private BSTNode _root;

		public BSTNode Root { get { return _root; } }

		public BST()
		{
			_root = null;
		}

		public void Insert(int data)
		{
			BSTNode newNode = new BSTNode();
			newNode.Data = data;

			if (_root == null)
				_root = newNode;
			else
			{
				BSTNode currentNode = _root;
				BSTNode parent;

				while (true)
				{
					parent = currentNode;
					if(data < currentNode.Data)
					{
						currentNode = currentNode.Left;
						if(currentNode ==null)
						{
							parent.Left = newNode;
							break;
						}
					}
					else
					{
						currentNode = currentNode.Right;
						if(currentNode == null)
						{
							parent.Right = newNode;
							break;
						}
					}

				}
			}

		}

		public void TraverseInOrder(BSTNode root)
		{
			if(root!=null)
			{
				TraverseInOrder(root.Left);
				root.DisplayNode();
				TraverseInOrder(root.Right);
			}
		}

		public void TraversePreOrder(BSTNode root)
		{
			if(root!=null)
			{
				root.DisplayNode();
				TraversePreOrder(root.Left);
				TraversePreOrder(root.Right);
			}
		}

		public void TraversePostOrder(BSTNode root)
		{
			if(root!=null)
			{
				TraversePreOrder(root.Left);
				TraversePreOrder(root.Right);
				root.DisplayNode();
			}
		}
	}
}
