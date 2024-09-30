using System.Globalization;

namespace LevelUpCSharp.Linq.Model
{
	public class Person
	{
		private static int index = 0;
		public string Name { get; private set; }

		public Person()
			: this(string.Format(CultureInfo.CurrentCulture, "Name_{0}", index++))
		{

		}

		public Person(string name)
		{
			this.Name = name;
		}
	}
}
