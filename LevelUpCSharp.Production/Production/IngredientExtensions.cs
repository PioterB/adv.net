using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp.Production
{
	public static class IngredientExtensions
	{
		public static IEnumerable<string> ToStrings(this IEnumerable<IGarnish> source)
		{
			foreach (IGarnish ingredient in source)
			{
				yield return ingredient.Name;
			}
		}
	}
}
