using SortArray.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Interfases
{
	public interface IModel
	{
		int[,] Matrix { get; }

		void Sort(ISort sort);

		event EventHandler<EventSortArray> UpdateArray;
	}
}
