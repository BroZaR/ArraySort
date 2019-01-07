using System;
using System.Text;
using Common.Interfases;
using SortArray.Models;
using SortArray.Presenters;
using SortArray.Views;

namespace SortArray
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleConfig("SortArray");
			IModel model = new Model();
			IView view = new MatrixView();

			MatrixPresenter presenter = new MatrixPresenter(model, view);
			presenter.Start();

			Console.ReadKey(true);
		}

		static void ConsoleConfig(string title)
		{
			Console.Title = title;
			Console.BackgroundColor = ConsoleColor.Gray;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.Black;
			Console.InputEncoding = Encoding.Unicode;
			Console.OutputEncoding = Encoding.Unicode;
		}

		/*static void Run()
		{
			while (true)
			{
				ShowCommandsMenu();
				Command command = EnterCommand();
				if (command == null)
				{
					return;
				}
				command();
				if (!Result())
					return;
				else
					Console.Clear();
			}
		}*/
	}
}
