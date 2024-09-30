using System.Linq;
using LevelUpCSharp.Linq.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LevelUpCSharp.Linq.Counters
{
	[TestClass]
	public class MoveNextCounterTests
	{
        private readonly Numbers _numbers = new Numbers(100);

		[TestInitialize]
		public void TestInitialize()
		{
			NumbersIterator.ResetMoveNextCounter();
		}
		
		[TestMethod]
		public void ToArray()
		{
			_numbers.ToArray();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void Cast()
		{
			var _= _numbers.Cast<object>();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void Cast_ToArray()
		{
			var _ =_numbers.Cast<object>().ToArray();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void Where()
		{
            var _ = _numbers.Where(x => x > 10);

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void First()
		{
            var _ = _numbers.First(x => x == 10);

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void Single()
		{
            var _ = _numbers.Single(x => x == 10);

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void WhereEqualsToTen_First()
		{
            var _ = _numbers.Where(x => x == 10).First();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void WhereGreatenThenTen_WhereGreaterThenTwenty_First()
		{
            var _ = _numbers.Where(x => x > 10).Where(x => x > 20).First();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}

		[TestMethod]
		public void WhereGreatenThenTwenty_WhereGreaterThenTen_First()
		{
            var _ = _numbers.Where(x => x > 20).Where(x => x > 10).First();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}


		[TestMethod]
		public void WhereLowerThenFifty_Count()
        {
            var _ = _numbers
                .Where(x => x < 50)
                .Count();

			Assert.AreEqual(/*??*/ -1, NumbersIterator.MoveNextCounter);
		}
	}
}
