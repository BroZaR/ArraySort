using SortArray.Enter;
using SortArray.Interfases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray
{
	public static class Commands
	{
		static IFileText file = Program.file;

		public static void ManualInput()
		{
			int len = Entering.EnterIntNext("Введіть кількість значень масиву");
			Program.array = new int[len];
			for (int i = 0; i < len; i++)
			{
				Program.array[i] = Entering.EnterIntPrompt("Введіть " + (i + 1) + " значення");
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
			else if (!file.fileValid) {
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
	}
}
