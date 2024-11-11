using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using LevelUpCSharp.Products;

namespace LevelUpCSharp.Production
{
	internal class ProductionRequestsQueue : IEnumerable<ProdcutionRequest>
	{
		private ConcurrentQueue<ProdcutionRequest> _queue;

		public ProductionRequestsQueue()
		{
            _queue = new ConcurrentQueue<ProdcutionRequest>();
		}

		public ProductionRequestsQueue(IEnumerable<ProdcutionRequest> source)
		{
            _queue = new ConcurrentQueue<ProdcutionRequest>(source);
		}

		public IEnumerator<ProdcutionRequest> GetEnumerator()
		{
            return _queue.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
            return GetEnumerator();
		}

        public void Enqueue(ProdcutionRequest item)
		{
            _queue.Enqueue(item);
		}

        public void Enqueue(SandwichKind kind, uint count)
        {
            var order = new ProdcutionRequest(kind, count);
            _queue.Enqueue(order);
        }

        public ProdcutionRequest Dequeue()
		{
            _queue.TryDequeue(out var order);
            return order ?? ProdcutionRequest.Empty;
        }

		public static implicit operator ConcurrentQueue<object>(ProductionRequestsQueue v)
		{
			throw new NotImplementedException();
		}
	}
}
