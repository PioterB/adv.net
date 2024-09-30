using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
    internal class StockItemViewModel
    {
        public StockItemViewModel(StockItem item)
        {
            Type = item.Type;
            Count = item.Count;
        }

        public int Count { get; set; }

        public SandwichKind Type { get; }
    }
}