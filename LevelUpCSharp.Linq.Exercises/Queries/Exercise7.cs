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
			bool areEqual = allCompaniesFromSourceB.OrderBy(c => c.Name)
				.SequenceEqual(allCompaniesFromSourceA.OrderBy(c => c.Name), new MyCompanyComparer());

			// assert
			Assert.IsTrue(areEqual);
		}

	}
}