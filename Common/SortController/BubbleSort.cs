using Common.Interfases;

namespace Common.SortController
{
	public class BubbleSort : GeneralSort, ISort
	{
		public BubbleSort(int[,] _matrix) : base(_matrix) { }

		public int[,] Sort()
		{
			bool swapped;
			int row = matrix.GetUpperBound(0) + 1;

			do
			{
				swapped = false;
				for (int i = 1; i < matrix.Length; i++)
				{
					if (matrix[(i - 1) % row, (i - 1) / row].CompareTo(matrix[i % row, i / row]) > 0)
					{
						Swap(matrix, new int[] { (i - 1) % row, (i - 1) / row }, new int[] { i % row, i / row });
						swapped = true;
					}
				}
			} while (swapped != false);

			return matrix;
		}
	}
}
