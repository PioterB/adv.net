using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise10
	{

		[TestMethod]
		public void Exercises10_Run()
		{
			// arrange
			Company[] allCompaniesFromSourceA = new Numbers(10).Select(x => new Company((x).ToString())).ToArray();
			Company[] allCompaniesFromSourceB = new Numbers(5).Select(x => new Company((x * 2).ToString())).ToArray();


			// act, get the intersection set of allCompaniesFromSourceA and allCompaniesFromSourceB depending on the name
			List<Company> intersectionSet = new List<Company>();
			foreach (Company p in allCompaniesFromSourceA)
			{
				if (allCompaniesFromSourceB.Contains(p, new MyCompanyComparer()))
				{
					intersectionSet.Add(p);
				}
			}
			Assert.Fail("build the intersection set using Linq");

			// assert
			foreach (var item in intersectionSet)
			{
				Assert.IsTrue(allCompaniesFromSourceA.Contains(item, new MyCompanyComparer()));
				Assert.IsTrue(allCompaniesFromSourceB.Contains(item, new MyCompanyComparer()));
			}

		}

	}
}
