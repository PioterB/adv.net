using LevelUpCSharp.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp.Production
{
	internal static class SandwitchKindExtensions
	{
		internal static IKeyIngredient ToKeyIngredient(this SandwichKind kind)
		{
			return kind switch
			{
				SandwichKind.Beef => new Beef(),
				SandwichKind.Cheese => new Gouda(),
				SandwichKind.Chicken => new Chicken(),
				SandwichKind.Pork => new Pork(),
				_ => throw new NotSupportedException("ensure full translation"),
			};
		}
	}
}
