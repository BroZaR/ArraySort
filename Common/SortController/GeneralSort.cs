using Common.Interfases;

namespace Common.SortController
{
	public abstract class GeneralSort : ISort
	{
		protected int[,] matrix;
		protected int row;

		public GeneralSort(int[,] _matrix) {
			matrix = _matrix;
			row = _matrix.GetUpperBound(0) + 1;
		}

		public abstract int[,] Sort();

		protected void Swap(int[] left, int[] right)
		{
			if (left != right)
			{
				int temp = matrix[left[0],left[1]];
				matrix[left[0], left[1]] = matrix[right[0], right[1]];
				matrix[right[0], right[1]] = temp;
			}
		}
	}
}
