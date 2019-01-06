using Common.Events;
using SortArray.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		public void SortMatrix(int keyEnum)
		{
			throw new NotImplementedException();
		}
	}
}
