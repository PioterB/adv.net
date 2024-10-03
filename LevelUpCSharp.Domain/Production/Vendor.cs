using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using LevelUpCSharp.Collections;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
	public class Vendor
    {
        private Thread _worker;

		private readonly ConcurrentQueue<Sandwich> _warehouse; 
		private readonly ProductionRequestsQueue _pendingProduction;
		private readonly IProductionStrategy _productionStrategy;

		public Vendor(string name)
            : this(name, new MadeByMe())
        {
        }

        public Vendor(string name, IProductionStrategy productionStrategy)
        {
            Name = name;
			_productionStrategy = productionStrategy;
			_worker = new Thread(Worker) { IsBackground = true };
            _warehouse = new ConcurrentQueue<Sandwich>();
            _pendingProduction = new ProductionRequestsQueue();
            _worker.Start();
        }


        public event Action<Sandwich[]> Produced;

        public string Name { get; }

        public IEnumerable<Sandwich> Buy(int howMuch = 0)
        {
            var toSell = new List<Sandwich>();
            lock (_warehouse)
			{
				for (int i = 0; i < howMuch; i++)
				{
					var success = _warehouse.TryDequeue(out var sandwitch);
                    if (!success)
                    {
                        return toSell;
                    }

                    toSell.Add(sandwitch);
                }
            }

            return toSell;
        }

        public void Order(SandwichKind kind, int count)
        {
            // opcja A
            var safeCount = (uint)Math.Max(0, count);

            //// opcja B
            //if (count < 0)
            //    throw new ArgumentException("no kidding");

   //         // opcja C
   //         if( count < 0)
			//{
   //             return;
			//}

            _pendingProduction.Enqueue(new ProdcutionRequest(kind, safeCount));
        }

        public IEnumerable<StockItem> GetStock()
        {
            var result = _warehouse.GroupBy(s => s.Kind, (kind, sandwitches) => new StockItem(kind, sandwitches.Count()));
            return result;
        }

        private IEnumerable<Sandwich> Produce(ProdcutionRequest currentOrder)
        {
            var ordered = _productionStrategy.Produce(currentOrder);
            ordered.ForEach(s => _warehouse.Enqueue(s));
             return ordered;
        }

        private void Worker(object obj)
        {
            Random r = new Random((int)DateTime.Now.Ticks);

            while(true)
			{
                var currentOrder = _pendingProduction.Dequeue();
                var ordered = Produce(currentOrder);
                
                Produced?.Invoke(ordered.ToArray());
                
                Thread.Sleep(TimeSpan.FromMilliseconds(r.Next(500, 3000)));
			}
		}
    }
}
