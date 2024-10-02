using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
	internal interface IKeyIngredient : IIngredient
	{
		SandwichKind Kind { get; }
	}
}
