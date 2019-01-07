using Common.Interfases;
using System.IO;
using System.Text.RegularExpressions;

namespace Common.Inputs
{
	public class FileInput : IInput
	{
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
				if (fileExists && Regex.IsMatch(File.ReadAllText(fileName), @"^((-?[0-9]+,)*(-?[0-9]+)+(\r\n)?)+$") && ValidRowColl(File.ReadAllText(fileName)))
					return true;
				else
					return false;
			}
		}

		public bool fileExists
		{
			get
			{
				if (fileName != null && File.Exists(fileName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}
		}

		public FileInput(string _fileName)
		{
			fileName = _fileName;
		}

		public int[,] Leading()
		{
			if (!fileExists || !fileValid)
			{
				return new int[0,0];
			}

			string text = File.ReadAllText(fileName);
			int row = 1, coll = 1;
			string number = "";
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ',' && coll == 1)
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
				} else if (text[i] == '\r' && text[i + 1] == '\n') {
					arr[_row, _coll] = int.Parse(number);
					_coll++;
					i++;
					_row = 0;
					number = "";
				}  else {
					number += text[i];
				}
			}
			arr[_row, _coll] = int.Parse(number);

			return arr;
		}

		private bool ValidRowColl(string text) {
			int row = 1, coll = 1, row1 = 0;
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ',')
				{
					row++;
				}
				if (text[i] == '\n')
				{
					if (coll == 1) {
						row1 = row;
					}
					coll++;
					row++;
				}
			}

			if ((row / coll) == row1)
			{
				return true;
			}
			else {
				return false;
			}
		}
	}
}
