using System;
using System.Collections.Generic;
using System.Text;

namespace LevelUpCSharp
{
	public static class ResultExtensions
	{
		/// <summary>
		/// Adapts methods return value to successful <see cref="Result{T}"/>.
		/// </summary>
		/// <typeparam name="T">Method's return type.</typeparam>
		/// <param name="value">Method's successful retun value.</param>
		/// <returns>Succeful return value wrapped into <see cref="Result{T}"/>.</returns>
		public static Result<T> AsSuccess<T>(this T value)
		{
			return Result<T>.Success(value);
		}
	}
}
