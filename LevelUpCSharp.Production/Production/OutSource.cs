using LevelUpCSharp.Products;
using System.Collections.Generic;

namespace LevelUpCSharp.Production
{
	internal class OutSource : IProductionStrategy
	{
		private readonly object _converter;
        private readonly object _sandwichesFactory;

        public OutSource(object converter, ISandwichsFacory sandwichesFactory)
		{
			_converter = converter;
            _sandwichesFactory = sandwichesFactory;
		}


		public IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder)
		{
			var other = _converter.ToSubVendor(currentOrder);
			var given = _domainService.Ask(other);
			var ordered = _converter.FromSubVendor(given);
			return ordered;
		}
	}
}