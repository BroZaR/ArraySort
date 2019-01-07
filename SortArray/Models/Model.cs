using Common.Enums;
using Common.Events;
using Common.Interfases;
using Common.SortController;
using System;
using System.Diagnostics;

namespace SortArray.Models
{
	public class Model : IModel
	{
		private int[,] matrix;

		public event Action<int[,]> UpdateMatrix;
		public event EventHandler<EventUpdateMatrix> SortsMatrix;

		public void InputMatrix(int[,] _matrix)
		{
			matrix = _matrix;
			UpdateMatrix(matrix);
		}

		public void SortMatrix(Sorts keyEnum)
		{
			ISort sorter;
			switch (keyEnum) {
				case (Sorts)1:
					sorter = new BubbleSort(matrix);
					break;
				case (Sorts)2:
					sorter = new SortInserts(matrix);
					break;
				case (Sorts)3:
					sorter = new SortBySelection(matrix);
					break;
				/*case (Sorts)4:
					sorter = new MergeSort(matrix);
					break;
				case (Sorts)5:
					sorter = new QuickSort(matrix);
					break;*/
				default:
					sorter = new BubbleSort(matrix);
					break;
			}
			var timer = new Stopwatch();
			timer.Start();
			matrix = sorter.Sort();
			timer.Stop();

			SortsMatrix(this, new EventUpdateMatrix(matrix, timer.Elapsed, keyEnum));
		}
	}
}
