namespace Common.SortController
{
	public abstract class GeneralSort
	{
		protected int[,] matrix;

		public GeneralSort(int[,] _matrix) {
			matrix = _matrix;
		}

		protected void Swap(int[,] items, int[] left, int[] right)
		{
			if (left != right)
			{
				int temp = items[left[0],left[1]];
				items[left[0], left[1]] = items[right[0], right[1]];
				items[right[0], right[1]] = temp;
			}
		}
	}
}
