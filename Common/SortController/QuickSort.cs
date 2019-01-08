using Common.Interfases;
using System;

namespace Common.SortController
{
	public class QuickSort : GeneralSort, ISort
	{
		private Random _pivotRng = new Random();

		public QuickSort(int[,] _matrix) : base(_matrix) { }

		public int[,] Sort()
		{
			quicksort(0, matrix.Length - 1);

			return matrix;
		}

		private void quicksort(int left, int right)
		{
			if (left < right)
			{
				int pivotIndex = _pivotRng.Next(left, right);
				int newPivot = partition(left, right, pivotIndex);

				quicksort(left, newPivot - 1);
				quicksort(newPivot + 1, right);
			}
		}

		private int partition(int left, int right, int pivotIndex)
		{
			int pivotValue = matrix[pivotIndex % row, pivotIndex / row];

			Swap(new int[] { pivotIndex% row, pivotIndex / row }, new int[] { right % row, right / row });

			int storeIndex = left;

			for (int i = left; i < right; i++)
			{
				if (matrix[i % row,i / row].CompareTo(pivotValue) < 0)
				{
					Swap(new int[] { i % row,i / row }, new int[] { storeIndex % row, storeIndex / row });
					storeIndex += 1;
				}
			}

			Swap(new int[] { storeIndex % row, storeIndex / row }, new int[] { right % row, right / row });
			return storeIndex;
		}
	}
}
