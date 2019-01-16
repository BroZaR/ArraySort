using BasicConsole.Enter;
using Common.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Inputs
{
	public class ManualInput : IInput
	{
		int[,] _matrix;
		//Ширина матриці
		int _j;
		//Висота матриці
		int _k;

		public ManualInput(int column, int row) {
			_j = column;
			_k = row;
		}

		public int[,] Leading()
		{
			_matrix = new int[_j, _k];
			for (int i = 0; i < _k; i++)
			{
				for (int n = 0; n < _j; n++)
				{
					_matrix[n, i] = Entering.EnterIntPrompt("Введіть " + (i + 1) + (n + 1) + " значення");
				}
			}

			return _matrix;
		}
	}
}
