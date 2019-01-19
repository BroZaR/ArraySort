using Common.Interfases;
using System;

namespace Common.SortController
{
	public class SortInserts : GeneralSort
	{
		public SortInserts() { }

		public override int[,] Sort()
		{
			int sortedRangeEndIndex = 1;

			while (sortedRangeEndIndex < matrix.Length)
			{
				if (matrix[sortedRangeEndIndex % row, sortedRangeEndIndex / row]
					.CompareTo(matrix[(sortedRangeEndIndex - 1) % row,(sortedRangeEndIndex - 1) / row]) < 0)
				{
					int insertIndex = FindInsertionIndex(matrix[sortedRangeEndIndex % row, sortedRangeEndIndex / row]);
					Insert(insertIndex, sortedRangeEndIndex);
				}

				sortedRangeEndIndex++;
			}

			return matrix;
		}

		private int FindInsertionIndex(int valueToInsert)
		{
			for (int index = 0; index < matrix.Length; index++)
			{
				if (matrix[index % row,index/row].CompareTo(valueToInsert) > 0)
				{
					return index;
				}
			}

			throw new InvalidOperationException("The insertion index was not found");
		}

		private void Insert(int indexInsertingAt, int indexInsertingFrom)
		{
			// matrix =       0 1 2 4 5 6 3 7
			// insertingAt =     3
			// insertingFrom =   6
			// 
			// Действия:
			//  1: Сохранить текущий индекс в temp
			//  2: Заменить indexInsertingAt на indexInsertingFrom
			//  3: Заменить indexInsertingAt на indexInsertingFrom в позиции +1
			//     Сдвинуть элементы влево на один.
			//  4: Записать temp на позицию в массиве + 1.


			// Шаг 1.
			int temp = matrix[indexInsertingAt % row,indexInsertingAt / row];

			// Шаг 2.

			matrix[indexInsertingAt % row, indexInsertingAt / row] 
				= matrix[indexInsertingFrom % row, indexInsertingFrom / row];

			// Шаг 3.
			for (int current = indexInsertingFrom; current > indexInsertingAt; current--)
			{
				matrix[current % row,current / row] = matrix[(current - 1) % row, (current - 1) / row];
			}

			// Шаг 4.
			matrix[(indexInsertingAt + 1) % row,(indexInsertingAt + 1) / row] = temp;
		}
	}
}
