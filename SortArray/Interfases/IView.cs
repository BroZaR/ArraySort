using Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Interfases
{
	public interface IView
	{
		event EventHandler<EventArgsManually> EventInputManually;
		event EventHandler<EventArgsFile> EventInputFille;
		event EventHandler<EventArgsRandom> EventInputRandom;
		event Action<int> EventSort;
		event Action<bool> Continuation;
	}
}
