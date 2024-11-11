using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LevelUpCSharp.Networking;
using LevelUpCSharp.Production;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Server
{
    [Ctrl("p")]
    internal class ProductionHandler
    {
        private readonly IEnumerable<Vendor> _vendors;

        public ProductionHandler(IEnumerable<Vendor> vendors)
        {
            _vendors = vendors;
        }

        [Worker("s")]
        public IEnumerable<Sandwich> Sandwiches()
        {
            return _vendors.SelectMany(v => v.Buy(5)).ToArray();
        }
    }
}
