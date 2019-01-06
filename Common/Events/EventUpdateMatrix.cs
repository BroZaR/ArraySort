using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Events
{
	public class EventUpdateMatrix : EventArgs
	{
		public int[,] matrix;

		public EventUpdateMatrix(int[,] _matrix) {
			matrix = _matrix;
		}

		public EventUpdateMatrix() { }
	}
}
