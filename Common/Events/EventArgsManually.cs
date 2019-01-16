using System;

namespace Common.Events
{
	public class EventArgsManually : EventArgs
	{
		public int _coll;
		public int _row;

		public EventArgsManually(int coll, int row) {
			_coll = coll;
			_row = row;
		}

		public EventArgsManually() { }
	}
}
