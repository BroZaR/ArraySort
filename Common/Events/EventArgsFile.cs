using System;

namespace Common.Events
{
	public class EventArgsFile : EventArgs
	{
		public string fileName;
		public string wayToFile;

		public EventArgsFile(string _fileName, string _wayToFile)
		{
			fileName = _fileName;
			wayToFile = _wayToFile;
		}

		public EventArgsFile(string _fileName) {
			fileName = _fileName;
		}

		public EventArgsFile() { }
	}
}
