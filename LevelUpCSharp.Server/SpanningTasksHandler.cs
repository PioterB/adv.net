using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Networking;
using LevelUpCSharp.Production;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Server
{
	[Ctrl("x")]
    internal class SpanningTasksHandler
    {
        private readonly IEnumerable<Vendor> _vendors;

        public SpanningTasksHandler(IEnumerable<Vendor> vendors)
        {
            _vendors = vendors;
        }

        [Worker("s")]
        public IEnumerable<Sandwich> Sandwiches()
        {
            return _vendors.AsParallel().SelectMany(v => v.Buy(1)).ToArray();
        }
    }
}
