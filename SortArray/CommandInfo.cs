namespace SortArray
{
	public class CommandInfo
	{
		public delegate void Command();

		public string name;
		public Command command;

		public CommandInfo(string name, Command command)
		{
			this.name = name;
			this.command = command;
		}
	}
}
