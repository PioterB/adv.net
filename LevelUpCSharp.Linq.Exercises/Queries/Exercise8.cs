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
			var result = allCompanies
				.SelectMany(x => x.Employees)
				.GroupBy(
					x =>
						x.Salear <= 2500,
					(important, employees) =>
						new
						{
							IsImporant = !important,
							Employees = employees,
							MaxSalear = employees.Max(x => x.Salear),
							MinSalear = employees.Min(x => x.Salear),
						})
				.OrderBy(x => x.IsImporant)
				.ToArray();

			int minSalearImportant = result[1].MinSalear;
			int minSalearNotImportant = result[0].MinSalear;
			int maxSalearImportant = result[1].MaxSalear;
			int maxSalearNotImportant = result[0].MaxSalear;
			var notImportantEmployees = result[0].Employees.ToList();
			var importantEmployees = result[1].Employees.ToList();


			// assert
			Assert.IsFalse(notImportantEmployees.Exists(x => x.Salear > 2500));
			Assert.AreEqual(notImportantEmployees.Max(x => x.Salear), maxSalearNotImportant);
			Assert.AreEqual(notImportantEmployees.Min(x => x.Salear), minSalearNotImportant);
			Assert.IsFalse(importantEmployees.Exists(x => x.Salear <= 2500));
			Assert.AreEqual(importantEmployees.Max(x => x.Salear), maxSalearImportant);
			Assert.AreEqual(importantEmployees.Min(x => x.Salear), minSalearImportant);
		}

	}
}