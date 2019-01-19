using System.ComponentModel;

namespace Common.Enums
{
	public enum Sorts {

		[Description("Сортування методом бульбашки")]
		BubbleSort = 0,

		[Description("Сортування вставками")]
		SortInserts,

		[Description("Сортування вибором")]
		SortBySelection,

		[Description("Швидке сортування")]
		QuickSort,

		[Description("Сортування всіма методами")]
		AllSorts
	}
}
