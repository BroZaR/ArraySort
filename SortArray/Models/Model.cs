using Common.Creator;
using Common.Enums;
using Common.Events;
using Common.Interfases;
using Common.SortController;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SortArray.Models
{
	public class Model : IModel
	{
		private int[,] matrix;
		public Dictionary<Sorts, SortManager> CreateSorter = new Dictionary<Sorts, SortManager> {
			{  Sorts.BubbleSort, new BubbleSortManager() },
			{  Sorts.SortInserts, new InsertsSortManager() },
			{  Sorts.SortBySelection, new SelectionSortManager() },
			{  Sorts.QuickSort, new QuickSortManager() }
		};

		public event Action<int[,]> UpdateMatrix;
		public event EventHandler<EventUpdateMatrix> SortsMatrix;

		public void InputMatrix(int[,] _matrix)
		{
			matrix = _matrix;
			UpdateMatrix(matrix);
		}

		public void SortMatrix(Sorts keyEnum) {
			SortManager sortManager;

			if (keyEnum == Sorts.AllSorts)
			{
				foreach (Sorts el in Enum.GetValues(typeof(Sorts)))
				{
					if (el == Sorts.AllSorts)
					{
						continue;
					}
					sortManager = CreateSorter[el];
					Sorter(sortManager, el);
				}
			}
			else {
				sortManager = CreateSorter[keyEnum];
				Sorter(sortManager, keyEnum);
			}
		}

		private void Sorter(SortManager sortManager, Sorts type) {

			var timer = new Stopwatch();
			int[,] mat;

			timer.Start();
			mat = sortManager.Sorting(CopyMatrix());
			timer.Stop();

			SortsMatrix(this, new EventUpdateMatrix(mat, timer.Elapsed, type));
		}

		private int[,] CopyMatrix() {
			int row = matrix.GetUpperBound(0) + 1;
			int coll = matrix.Length / row;

			int[,] mat = new int[row, coll];
			for (int r = 0; r < row; r ++) {
				for (int c = 0; c < coll; c++)
				{
					mat[r, c] = matrix[r, c];
				}
			}

			return mat;
		}

		/*public void SortMatrix(Sorts keyEnum)
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
					sorter = new BubbleSort();
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
					sorter = new BubbleSort();
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
		}*/
	}
}
