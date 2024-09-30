using System;

namespace LevelUpCSharp.Linq.Model
{
	public class Employee : Person
	{

		public Company Company { get; private set; }
		
		public int Salear { get; private set; }
		private static Random random = new Random();

		public Employee(Company company=null)
		{
			Salear = random.Next(1, 10) * 500;
			Company = company;
		}

	}
}
