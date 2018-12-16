using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SortArray.CommandInfo;
using SortArray.Enter;
using System.IO;
using SortArray.Interfases;
using SortArray.Controller;

namespace SortArray
{
	class Program
	{
		public static int[] array;

		public static IFileText file = new FileTextController();

		static CommandInfo[] CommandInfoArray = {
			new CommandInfo("вийти", null),
			new CommandInfo("ввести дані вручну", Commands.ManualInput),
			new CommandInfo("ввести дані через файл (*.csv.txt)", Commands.FilelInput),
			new CommandInfo("заповнити масив випадковими числами", Commands.RandomInput),
		};

		static void Main(string[] args)
		{
			ConsoleConfig("SortArray");
			Run();

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

		static void Run()
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
		}

		static void ShowCommandsMenu()
		{
			Console.WriteLine("\n  Перелік команд меню:\n");
			for (int i = 0; i < CommandInfoArray.Length; i++)
			{
				Console.WriteLine("\t{0,2} - {1}", i, CommandInfoArray[i].name);
			}
		}

		static Command EnterCommand()
		{
			int number;
			while (true)
			{
				number = Entering.EnterIntPrompt("Введіть номер команди меню");
				if (number < CommandInfoArray.Length && number >= 0)
					return CommandInfoArray[number].command;
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tНемає команди з введеним номером!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}

		static void EchoArray(string roz) {
			for (int i = 0; i < array.Length; i++) {
				Console.Write(array[i]);
				if (i != array.Length - 1) {
					Console.Write(roz);
				}
			}
		}

		static bool Result() {
			if (array.Length != 0)
			{
				Console.Write("  Введені значення: ");
				EchoArray(", ");
				Array.Sort(array);
				Console.Write("\n\n  Введені значення: ");
				EchoArray(", ");
			}
			if (Entering.EnterBoolUA("\n\n  Бажаєте повторити[так/ні]"))
				return true;
			else
				return false;
		}
	}
}
