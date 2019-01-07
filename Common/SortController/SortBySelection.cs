using Common.Interfases;

namespace Common.SortController
{
	public class SortBySelection : GeneralSort, ISort
	{
		public SortBySelection(int[,] _matrix) : base(_matrix) { }

		public int[,] Sort()
		{
			int sortedRangeEnd = 0;

			while (sortedRangeEnd < matrix.Length)
			{
				int nextIndex = FindIndexOfSmallestFromIndex(sortedRangeEnd);
				Swap(new int[] { sortedRangeEnd % row, sortedRangeEnd / row }, new int[] { nextIndex % row, nextIndex / row });

				sortedRangeEnd++;
			}

			return matrix;
		}

		private int FindIndexOfSmallestFromIndex(int sortedRangeEnd)
		{
			int currentSmallest = matrix[sortedRangeEnd % row, sortedRangeEnd / row];
			int currentSmallestIndex = sortedRangeEnd;

			for (int i = sortedRangeEnd + 1; i < matrix.Length; i++)
			{
				if (currentSmallest.CompareTo(matrix[i % row,i / row]) > 0)
				{
					currentSmallest = matrix[i % row, i / row];
					currentSmallestIndex = i;
				}
			}

			return currentSmallestIndex;
		}
	}
}
