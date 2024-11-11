using LevelUpCSharp.Products;
using System;

namespace LevelUpCSharp.Production
{
	public class ProdcutionRequest
	{
		private static Lazy<ProdcutionRequest> _empty = new Lazy<ProdcutionRequest>(() => new ProdcutionRequest(SandwichKind.Pork, 0));

		public ProdcutionRequest(SandwichKind kind, uint count)
		{
			Kind = kind;
			Count = count;
		}

		public static ProdcutionRequest Empty => _empty.Value;

		public SandwichKind Kind { get; }

		public uint Count { get; }
	}
}