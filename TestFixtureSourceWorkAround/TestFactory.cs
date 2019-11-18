using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace TestFixtureSourceError
{
    public static class Settings
    {
        public static bool SingleBrowser { get; set; } = false;
    }

    public class TestCaseDefinition
    {
        public string Os { get; set; }
        public string Browser { get; set; }

        public override string ToString()
        {
            return $"{Os} {Browser}";
        }
    }

    public static class TestFactory
    {
        public static IEnumerable TestCases
        {
            get
            {
                var cases = GetTests(Settings.SingleBrowser);
                return cases;
            }
        }

        private static IEnumerable GetTests(bool singleBrowser)
        {
            var cases = new List<TestFixtureData>();
            var definition = new TestCaseDefinition { Os = "Windows", Browser = "Google" };
            var data = new TestFixtureData(definition);
            data.TestName = definition.ToString();
            yield return data;
            if(!singleBrowser)
            {
                var definition2 = new TestCaseDefinition { Os = "Windows", Browser = "Edgium" };
                var data2 = new TestFixtureData(definition2);
                data.TestName = definition.ToString();
                yield return data2;
            }
        }
    }
}
