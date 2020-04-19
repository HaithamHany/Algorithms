using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	public class Graph<T>
	{

		private List<Node> _nodes;

		public class Node
		{
			private T _data;

			public T Data
			{
				get { return _data; }
				set { _data = value; }
			}

			private List<Node> _children;

			public Node(T data)
			{
				_children = new List<Node>();
			}

		}

		public Graph()
		{
			_nodes = new List<Node>();
		}
	}
}
