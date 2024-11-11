using LevelUpCSharp.Consumption;
using LevelUpCSharp.Persistence;

namespace LevelUpCSharp
{
    public static class Repositories
    {
        static Repositories()
        {
            Consumers = InitializeCustomers();
        }

        public static Repository<string, Consumer> Consumers { get; }

        private static Repository<string, Consumer> InitializeCustomers()
        {
            var repo = new Repository<string, Consumer>();

            repo.Add("Adam", new Consumer("Adam"));
            repo.Add("Piotrek", new Consumer("Piotrek"));
            repo.Add("Zbyszek", new Consumer("Zbyszek"));
            repo.Add("Waldek", new Consumer("Waldek"));

            return repo;
        }
    }
}
