using System.Collections.Generic;
using LevelUpCSharp.Consumption;
using LevelUpCSharp.Persistence;
using LevelUpCSharp.Production;

namespace LevelUpCSharp
{
    public static class Repositories
    {
        static Repositories()
        {
            Consumers = InitializeCustomers();
            Vendors = InitializeFactories();
        }

        public static Repository<string, Vendor> Vendors { get; }

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

        private static Repository<string, Vendor> InitializeFactories()
        {
            var repo = new Repository<string, Vendor>();

            repo.Add("Slimak", new Vendor("Slimak"));
            repo.Add("Pan Kanapka", new Vendor("Pan Kanapka"));
            repo.Add("Nowakowski", new Vendor("Nowakowski"));

            return repo;
        }
    }
}
