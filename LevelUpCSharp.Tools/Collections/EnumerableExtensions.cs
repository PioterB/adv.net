using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp.Collections
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Executes given logic agains every single item present in source collection.
		/// </summary>
		/// <typeparam name="T">Type of colletion's item</typeparam>
		/// <param name="source">Collection of items of given type.</param>
		/// <param name="job">Job made against single item in the collection.</param>
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> job)
		{
			foreach (T item in source)
			{
				job(item);
			}
		}

		/// <summary>
		/// Executes given logic agains every single item present in source collection.
		/// </summary>
		/// <typeparam name="T">Type of colletion's item</typeparam>
		/// <param name="source">Collection of items of given type.</param>
		/// <param name="job">Job made against single item in the collection.</param>
		public static IEnumerable<Issue<T>> SafeForEach<T>(this IEnumerable<T> source, Action<T> job)
		{
			if (job == null)
			{
				new ArgumentNullException("na nullach nie dzialam!");
			}

			var issues = new List<Issue<T>>();
			foreach (T item in source)
			{
				try
				{
					job(item);
				}
				catch (Exception e)
				{
					issues.Add(new Issue<T>(item, e));
				}
			}

			return issues;
		}
	}
}