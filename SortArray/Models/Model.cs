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
			TimeSpan[] time;
			Sorts[] sort;
			if (keyEnum != (Sorts)6)
			{
				time = new TimeSpan[] { Sorter(keyEnum) };
				sort = new Sorts[] { keyEnum };
			}
			else {
				int i = 0;
				int count = Enum.GetValues(typeof(Sorts)).Length;
				time = new TimeSpan[count - 1];
				sort = new Sorts[count - 1];
				foreach (Sorts el in Enum.GetValues(typeof(Sorts))) {
					if ((int)el == 6) {
						continue;
					}
					time[i] = Sorter(el, false);
					sort[i] = el;
					i++;
				}
				Sorter((Sorts)1);
			}

			SortsMatrix(this, new EventUpdateMatrix(matrix, time, sort));
		}

		private TimeSpan Sorter(Sorts key, bool in_save = true) {
			ISort sorter;
			switch (key)
			{
				case (Sorts)1:
					sorter = new BubbleSort(matrix);
					break;
				case (Sorts)2:
					sorter = new SortInserts(matrix);
					break;
				case (Sorts)3:
					sorter = new SortBySelection(matrix);
					break;
				case (Sorts)5:
					sorter = new QuickSort(matrix);
					break;
				default:
					sorter = new BubbleSort(matrix);
					break;
			}
			var timer = new Stopwatch();
			
			if (in_save) {
				timer.Start();
				matrix = sorter.Sort();
				timer.Stop();
			} else {
				int[,] mat;
				timer.Start();
				mat = sorter.Sort();
				timer.Stop();
			}

			return timer.Elapsed;
		}
	}
}
