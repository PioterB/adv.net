using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using LevelUpCSharp.Collections;
using LevelUpCSharp.Helpers;
using LevelUpCSharp.Products;
using LevelUpCSharp.Tax;

namespace LevelUpCSharp.Retail
{
    public class Retailer
    {
        private static Retailer _instance;
        private readonly IDictionary<SandwichKind, List<Sandwich>> _lines;

        protected Retailer(string name)
        {
            Name = name;
            _lines = InitializeLines();
        }

        public static Retailer Instance => _instance ?? (_instance = new Retailer("Build-in"));

        public event Action<PackingSummary> Packed;
        public event Action<DateTimeOffset, Sandwich> Purchase;

        public string Name { get; }

        public Result<Sandwich> Sell(SandwichKind kind)
        {
            if (_lines.ContainsKey(kind) == false || _lines[kind].Count == 0)
            {
                return Result<Sandwich>.Failed();
            }

             var sandwich = _lines[kind][0];
            _lines[kind].RemoveAt(0);
            OnPurchase(DateTimeOffset.Now, sandwich);

            //return Result<Sandwich>.Success(sandwich);
            return sandwich.AsSuccess();
        }

        public void Pack(IEnumerable<Sandwich> package, string deliver)
        {
            PopulateRack(package);
            var summary = ComputeReport(package, deliver);
            OnPacked(summary);
        }

        private void PopulateRack(IEnumerable<Sandwich> package)
        {
            package.ForEach(sandwitch => _lines[sandwitch.Kind].Add(sandwitch));
        }

        private static PackingSummary ComputeReport(IEnumerable<Sandwich> package, string deliver)
        {
            var summaryPositions = package
                .GroupBy(
                    p => p.Kind,
                    (kind, sandwiches) => new LineSummary(kind, sandwiches.Count()))
                .ToArray();
            var summary = new PackingSummary(summaryPositions, deliver);
            return summary;
        }

        protected virtual void OnPacked(PackingSummary summary)
        {
            Packed?.Invoke(summary);
        }

        protected virtual void OnPurchase(DateTimeOffset time, Sandwich product)
        {
            Purchase?.Invoke(time, product);
        }

        private IDictionary<SandwichKind, List<Sandwich>> InitializeLines()
        {
            var result = new Dictionary<SandwichKind, List<Sandwich>>();

            foreach (var sandwichKind in EnumHelper.GetValues<SandwichKind>())
            {
                result.Add(sandwichKind, new List<Sandwich>());
            }

            return result;
        }
    }
}
