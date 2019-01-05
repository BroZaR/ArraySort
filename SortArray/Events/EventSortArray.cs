using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Events
{
	public class EventSortArray : EventArgs
	{
		public int[,] matrix;

		public EventSortArray(int[,] _matrix) {
			matrix = _matrix;
		}
	}
}
