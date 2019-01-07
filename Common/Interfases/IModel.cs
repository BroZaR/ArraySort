using Common.Enums;
using Common.Events;
using System;

namespace Common.Interfases
{
	public interface IModel
	{
		event EventHandler<EventUpdateMatrix> UpdateMatrix;

		void InputMatrix(int[,] matrix);
		void SortMatrix(Sorts keyEnum);
	}
}
