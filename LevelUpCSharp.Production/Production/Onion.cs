using System;

namespace LevelUpCSharp.Production
{
	internal class Onion : IGarnish
	{
		public string Name => "Onion";

		public DateTime ExpDate => DateTime.Now.AddDays(5);
	}
}