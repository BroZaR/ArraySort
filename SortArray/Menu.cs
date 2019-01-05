using SortArray.Enter;
using SortArray.Interfases;
using SortArray.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SortArray.CommandInfo;

namespace SortArray
{
	public static class Menu
	{
		static IFileText file = Program.file;

		/*public static Dictionary<string, CommandInfo> CommandInfoArray = new Dictionary<string, CommandInfo> {
			{ "вийти", new CommandInfo("вийти", null) },
			{ "вручну", new CommandInfo("ввести дані вручну", ManualInput) },
			{ "файл", new CommandInfo("ввести дані через файл (*.csv.txt)", FilelInput) },
			{ "рандом", new CommandInfo("заповнити масив випадковими числами", RandomInput) }
		};*/

		static CommandInfo[] CommandInfoArray = {
			new CommandInfo("вийти", null),
			new CommandInfo("ввести дані вручну", ManualInput),
			new CommandInfo("ввести дані через файл (*.csv.txt)", FilelInput),
			new CommandInfo("заповнити масив випадковими числами", RandomInput),
		};

		public static void ManualInput()
		{
			int j = Entering.EnterIntNext("Введіть ширину матриці");
			int k = Entering.EnterIntNext("Введіть висоту матриці");
			MatrixView._matrix = new int[j,k];
			for (int i = 0; i < k; i++)
			{
				for (int n = 0; n < j; n++)
				{
					MatrixView._matrix[n,i] = Entering.EnterIntPrompt("Введіть " + (i + 1) + (n + 1) + " значення");
				}
			}
		}

		public static void FilelInput()
		{
			Program.array = file.Load(Entering.EnterStringPrompt("Введіть назву файлу"));
			if (!file.fileExists)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tТакого файлу не існує!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
			else if (!file.fileValid)
			{
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tДані файлу не відповідають формату csv!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}

		public static void RandomInput()
		{
			Random rand = new Random();
			int len = Entering.EnterIntNext("Введіть кількість значень масиву");
			Program.array = new int[len];
			int max = Entering.EnterIntPrompt("Введіть максимальне значення");
			for (int i = 0; i < len; i++)
			{
				Program.array[i] = rand.Next(max);
			}
		}

		public static void ShowCommandsMenu()
		{
			Console.WriteLine("\n  Перелік команд меню:\n");
			for (int i = 0; i < CommandInfoArray.Length; i++)
			{
				Console.WriteLine("\t{0,2} - {1}", i, CommandInfoArray[i].name);
			}
			Command command = EnterCommand();
			if (command == null)
			{
				return;
			}
			command();
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
	}
}
