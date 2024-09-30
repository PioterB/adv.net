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

			// act, create a list of all available employees using one single query
			List<Employee> employees=new List<Employee>();
			foreach (Company c in allCompanies)
			{
				foreach (Employee e in c.Employees)
				{
					employees.Add(e);
				}
			}
			Assert.Fail("create a list of all available employees using one single query");

			// assert
			Assert.AreEqual(10*5, employees.Count());
		}
	}
}
