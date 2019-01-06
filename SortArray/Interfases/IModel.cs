using Common.Enums;
using Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Interfases
{
	public interface IModel
	{
		event EventHandler<EventUpdateMatrix> UpdateMatrix;

		void InputMatrix(int[,] matrix);
		void SortMatrix(Sorts keyEnum);
	}
}
