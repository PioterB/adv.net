using LevelUpCSharp.Products;
using System.Collections.Generic;

namespace LevelUpCSharp.Production
{
    public interface IProductionStrategy
	{
		IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder);
	}

	internal class MadeByMe : IProductionStrategy
	{
		public IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder)
		{
			var ordered = new List<Sandwich>((int)currentOrder.Count);
			for (int i = 0; i < currentOrder.Count; i++)
			{
				var sandwitch = SandwichBuilder.WithButter(true)
					.Use(currentOrder.Kind.ToKeyIngredient())
					.AddVeg(new Onion())
					.AddTopping(new GarlicSos())
					.Wrap();
				ordered.Add(sandwitch);
			}

			return ordered;
		}
	}

	internal class OutSource : IProductionStrategy
	{
		public IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder)
		{
			var ordered = new List<Sandwich>((int)currentOrder.Count);

			return ordered;
		}
	}
}