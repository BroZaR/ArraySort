using Common.Enums;
using Common.Events;
using System;

namespace Common.Interfases
{
	public interface IView
	{
		event EventHandler<EventArgsManually> EventInputManually;
		event EventHandler<EventArgsFile> EventInputFille;
		event EventHandler<EventArgsRandom> EventInputRandom;
		event Action<Sorts> EventSort;
		event Action<bool> Continuation;

		void Show();
		void InputMatrix(int[,] matrix);
		void SortMatrix(int[,] mattrix, TimeSpan time, Sorts type);
		void ShowError(string message);
	}
}
