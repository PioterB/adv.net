using LevelUpCSharp.Helpers;
using LevelUpCSharp.Products;

namespace LevelUpCSharp
{
    public static class Dictionaries
    {
        static Dictionaries()
        {
            SandwichKinds = EnumHelper.GetValues<SandwichKind>();
        }

        public static SandwichKind[] SandwichKinds { get; }
    }
}
