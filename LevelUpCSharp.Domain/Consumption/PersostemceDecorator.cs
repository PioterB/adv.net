namespace LevelUpCSharp.Consumption
{
	public class PersostemceDecorator : IConsumersService
	{
		private readonly IConsumersService inner;
		private readonly IRepository<string, Consumer> consumers;

		public PersostemceDecorator(IConsumersService inner, IRepository<string, Consumer> consumers)
        {
			this.inner = inner;
			this.consumers = consumers;
		}

        public Result<Consumer> Create(string name)
		{
			var insrtance = inner.Create(name);
			consumers.Add(name, insrtance);
			return insrtance;
		}
	}
}