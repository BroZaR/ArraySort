using SortArray.Events;
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
		public int[,] Matrix {
			get {
				return matrix;
			} private set {
				if (value != null) {
					matrix = value;
				}
			}
		}

		public event EventHandler<EventSortArray> UpdateArray;

		public void Sort(ISort sort)
		{
			sort.Matrix = Matrix;
			Matrix = sort.Sort();
			UpdateArray(this, new EventSortArray(Matrix));
		}
	}
}
