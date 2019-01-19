﻿using System;

namespace BasicConsole.Enter
{
	public static class Entering
	{
		public static int EnterIntPrompt(string prompt) {
			int var = 0;
			while (true)
			{
				Console.Write("  " + prompt + ": ");
				if (!int.TryParse(Console.ReadLine(), out var))
				{
					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\tПотрібно ввести ціле значення!");
					Console.ForegroundColor = ConsoleColor.Black;
				}
				else {
					break;
				}
			}
			return var;
		}

		public static int EnterIntNext(string prompt)
		{
			while (true) {
				int var = EnterIntPrompt(prompt);
				if (var > 0) {
					return var;
				}
				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tПотрібно ввести значення більше нуля!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}

		public static string EnterStringPrompt(string prompt)
		{
			Console.Write("  " + prompt + ": ");
			return (Console.ReadLine()).Trim();
		}

		public static bool EnterBoolUA(string prompt)
		{
			string s;
			while (true)
			{
				Console.Write(prompt + ": ");
				s = Console.ReadLine();
				if (s == "так")
				{
					return true;
				}
				if (s == "ні")
				{
					return false;
				}

				Console.ForegroundColor = ConsoleColor.Red;
				Console.WriteLine("\tПотрібно ввести значення \"так\" або \"ні\"!");
				Console.ForegroundColor = ConsoleColor.Black;
			}
		}
	}
}
