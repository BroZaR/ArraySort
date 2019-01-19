using Common.Interfases;
using Common.SortController;

namespace Common.Creator
{
	public class BubbleSortMenager : SortManager
	{
		public override ISort CreateClassSort()
		{
			return new BubbleSort();
		}
	}
}
