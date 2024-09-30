namespace LevelUpCSharp.Consumption
{
    public class ConsumersService
    {
        public Result<Consumer> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Consumer>.Failed();
            }

            var consumer = new Consumer(name);

            Repositories.Consumers.Add(consumer.Name, consumer);
            
            return Result<Consumer>.Success(consumer);
        }
    }
}
