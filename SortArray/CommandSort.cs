using Common.Enums;

namespace SortArray
{
	public delegate void CommandS(Sorts type);

	public class CommandSort
	{
		public string name;
		public Sorts sort;

		public CommandSort(string name, Sorts sort)
		{
			this.name = name;
			this.sort = sort;
		}
	};
}
