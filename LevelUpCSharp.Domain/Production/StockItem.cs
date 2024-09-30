using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
    public readonly struct StockItem
    {
        public StockItem(SandwichKind type, int count)
        {
            Type = type;
            Count = count;
        }

        public SandwichKind Type { get; }

        public int Count { get; }
    }
}