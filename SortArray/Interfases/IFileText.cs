namespace SortArray.Interfases
{
	public interface IFileText
	{
		string fileName { get; set; }
		bool fileValid { get; }
		bool fileExists { get; }
		int[] Load(string name);
	}
}
