using Common.Interfases;
using Common.SortController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Creator
{
	public class InsertsSortManager : SortManager
	{
		public override ISort CreateClassSort()
		{
			return new SortInserts();
		}
	}
}
