using System.Collections.Generic;
using System.Globalization;

namespace LevelUpCSharp.Linq.Model
{
	public class Company
	{
		private static int index = 0;
		private List<Employee> employees = new List<Employee>();
		public string Name { get; set; }

		public IEnumerable<Employee> Employees { get { return employees; } }

		public void AddEmployee(Employee e)
		{
			employees.Add(e);
		}
		public Company(string name)
		{
			Name = name;

		}
		public Company()
			: this(string.Format(CultureInfo.CurrentCulture, "Company_{0}", index++))
		{
		}

		public Employee CreateEmployee()
		{
			Employee toReturn = new Employee(this);
			employees.Add(toReturn);
			return toReturn;
		}
	}
}
