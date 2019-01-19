﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Interfases;
using Common.SortController;

namespace Common.Creator
{
	public class QuickSortManager : SortManager
	{
		public override ISort CreateClassSort()
		{
			return new QuickSort();
		}
	}
}
