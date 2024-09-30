using System;
using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise8
	{

		[TestMethod]
		public void Exercises8_Run()
		{
			// arrange
			Company[] allCompanies = new Numbers(10).Select(x => new Company()).ToArray();
			foreach (Company c in allCompanies)
			{
				for (int i = 0; i < 5; i++)
				{
					c.CreateEmployee();
				}
			}

			// act, group the employees from the companies in important employees (salear > 2500)
			// and not so important employees(salear <= 2500)
			// for each group the min and the max salear should be retrieved
			List<Employee> importantEmployees = new List<Employee>();
			List<Employee> notImportantEmployees = new List<Employee>();
			int minSalearImportant = int.MaxValue;
			int minSalearNotImportant = int.MaxValue;
			int maxSalearImportant = int.MinValue;
			int maxSalearNotImportant = int.MinValue;
			foreach (Company c in allCompanies)
			{
				foreach (Employee e in c.Employees)
					if (e.Salear <= 2500)
					{
						notImportantEmployees.Add(e);
						minSalearNotImportant = Math.Min(minSalearNotImportant, e.Salear);
						maxSalearNotImportant = Math.Max(maxSalearNotImportant, e.Salear);
					}
					else
					{
						importantEmployees.Add(e);
						minSalearImportant = Math.Min(minSalearImportant, e.Salear);
						maxSalearImportant = Math.Max(maxSalearImportant, e.Salear);
					}
			}


			// assert
			Assert.Fail("group the data via linq");
			Assert.IsFalse(notImportantEmployees.Exists(x => x.Salear > 2500));
			Assert.AreEqual(notImportantEmployees.Max(x => x.Salear), maxSalearNotImportant);
			Assert.AreEqual(notImportantEmployees.Min(x => x.Salear), minSalearNotImportant);
			Assert.IsFalse(importantEmployees.Exists(x => x.Salear <= 2500));
			Assert.AreEqual(importantEmployees.Max(x => x.Salear), maxSalearImportant);
			Assert.AreEqual(importantEmployees.Min(x => x.Salear), minSalearImportant);
		}

	}
}
