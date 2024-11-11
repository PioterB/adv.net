using LevelUpCSharp.Products;
using System;

namespace LevelUpCSharp.Production
{
	internal class Gouda : IKeyIngredient, IGarnish
	{
		public Gouda()
		{
		}

		public SandwichKind Kind => SandwichKind.Cheese;

		public DateTime ExpDate => DateTime.Now.AddDays(7);

		public string Name => "Gouda";
	}
}