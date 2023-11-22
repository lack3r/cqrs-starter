using Events.Something;
using ISXFinancial.CQRS;
using NUnit.Framework;
using System;
using YourDomain.Something;

namespace YourDomainTests
{
    [TestFixture]
    public class SomethingTests : BDDTest<SomethingAggregate>
    {
        private Guid testId;

        [SetUp]
        public void Setup()
        {
            testId = Guid.NewGuid();
        }

        [Test]
        public void SomethingCanHappen()
        {
            Test(
                Given(),
                When(new MakeSomethingHappen
                {
                    Id = testId,
                    What = "Boom!"
                }),
                Then(new SomethingHappened
                {
                    Id = testId,
                    What = "Boom!"
                }));
        }

        [Test]
        public void SomethingCanHappenOnlyOnce()
        {
            Test(
                Given(new SomethingHappened
                {
                    Id = testId,
                    What = "Boom!"
                }),
                When(new MakeSomethingHappen
                {
                    Id = testId,
                    What = "Boom!"
                }),
                ThenFailWith<SomethingCanOnlyHappenOnce>());
        }
    }
}
