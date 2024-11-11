namespace LevelUpCSharp.Production
{
	public interface ISossing : ISandwichDispatching
	{
		ISandwichDispatching AddTopping(ITopping topping);
	}
}
