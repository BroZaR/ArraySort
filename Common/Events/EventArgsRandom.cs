using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Events
{
	public class EventArgsRandom : EventArgs
	{
		public int row;
		public int coll;
		public int max;

		public EventArgsRandom(int _row, int _coll, int _max = 10) {
			row = _row;
			coll = _coll;
			max = _max;
		}

		public EventArgsRandom() { }
	}
}
