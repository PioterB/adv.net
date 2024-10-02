using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise4
	{

		[TestMethod]
		public void Exercises_Run()
		{
			// arrange
			Company[] allCompanies = new Numbers(10).Select(x => new Company()).ToArray();
			foreach (Company c in allCompanies)
			{
				for (int i=0;i<5;i++)
				{
					c.CreateEmployee();
				}
			}

			List<Employee> employees = allCompanies.SelectMany(c => c.Employees).ToList();

			// assert
			Assert.AreEqual(10*5, employees.Count());
		}
	}
}
