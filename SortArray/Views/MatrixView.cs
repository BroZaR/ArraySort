using Common.Enums;
using Common.Events;
using SortArray.Enter;
using Common.Interfases;
using System;

namespace SortArray.Views
{
	public class MatrixView : IView
	{
		private CommandInfo[] MenuLevel_1;

		public event EventHandler<EventArgsManually> EventInputManually;
		public event EventHandler<EventArgsFile> EventInputFille;
		public event EventHandler<EventArgsRandom> EventInputRandom;
		public event Action<Sorts> EventSort;
		public event Action<bool> Continuation;

		public MatrixView()
		{
			MenuLevel_1 = new CommandInfo[] {
				new CommandInfo("вийти", null),
				new CommandInfo("ввести дані вручну", ManualInput),
				new CommandInfo("ввести дані через файл (*.csv.txt)", FilelInput),
				new CommandInfo("заповнити масив випадковими числами", RandomInput),
			};
		}

		public void ShowMatrix(int[,] matrix, int time, Sorts type)
		{
			throw new NotImplementedException();
		}

		public void ShowMainMenu()
		{
			Console.WriteLine("\n  Перелік команд меню:\n");
			for (int i = 0; i < MenuLevel_1.Length; i++)
			{
				Console.WriteLine("\t{0,2} - {1}", i, MenuLevel_1[i].name);
			}
			Command command = EnterCommand();
			if (command == null)
			{
				return;
			}
			command();
		}

		public void ShowSortMenu()
		{
			throw new NotImplementedException();
		}

		void ManualInput()
		{
			int[,] _matrix;
			int j = Entering.EnterIntNext("Введіть ширину матриці");
			int k = Entering.EnterIntNext("Введіть висоту матриці");
			_matrix = new int[j, k];
			for (int i = 0; i < k; i++)
			{
				for (int n = 0; n < j; n++)
				{
					_matrix[n, i] = Entering.EnterIntPrompt("Введіть " + (i + 1) + (n + 1) + " значення");
				}
			}

			EventInputManually(this, new EventArgsManually(_matrix));
		}

		void FilelInput()
		{
			string fileName = Entering.EnterStringPrompt("Введіть назву файлу");
			string way = Entering.EnterStringPrompt("Введіть шлях до файлу(якщо він не знаходиться в папці за замовчуванням)");

			EventInputFille(this, new EventArgsFile(fileName, way));
		}

		void RandomInput()
		{
			int row = Entering.EnterIntNext("Введіть ширину матриці");
			int coll = Entering.EnterIntNext("Введіть висоту матриці");
			int max = Entering.EnterIntPrompt("Введіть максимальне значення");

			EventInputRandom(this, new EventArgsRandom(row, coll, max));
		}

		private Command EnterCommand()
		{
			int number;
			while (true)
			{
				number = Entering.EnterIntPrompt("Введіть номер команди меню");
				if (number < MenuLevel_1.Length && number >= 0)
					return MenuLevel_1[number].command;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tНемає команди з введеним номером!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}
	}
}
