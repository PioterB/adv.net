﻿using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise6
	{

		[TestMethod]
		public void Exercises6_1_Run()
		{
			// arrange
			Company[] allCompanies = new Numbers(10).Select(x => new Company()).ToArray();
			Company c1 = new Company() { Name = allCompanies[2].Name };


			// act, detect if the given company already exists depending on its name
			bool containsComapany = allCompanies.Any(c => c.Name.Equals(c1.Name));

			// assert
			Assert.IsTrue(containsComapany);
		}

		[TestMethod]
		public void Exercises6_2_Run()
		{
			// arrange
			List<Company> allCompanies = new Numbers(10).Select(x => new Company()).ToList();
			allCompanies[0].Name = "ZZZ";
			Company lastCompany = allCompanies[0];

			// act, order all companies by their name
			allCompanies = allCompanies.OrderBy(c => c.Name).ToList();

			// assert
			Assert.AreEqual(lastCompany, allCompanies.Last());
		}

		[TestMethod]
		public void Exercises6_3_Run()
		{
			// arrange
			Company c1 = new Company() { Name = "A" };

			IEnumerable<Company> allCompanies =
				new[]
					{
						new Company() {Name = "ABC"},
						c1,
						new Company() {Name = "A"},
						new Company() {Name = "B"},
						c1,
					};

			// act, return a list of distinct companies (key is the company name) 
			IEnumerable<Company> filteredCompanies = allCompanies
				.GroupBy(c => c.Name)
				.Select(c => c.First())
				.ToArray();

			// assert
			Assert.AreEqual(3, filteredCompanies.Count());
		}

		[TestMethod]
		public void Exercises6_4_Run()
		{
			// arrange
			List<Company> allCompanies = new Numbers(10).Select(x => new Company()).ToList();
			allCompanies[1].Name = "ZZZ";
			Company lastCompany = allCompanies[1];

			// act, order all companies by their name and remember the old index from the list
			Dictionary<Company, int> oldIndexByCompany =
				allCompanies
					.Select((c, i) => new { c, i })
					.OrderBy(x => x.c.Name)
					.ToDictionary(x => x.c, x => x.i);

			// assert
			Assert.AreEqual(lastCompany, oldIndexByCompany.Last().Key);
			Assert.AreEqual(1, oldIndexByCompany.Last().Value);
		}
	}
}