using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using CounterChallenge.Service.UniqueCharacterParser;

namespace UnitTest.CounterChallenge.UniqueCharacterParser
{
    public class RegexUniqueCharacterParserServiceTest
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(null, "")]
        [InlineData("                                          ", "")]
        [InlineData("It was many and many a year ago", "I0t w1s m2y a1d m2y a y2r a1o")]
        [InlineData("Copyright,Microsoft:Corporation", "C7t,M6t:C6n")]
        [InlineData("                                         Hello!", "                                         H2o!")]
        [InlineData("!!!!Hello!!!!", "!!!!H2o!!!!")]
        public void RegexParserReturnsExpectedValue(string input, string expected)
        {
            var sut = CreateTestSystem();

            var actual = sut.Parse(input);

            Assert.Equal(expected, actual);
        }

        private RegexUniqueCharacterParserService CreateTestSystem()
        {
            return new RegexUniqueCharacterParserService();
        }
    }
}
