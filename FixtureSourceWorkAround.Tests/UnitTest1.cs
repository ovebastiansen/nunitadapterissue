using NUnit.Framework;

namespace TestFixtureSourceError
{
    [TestFixtureSource(typeof(TestFactory), nameof(TestFactory.TestCases))]
    public class TestsBroken
    {
        public TestsBroken(TestCaseDefinition definition)
        {
            Definition = definition;
        }

        public TestCaseDefinition Definition { get; }

        [Test]
        public void Test1()
        {
            if (Definition.Browser == "Edgium")
                Assert.Pass();

            Assert.Fail();
        }
    }

    public class TestsGood
    {
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}