using LevelUpCSharp.Products;

namespace LevelUpCSharp.Retail
{
    public class LineSummary
    {
        public LineSummary(SandwichKind kind, int added)
        {
            Kind = kind;
            Added = added;
        }

        public SandwichKind Kind { get; }
        public int Added { get; }
    }
}