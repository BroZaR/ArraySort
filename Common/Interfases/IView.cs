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

		void ShowMainMenu();
		void ShowSortMenu();
		void ShowMatrix(int[,] matrix, int time, Sorts type);
	}
}
