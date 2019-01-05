using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortArray.Interfases
{
	public interface IView
	{
		int[,] Matrix { get; set; }

		void Show();

		event Action<string> EnterLine;
	}
}
