namespace LevelUpCSharp.Server
{
	internal class AskedAction
	{
		public AskedAction(string group, string worker)
		{
			Group = group;
			Worker = worker;
		}

		public string Group { get; }

		public string Worker { get; }
	}
}