using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp.Tax
{
	public static class DecimalExtensions
	{
		/// <summary>
		/// Computes bruttp price by adding VAT tax to given netto price.
		/// </summary>
		/// <param name="netto">Netto price (source).</param>
		/// <param name="vat">Value Added Tax (VAT) expressed in %.</param>
		/// <param name="precision">The number of decimal places in the return value.</param>
		/// <returns>Brutto price (netto + VAT).</returns>
		public static decimal ToBrutto(this decimal netto, int vat, int precision = 4)
		{
			var brutto =  netto +  vat * netto / 100;
			return Math.Round(brutto, precision, MidpointRounding.ToEven);
		}
	}
}
