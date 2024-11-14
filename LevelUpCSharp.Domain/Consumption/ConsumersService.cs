namespace LevelUpCSharp.Consumption
{
    public class ConsumersService : IConsumersService
    {
        public Result<Consumer> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Consumer>.Failed();
            }

            var consumer = new Consumer(name);
            
            return Result<Consumer>.Success(consumer);
        }
    }
}
