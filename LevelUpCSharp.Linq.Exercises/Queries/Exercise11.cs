using System;
using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise11
	{
		[TestMethod]
		public void Exercises11_Run()
		{
			// arrange
			Company[] allCompanies = new Numbers(10).Select(x => new Company()).ToArray();
			Random random = new Random();
			foreach (Company c in allCompanies)
			{
				for (int i = 0; i < random.Next(1, 25); i++)
				{
					c.CreateEmployee();
				}
			}


			// act, create a dictionary where the company is the key, and the employees are the value (with a reference back to the company)
			Dictionary<Company, EmployeesCollection> results = new Dictionary<Company, EmployeesCollection>();
			foreach (Company c in allCompanies)
			{
				results.Add(c, new EmployeesCollection(c.Employees.ToList(), c));
			}

			Assert.Fail("Generate the dictionary with using Linq and without a internal class");

			// assert
			foreach (var item in results)
			{
				Assert.AreEqual(item.Key, item.Value.Company);
				Assert.AreEqual(item.Key.Employees.Count(), item.Value.Company.Employees.Count());
			}
		}

		private class EmployeesCollection
		{
			public IList<Employee> Employees { get; private set; }
			public Company Company { get; private set; }

			public EmployeesCollection(IList<Employee> employees, Company company)
			{
				Employees = employees;
				Company = company;
			}
		}
	}

}
