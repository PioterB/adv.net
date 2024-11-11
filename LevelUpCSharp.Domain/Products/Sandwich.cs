using System;

namespace LevelUpCSharp.Products
{
    public class Sandwich
    {
        public Sandwich()
        {
        }

        public SandwichKind Kind { get; set; }
    

        public DateTimeOffset ExpirationDate { get; set; }
    }
}
