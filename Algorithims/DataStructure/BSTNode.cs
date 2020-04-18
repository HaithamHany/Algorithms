using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.DataStructure
{
	public class BSTNode
	{
		private int _data;
		private BSTNode _left;
		private BSTNode bSTNode;

		public BSTNode Right
		{
			get { return bSTNode; }
			set { bSTNode = value; }
		}


		public BSTNode Left
		{
			get { return _left; }
			set { _left = value; }
		}

		public int Data
		{
			get { return _data; }
			set { _data = value; }
		}


		public void DisplayNode()
		{
			Console.Write(_data);
		}
	}
}
