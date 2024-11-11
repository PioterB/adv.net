using System.Reflection;

namespace LevelUpCSharp.Server
{
	internal class SandwichesMaker
	{
		public SandwichesMaker(TypeInfo group, string method)
		{
			Group = group;
			Method = method;
		}

		public TypeInfo Group { get; }

		public string Method { get; }
	}
}