using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise7
	{

		[TestMethod]
		public void Exercises7_Run()
		{
			// arrange
			Company[] allCompaniesFromSourceA = new Numbers(10).Select(x => new Company(x.ToString())).ToArray();
			Company[] allCompaniesFromSourceB = new Numbers(10).Select(x => new Company(x.ToString())).ToArray();


			// act, compare the elements in the given list based on the company name
			allCompaniesFromSourceA = allCompaniesFromSourceA.OrderBy(x => x.Name).ToArray();
			allCompaniesFromSourceB = allCompaniesFromSourceB.OrderBy(x => x.Name).ToArray();
			bool areEqual = true;
			areEqual &= allCompaniesFromSourceA.Length == allCompaniesFromSourceB.Length;
			if (areEqual)
			{
				for (int i = 0; i < allCompaniesFromSourceA.Length; i++)
				{
					areEqual &= allCompaniesFromSourceA[i].Name == allCompaniesFromSourceB[i].Name;
				}
			}
			Assert.Fail("compare the lists using linq");

			// assert
			Assert.IsTrue(areEqual);
		}

	}
}
