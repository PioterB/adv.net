using LevelUpCSharp.Products;
using System;

namespace LevelUpCSharp.Production
{
	internal class Beef : IKeyIngredient
	{
		public Beef()
			:this(DateTime.Now.AddDays(7))
		{
		}

		public Beef(DateTime expDate)
		{
			ExpDate = expDate;
		}


		public SandwichKind Kind => SandwichKind.Beef;

		public DateTime ExpDate { get; }
	}
}