using Common.Interfases;
using Common.SortController;

namespace Common.Creator
{
	public class BubbleSortManager : SortManager
	{
		public override ISort CreateClassSort()
		{
			return new BubbleSort();
		}
	}
}
