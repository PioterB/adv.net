using System.Collections.Generic;
using System.Linq;
using LevelUpCSharp.Linq.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Queries
{
	[TestClass]
	public class Exercise1
	{

		[TestMethod]
		public void Exercises1_Run()
		{
			// arrange
			IEnumerable<Person> allPersons = new[] {new Employee(), new Person(), new Employee()};
		
			// act, get all persons that are employees
			var allEmployes = allPersons;

			// assert
			Assert.AreEqual(2, allEmployes.Count());
		}
	}
}
