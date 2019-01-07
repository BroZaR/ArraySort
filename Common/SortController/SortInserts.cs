using Common.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.SortController
{
	public class SortInserts : GeneralSort, ISort
	{
		public SortInserts(int[,] _matrix) : base(_matrix) { }

		/*public int[,] Sort()
		{
			
		}*/
	}
}
