using System;
using System.Collections.Generic;
using System.Text;

namespace Algorithims.Algorithms.Search
{
	/// <summary>
	/// Searching Algorithms
	/// </summary>
	public class SearchAlgo
	{
		/// <summary>
		/// Searching for specific element in an array.
		/// Time complexity is O(LogN)
		/// </summary>
		/// <param name="arr"></param>
		/// <param name="element"></param>
		public object BinarySearch(int[] arr, int element)
		{
			int min = 0;
			int max = arr.Length - 1;

			while (min <= max)
			{
				int mid = (min + max) / 2;
				if (element == arr[mid])
					return ++mid;
				else if (element < arr[mid])
					max = min - 1;
				else if (element > arr[mid])
					min = mid + 1;
			}

			return null;
		}

	}
}
