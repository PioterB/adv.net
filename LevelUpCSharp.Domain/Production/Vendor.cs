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
        private readonly List<Sandwich> _warehouse = new List<Sandwich>();

        public Vendor(string name)
        {
            Name = name;
        }

        public event Action<Sandwich[]> Produced;

        public string Name { get; }

        public IEnumerable<Sandwich> Buy(int howMuch = 0)
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

            var toSell = new List<Sandwich>();
            for (int i = 0; i < howMuch; i++)
            {
                var first = _warehouse[0];
                toSell.Add(first);
                _warehouse.Remove(first);
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
            _warehouse.AddRange(sandwiches);
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

            foreach (var sandwich in _warehouse)
            {
                counts[sandwich.Kind] += 1;
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
    }
}
