using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Interfases
{
	public interface ISort
	{
		int[,] Matrix { get; set; }

		int[,] Sort();
	}
}
