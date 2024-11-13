namespace LevelUpCSharp.Consumption
{
    public class ConsumersService
    {
		private readonly IRepository<string, Consumer> _consumers;

		public ConsumersService(IRepository<string, Consumer> consumers)
        {
            /* 
             * sanity check guarding architecture is missing 
             * - consumetrs is not null
             */

			_consumers = consumers;
		}

        public Result<Consumer> Create(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return Result<Consumer>.Failed();
            }

            var consumer = new Consumer(name);

            _consumers.Add(consumer.Name, consumer);
            
            return Result<Consumer>.Success(consumer);
        }
    }
}
