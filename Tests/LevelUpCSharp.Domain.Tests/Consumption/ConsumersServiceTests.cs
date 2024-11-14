using LevelUpCSharp.Consumption;
using LevelUpCSharp.Testing.Data;
using NUnit.Framework;
using System.Reflection.Metadata;

namespace LevelUpCSharp.Domain.Tests.Consumption
{
    public class ConsumersServiceTests
	{
		private ConsumersService _unitUnderTest;

        [SetUp]
        public void Setup()
        {
			IRepository<string, Consumer> customers = null;
			_unitUnderTest = new ConsumersService(customers);
        }

        [Test]
        public void Create_MissingName_Failed()
        {
            var invalidName = StringGenerator.Instance.Nothing();

            var failure = _unitUnderTest.Create(invalidName);

            Assert.IsTrue(failure.Fail);
        }

        [Test]
        public void Create_EmptyName_Failed()
        {
            var invalidName = StringGenerator.Instance.Empty();

            var failure = _unitUnderTest.Create(invalidName);

            Assert.IsTrue(failure.Fail);
        }

        [Test]
        public void Create_BlankName_Success()
        {
            var invalidName = StringGenerator.Instance.Blank();

            var success = _unitUnderTest.Create(invalidName);

            Assert.IsFalse(success.Fail);
        }

        [Test]
        public void Create_ValidName_Success()
        {
            Assert.Fail();
        }
    }
}