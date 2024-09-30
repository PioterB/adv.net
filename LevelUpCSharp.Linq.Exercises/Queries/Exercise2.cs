using System;
using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise2
	{

		[TestMethod]
		public void Exercises2_Run()
		{
			// arrange
			IEnumerable<object> allItems = new[] { new Employee(), new Employee(), new Person() };

			// act, refactor the code so that Linq is used to get a list of persons
			IList<Person> allPersons = new List<Person>();
			foreach (Object obj in allItems)
			{
				allPersons.Add((Person)obj);

			}
			Assert.Fail("refactor the code so that Linq is used to get a list of persons");

			// assert
			Assert.AreEqual(3, allPersons.Count());
		}
	}
}
