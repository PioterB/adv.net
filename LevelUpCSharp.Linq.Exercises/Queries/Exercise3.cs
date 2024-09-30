using System;
using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise3
	{

		[TestMethod]
		public void Exercises3_Run()
		{
			// arrange
			Company[] allCompanies = new Numbers(10).Select(x => new Company()).ToArray();
			Random random = new Random();
			IEnumerable<Employee> allPersons =
				new Numbers(100).Select(x => allCompanies[random.Next(0, 9)].CreateEmployee());

			// act, get all companies where in minimum one employee earn a salear greater than 2500
			var companiesWithHighSalary = allPersons.Select(x => x.Company);


			// assert
			foreach (Company c in companiesWithHighSalary)
			{
				Assert.IsTrue(c.Employees.Any(x => x.Salear > 2500));
			}
			Assert.AreEqual(companiesWithHighSalary.Distinct().Count(), companiesWithHighSalary.Count());
		}
	}
}
