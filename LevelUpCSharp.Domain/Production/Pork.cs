using LevelUpCSharp.Products;
using System;

namespace LevelUpCSharp.Production
{
	internal class Pork: IKeyIngredient
	{
		public Pork()
		{
		}

		public SandwichKind Kind => SandwichKind.Pork;

		public DateTime ExpDate => DateTime.Now.AddDays(7);
	}
}