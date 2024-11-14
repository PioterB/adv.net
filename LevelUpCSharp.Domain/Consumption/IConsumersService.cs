namespace LevelUpCSharp.Consumption
{
	public interface IConsumersService
	{
        Result<Consumer> Create(string name);
    }
}