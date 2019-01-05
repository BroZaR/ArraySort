using SortArray.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Views
{
	public class MatrixView : IView
	{
		public static int[,] _matrix;
		public int[,] Matrix {
			get {
				return _matrix;
			} set {
				_matrix = value;
			}
		}

		public event Action<string> EnterLine;
		public event Action EnterCommandMenuSort;
		public event Action EnterCommandMenuCreateMatrix;

		public void UpdateMatrix()
		{
			int row = _matrix.GetUpperBound(0) + 1;
			int col = _matrix.Length / row;

			for (int i = 0; i < col; i++) {
				for (int n = 0; n < row; n++)
				{
					Console.Write("   " + _matrix[n,i]);
				}
				Console.WriteLine();
			}

			Console.WriteLine();
		}

		public void UpdateMenu(int level)
		{
			Console.WriteLine("UpdateMenu");
		}

		public void Show() {
			Menu.ShowCommandsMenu();
			UpdateMatrix();

			EnterLine(Console.ReadLine());
		}

		public void Enter() {
			EnterLine(Console.ReadLine());
		}
	}
}
