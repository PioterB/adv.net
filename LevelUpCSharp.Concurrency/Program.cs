using System;
using System.Threading;

namespace LevelUpCSharp.Concurrency
{
    class Program
    {
        private static Random r = new Random();

        static void Main(string[] args)
        {
            var a = new Thread(WorkA);
            var b = new Thread(WorkB);
            var vault = new Vault<int>();

            a.Start(vault);
            b.Start(vault);

            Console.ReadKey(true);
            Console.WriteLine("Closing...");
        }

        private static void WorkB(object? obj)
        {
            var vault = (IVault<int>)obj;

            while (true)
            {
                var found = r.Next(100);

                Console.WriteLine("[B] i have: " + found);

                vault.Put(found);
                Console.WriteLine("[B] stored: " + found);

                Console.WriteLine("[B] break");
                Thread.Sleep(3 * 1000);
                Console.WriteLine("[B] after break");

                var get = vault.Get();
                Console.WriteLine("[B] get:" + get);
                Thread.Sleep(3 * 1000);
            }
        }

        private static void WorkA(object? obj)
        {
            var vault = (IVault<int>)obj;

            while (true)
            {
                var found = r.Next(100);

                Console.WriteLine("[A] i have: " + found);
                vault.Put(found);
                Console.WriteLine("[A] stored: " + found);

                Console.WriteLine("[A] break");
                Thread.Sleep(7 * 1000);
                Console.WriteLine("[A] after break");

                var get = vault.Get();
                Console.WriteLine("[A] get:" + get);

                Thread.Sleep(7 * 1000);
            }
        }
    }
}
