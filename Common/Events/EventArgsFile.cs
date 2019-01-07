using System;

namespace Common.Events
{
	public class EventArgsFile : EventArgs
	{
		public string fileName;

		public EventArgsFile(string _fileName) {
			fileName = _fileName;
		}

		public EventArgsFile() { }
	}
}
