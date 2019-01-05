using SortArray.Interfases;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SortArray.Controller
{
	public class FileTextController : IFileText
	{
		private string filename;
		public string fileName {
			get {
				return filename;
			} set {
				if (value != null) {
					filename = value + ".csv.txt";
				}
			} }

		public bool fileValid {
			get {
				if (fileExists && Regex.IsMatch(File.ReadAllText(fileName), @"^(-?[0-9]+,)*(-?[0-9]+)+"))
					return true;
				else
					return false;
			} }

		public bool fileExists {
			get {
				if (fileName != null && File.Exists(fileName))
				{
					return true;
				}
				else
				{
					return false;
				}
			}}

		public int[] Load(string name = null) {
			if (name != null) {
				fileName = name;
			}

			if (!fileExists || !fileValid) {
				return new int[0];
			}

			string text = File.ReadAllText(fileName);
			int k = 0, count = 0;
			string number = "";
			for (int i = 0; i < text.Length; i++)
			{
				if (text[i] == ',')
					count++;
			}

			int[] arr = new int[count + 1];
			for (int i = 0; i < text.Length; i++) {
				if (text[i] != ',')
				{
					number += text[i];
				}
				else
				{
					arr[k] = int.Parse(number);
					k++;
					number = "";
				}
			}
			return arr;
		}

		public FileTextController(string name) {
			fileName = name;
		}

		public FileTextController() { }
	}
}
