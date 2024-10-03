using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
    public class Vendor
    {
        private Thread _worker;

		private readonly List<Sandwich> _warehouse; 

        public Vendor(string name)
        {
            Name = name;
            _worker = new Thread(Worker) { IsBackground = true };
            _warehouse = new List<Sandwich>();
            _worker.Start();
        }

        public event Action<Sandwich[]> Produced;

        public string Name { get; }

        public IEnumerable<Sandwich> Buy(int howMuch = 0)
        {
            var toSell = new List<Sandwich>();
            lock (_warehouse)
			{
				if (_warehouse.Count == 0)
				{
					return Array.Empty<Sandwich>();
				}

				if (howMuch == 0 || _warehouse.Count <= howMuch)
				{
					var result = _warehouse.ToArray();
					_warehouse.Clear();
					return result;
				}

				for (int i = 0; i < howMuch; i++)
				{
					var first = _warehouse[0];
					toSell.Add(first);
					_warehouse.Remove(first);
				} 
			}

            return toSell;
        }

        public void Order(SandwichKind kind, int count)
        {
            var sandwiches = new List<Sandwich>();
            for (int i = 0; i < count; i++)
            {
                sandwiches.Add(Produce(kind));
            }

			lock (_warehouse)
			{
				_warehouse.AddRange(sandwiches);
			}            
            
            Produced?.Invoke(sandwiches.ToArray());
        }

        public IEnumerable<StockItem> GetStock()
        {
            Dictionary<SandwichKind, int> counts = new Dictionary<SandwichKind, int>()
            {
                {SandwichKind.Cheese, 0},
                {SandwichKind.Chicken, 0},
                {SandwichKind.Beef, 0},
                {SandwichKind.Pork, 0},
            };

			lock (_warehouse)
			{
				foreach (var sandwich in _warehouse)
				{
					counts[sandwich.Kind] += 1;
				} 
			}

            var result = new StockItem[counts.Count];

            int i = 0;
            foreach (var count in counts)
            {
                result[i] = new StockItem(count.Key, count.Value);
                i++;
            }

            return result;
        }

        private Sandwich Produce(SandwichKind kind)
        {
            return kind switch
            {
                SandwichKind.Beef => ProduceSandwich(kind, DateTimeOffset.Now.AddMinutes(3)),
                SandwichKind.Cheese => ProduceSandwich(kind, DateTimeOffset.Now.AddSeconds(90)),
                SandwichKind.Chicken => ProduceSandwich(kind, DateTimeOffset.Now.AddMinutes(4)),
                SandwichKind.Pork => ProduceSandwich(kind, DateTimeOffset.Now.AddSeconds(150)),
                _ => throw new ArgumentOutOfRangeException(nameof(kind), kind, null)
            };
        }

        private Sandwich ProduceSandwich(SandwichKind kind, DateTimeOffset addMinutes)
        {
            var main = kind.ToKeyIngredient();
            return SandwichBuilder.WithButter(true)
                .Use(main)
                .AddVeg(new Onion())
                .AddTopping(new GarlicSos())
                .Wrap();
        }

        private void Worker(object obj)
        {
            Random r = new Random((int)DateTime.Now.Ticks);

            while(true)
			{
                var kind = (SandwichKind)r.Next(1, 4);

                var sandwitch = Produce(kind);
				lock (_warehouse)
				{
					_warehouse.Add(sandwitch);
				}

                Produced?.Invoke(new[] { sandwitch });

                var delay = r.Next(500, 3000);
                Thread.Sleep(TimeSpan.FromMilliseconds(delay));
			}
        }
    }
}
