using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
