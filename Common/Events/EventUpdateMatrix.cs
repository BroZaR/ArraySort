using Common.Enums;
using System;

namespace Common.Events
{
	public class EventUpdateMatrix : EventArgs
	{
		public int[,] matrix;
		public TimeSpan time;
		public Sorts type;

		public EventUpdateMatrix(int[,] _matrix, TimeSpan _time, Sorts _type) {
			matrix = _matrix;
			time = _time;
			type = _type;
		}

		public EventUpdateMatrix(int[,] _matrix)
		{
			matrix = _matrix;
		}

		public EventUpdateMatrix() { }
	}
}
