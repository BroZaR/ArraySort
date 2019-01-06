using Common.Interfases;
using System.IO;
using System.Text.RegularExpressions;

namespace Common.Inputs
{
	public class FileInput : IInput
	{
		private string wayToFile;

		private string filename;
		public string fileName
		{
			get
			{
				return filename;
			}
			set
			{
				if (value != null)
				{
					filename = value + ".csv.txt";
				}
			}
		}

		public bool fileValid
		{
			get
			{
				if (fileExists && Regex.IsMatch(File.ReadAllText(fileName), @"^(-?[0-9]+,)*(-?[0-9]+)+"))
					return true;
				else
					return false;
			}
		}

		public bool fileExists
		{
			get
			{
				if (wayToFile != "" && fileName != null && File.Exists(wayToFile + fileName))
				{
					return true;
				}
				else if (fileName != null && File.Exists(fileName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public FileInput(string _fileName, string _wayToFile = "")
		{
			fileName = _fileName;
			wayToFile = _wayToFile;
		}

		public int[,] Leading()
		{
			if (!fileExists || !fileValid)
			{
				return new int[0,0];
			}

			string text = File.ReadAllText(fileName);
			int row = 0, coll = 0;
			string number = "";
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ',' && coll == 0)
				{
					row++;
				}
				if (text[i] == '\n')
				{
					coll++;
				}
			}

			int[,] arr = new int[row,coll];
			int _row = 0, _coll = 0;
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ',') {
					arr[_row, _coll] = int.Parse(number);
					_row++;
					number = "";
				} else if (text[i] == '\n') {
					arr[_row, _coll] = int.Parse(number);
					_coll++;
					_row = 0;
					number = "";
				} else {
					number += text[i];
				}
			}
			return arr;
		}
	}
}
