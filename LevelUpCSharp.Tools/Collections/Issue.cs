using System;

namespace LevelUpCSharp.Collections
{
	public class Issue<T>
	{
		private T item;
		private readonly Exception e;

		public Issue(T item, Exception e)
		{
			this.item = item;
			this.e = e;
		}

		public T Item { get => item;}

		public Exception E => e;
	}
}