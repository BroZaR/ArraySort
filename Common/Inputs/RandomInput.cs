using Common.Interfases;
using System;

namespace Common.Inputs
{
	public class RandomInput : IInput
	{
		private int row;
		private int coll;
		private int max;

		public RandomInput(int _row, int _coll, int _max) {
			row = _row;
			coll = _coll;
			max = _max;
		}

		public int[,] Leading()
		{
			int[,] mat = new int[row, coll];
			Random rand = new Random();
			for (int i = 0; i < coll; i++)
			{
				for (int j = 0; j < row; j++)
				{
					mat[j,i] = rand.Next(max);
				}
			}

			return mat;
		}
	}
}
