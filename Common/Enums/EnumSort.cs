using System.ComponentModel;

namespace Common.Enums
{
	public enum Sorts {

		[Description("Сортування методом бульбашки")]
		BubbleSort = 1,

		[Description("Сортування вставками")]
		SortInserts = 2,

		[Description("Сортування вибором")]
		SortBySelection = 3,

		[Description("Швидке сортування")]
		QuickSort = 5,

		[Description("Сортування всіма методами")]
		AllSorts = 6
	}
}
