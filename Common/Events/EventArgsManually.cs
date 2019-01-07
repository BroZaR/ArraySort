using System;

namespace Common.Events
{
	public class EventArgsManually : EventArgs
	{
		public int[,] data;

		public EventArgsManually(int[,] _matrix) {
			data = _matrix;
		}

		public EventArgsManually() { }
	}
}
