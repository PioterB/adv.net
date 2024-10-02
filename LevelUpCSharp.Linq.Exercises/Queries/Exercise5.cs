using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise5
	{

		[TestMethod]
		public void Exercise5_Run()
		{
			// arrange
			Company[] companiesFromA = new Numbers(10).Select(x => new Company()).ToArray();
			Company[] companiesFromB = new Numbers(10).Select(x => new Company()).ToArray();


			List<Company> allCompanies = companiesFromB.Concat(companiesFromA).ToList();

			// assert
			Assert.AreEqual(20, allCompanies.Count());
		}
	}
}
