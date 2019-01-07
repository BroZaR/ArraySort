using Common.Enums;
using Common.Events;
using System;

namespace Common.Interfases
{
	public interface IModel
	{
		event Action<int[,]> UpdateMatrix;
		event EventHandler<EventUpdateMatrix> SortsMatrix;

		void InputMatrix(int[,] matrix);
		void SortMatrix(Sorts keyEnum);
	}
}
