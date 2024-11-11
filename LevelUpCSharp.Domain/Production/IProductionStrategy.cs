using LevelUpCSharp.Products;
using System.Collections.Generic;

namespace LevelUpCSharp.Production
{
	public interface IProductionStrategy
	{
		IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder);
	}
}