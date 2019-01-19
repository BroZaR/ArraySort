﻿using Common.Enums;
using Common.Events;
using BasicConsole.Enter;
using Common.Interfases;
using System;
using Common.Extensions;

namespace SortArray.Views
{
	public class MatrixView : IView
	{
		private int _count = 1;

		private CommandInfo[] MenuInput;

		public event EventHandler<EventArgsManually> EventInputManually;
		public event EventHandler<EventArgsFile> EventInputFille;
		public event EventHandler<EventArgsRandom> EventInputRandom;
		public event Action<Sorts> EventSort;

		public MatrixView()
		{
			MenuInput = new CommandInfo[] {
				new CommandInfo("вийти", null),
				new CommandInfo("ввести дані вручну", ManualInput),
				new CommandInfo("ввести дані через файл (*.csv.txt)", FilelInput),
				new CommandInfo("заповнити масив випадковими числами", RandomInput),
			};
		}

		public void Show() {
			ShowMainMenu();
			Command command = EnterCommand();
			if (command == null) {
				return;
			}
			Console.WriteLine();
			command();
		}

		public void InputMatrix(int[,] matrix)
		{
			ShowMatrix(matrix);
			ShowSortMenu();
			Sorts sort = EnterSorts();
			Console.WriteLine();
			Sort(sort);
		}

		public void SortMatrix(int[,] matrix, TimeSpan time, Sorts type)
		{
			ShowMatrix(matrix);
			Console.WriteLine("  Тип сортування: " + type.GetDescription());
			Console.WriteLine("  Час виконання сортування: " + time + "\n");
			_count--;

			if (_count == 0) {
				_count = 1;
				Show();
			}
		}

		public void ShowError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("\t" + message);
			Console.ForegroundColor = ConsoleColor.Black;
		}

		private void ShowMatrix(int[,] mat)
		{
			int row = mat.GetUpperBound(0) + 1;
			int coll = mat.Length / row;

			Console.Write("\n  Матриця: \n\t");
			for (int c = 0; c < coll; c++) {
				for (int r = 0; r < row; r++) {
					Console.Write("  " + mat[r,c]);
				}
				Console.Write("\n\t");
			}

			Console.WriteLine();
		}

		private void ShowMainMenu()
		{
			Console.WriteLine("\n  Перелік команд меню:\n");
			for (int i = 0; i < MenuInput.Length; i++)
			{
				Console.WriteLine("\t{0,2} - {1}", i, MenuInput[i].name);
			}
		}

		private void ShowSortMenu()
		{
			Console.WriteLine("\n  Перелік команд сортування:\n");
			foreach (Sorts el in Enum.GetValues(typeof(Sorts)))
			{
				Console.WriteLine("\t{0} - {1}", (int)el, el.GetDescription());
			}
		}

		private void ManualInput()
		{
			int j = Entering.EnterIntNext("Введіть ширину матриці");
			int k = Entering.EnterIntNext("Введіть висоту матриці");

			EventInputManually(this, new EventArgsManually(j, k));
		}

		private void FilelInput()
		{
			string fileName = Entering.EnterStringPrompt("Введіть назву файлу");

			EventInputFille(this, new EventArgsFile(fileName));
		}

		private void RandomInput()
		{
			int row = Entering.EnterIntNext("Введіть ширину матриці");
			int coll = Entering.EnterIntNext("Введіть висоту матриці");
			int max = Entering.EnterIntPrompt("Введіть максимальне значення");

			EventInputRandom(this, new EventArgsRandom(row, coll, max));
		}

		private void Sort(Sorts type) {
			if (Sorts.AllSorts == type) {
				_count = Enum.GetNames(typeof(Sorts)).Length - 1;
			}
			EventSort(type);
		}

		private Command EnterCommand()
		{
			int number;
			while (true)
			{
				number = Entering.EnterIntPrompt("Введіть номер команди меню");
				if (number < MenuInput.Length && number >= 0)
					return MenuInput[number].command;
				ShowError("Немає команди з введеним номером!");
			}
		}

		private Sorts EnterSorts()
		{
			int number;
			while (true)
			{
				number = Entering.EnterIntPrompt("Введіть номер команди меню");
				foreach (Sorts el in Enum.GetValues(typeof(Sorts)))
				{
					if ((int)el == number)
					{
						return el;
					}
				}
				ShowError("Немає команди з введеним номером!");
			}
		}
	}
}
