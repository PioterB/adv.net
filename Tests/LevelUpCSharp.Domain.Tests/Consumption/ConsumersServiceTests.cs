using LevelUpCSharp.Consumption;
using LevelUpCSharp.Testing.Data;
using NSubstitute;
using NUnit.Framework;
using System.Reflection.PortableExecutable;

namespace LevelUpCSharp.Domain.Tests.Consumption
{
    public class ConsumersServiceTests
	{
		private IRepository<string, Consumer> _customers;
		private ConsumersService _unitUnderTest;

        [SetUp]
        public void Setup()
        {
			_customers = Substitute.For<IRepository<string, Consumer>>();
			_unitUnderTest = new ConsumersService(_customers);
        }

        [Test]
        public void Ctor_AlwaysCreates()
        {
            TestDelegate action = () => new ConsumersService(Substitute.For<IRepository<string, Consumer>>());

            Assert.DoesNotThrow(action);
        }

        [Test]
        public void Create_Any_WasPersisted()
        {
            var any = StringGenerator.Instance.Create();
            
            _unitUnderTest.Create(any);

            _customers.Received(1).Add(any, Arg.Is<Consumer>(x => x != null));
        }

        private static object[] InvalildCustomerNames =
        {
            new object[]{ StringGenerator.Instance.Empty() },
            new object[]{ StringGenerator.Instance.Nothing() },
        };

        [Test]
        [TestCaseSource(nameof(InvalildCustomerNames))]
        public void Create_InvalidName_Failed(string name)
        {
            var failure = _unitUnderTest.Create(name);

            Assert.IsTrue(failure.Fail);
        }

        private static object[] ValildCustomerNames =
        {
            new object[]{ StringGenerator.Instance.Create(3) },
            new object[]{ StringGenerator.Instance.Blank() },
        };

        [Test]
        [TestCaseSource(nameof(ValildCustomerNames))]
        public void Create_ValidName_Success(string name)
        {
            var failure = _unitUnderTest.Create(name);

            Assert.IsFalse(failure.Fail);
        }
    }
}