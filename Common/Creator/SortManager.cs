using Common.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Creator
{
	public abstract class SortManager
	{
		public abstract ISort CreateClassSort();

		public int[,] Sorting(int[,] matrix) {
			ISort sorter = CreateClassSort();
			sorter.Matrix = matrix;

			return sorter.Sort();
		}
	}
}
