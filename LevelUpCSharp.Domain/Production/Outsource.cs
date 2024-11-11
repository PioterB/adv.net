using LevelUpCSharp.Products;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LevelUpCSharp.Production
{
	internal class Outsource : IProductionStrategy
	{
		public IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder)
		{
			var ordered = Enumerable.Repeat(currentOrder.Kind, (int)currentOrder.Count)
				.AsParallel()
				.WithExecutionMode(ParallelExecutionMode.ForceParallelism)
				.Select(kind => SandwichBuilder.WithButter(true)
					.Use(kind.ToKeyIngredient())
					.AddVeg(new Onion())
					.AddTopping(new GarlicSos())
					.Wrap())
				.ToArray();
			return ordered;
		}
	}
}