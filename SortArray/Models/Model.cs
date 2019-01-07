using Common.Enums;
using Common.Events;
using Common.Interfases;
using System;

namespace SortArray.Models
{
	public class Model : IModel
	{
		private int[,] matrix;

		public event EventHandler<EventUpdateMatrix> UpdateMatrix;

		public void InputMatrix(int[,] _matrix)
		{
			matrix = _matrix;
			UpdateMatrix(this, new EventUpdateMatrix(matrix));
		}

		public void SortMatrix(Sorts keyEnum)
		{
			throw new NotImplementedException();
		}
	}
}
