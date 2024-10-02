using LevelUpCSharp.Products;
using System;

namespace LevelUpCSharp.Production
{
	internal class Chicken : IKeyIngredient
	{
		public Chicken()
		{
		}

		public SandwichKind Kind => SandwichKind.Chicken;

		public DateTime ExpDate => DateTime.Now.AddDays(7);
	}
}