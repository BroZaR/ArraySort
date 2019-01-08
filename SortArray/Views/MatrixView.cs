﻿using Common.Enums;
using Common.Events;
using SortArray.Enter;
using Common.Interfases;
using System;

namespace SortArray.Views
{
	public class MatrixView : IView
	{
		private CommandInfo[] MenuLevel_1;
		private CommandSort[] MenuLevel_2 = new CommandSort[] {
			new CommandSort("сортувати методом бульбашки", (Sorts)1),
			new CommandSort("сортування вставками", (Sorts)2),
			new CommandSort("сортування вибором", (Sorts)3),
			new CommandSort("швидке сортування", (Sorts)5),
			new CommandSort("сортувати всіма видами", (Sorts)6)
		};

		public event EventHandler<EventArgsManually> EventInputManually;
		public event EventHandler<EventArgsFile> EventInputFille;
		public event EventHandler<EventArgsRandom> EventInputRandom;
		public event Action<Sorts> EventSort;

		public MatrixView()
		{
			MenuLevel_1 = new CommandInfo[] {
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
			string nameTipe;
			switch (type) {
				case (Sorts)1:
					nameTipe = "Сортування методом бульбашки";
					break;
				case (Sorts)2:
					nameTipe = "Сортування вставками";
					break;
				case (Sorts)3:
					nameTipe = "Сортування вибором";
					break;
				case (Sorts)5:
					nameTipe = "Швидке сортування";
					break;
				default:
					nameTipe = "Невідомий метод сортування";
					break;
			}
			Console.WriteLine("  Тип сортування: " + nameTipe);
			Console.WriteLine("  Час виконання сортування: " + time);

			if (Entering.EnterBoolUA("Хочите продовжити[так/ні]?"))
			{
				Show();
			}
			else {
				return;
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
			for (int i = 0; i < MenuLevel_1.Length; i++)
			{
				Console.WriteLine("\t{0,2} - {1}", i, MenuLevel_1[i].name);
			}
		}

		private void ShowSortMenu()
		{
			Console.WriteLine("\n  Перелік команд сортування:\n");
			for (int i = 0; i < MenuLevel_2.Length; i++)
			{
				Console.WriteLine("\t{0,2} - {1}", i, MenuLevel_2[i].name);
			}
		}

		private void ManualInput()
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
			EventSort(type);
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

		private Sorts EnterSorts()
		{
			int number;
			while (true)
			{
				number = Entering.EnterIntPrompt("Введіть номер команди меню");
				if (number < MenuLevel_2.Length && number >= 0)
					return MenuLevel_2[number].sort;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tНемає команди з введеним номером!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}
	}
}
