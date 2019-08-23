using System;
using Canvas.Common;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CanvasTests.CommonTests
{
    /// <summary>
    /// Summary description for StringParserTests
    /// </summary>
    [TestClass]
    public class StringParserTests
    {

        [TestMethod, TestCategory("Unit")]
        public void StringToIntShouldThrowArgumentException()
        {
            var testString = "12a";

            Action act = () => { testString.StringToInt(); };

            act.Should().Throw<ArgumentException>();
        }

        [TestMethod, TestCategory("Unit")]
        public void StringToIntShouldReturnCorrectNumber()
        {
            var testString = "12";

            var result = testString.StringToInt();

            result.Should().Be(12);
        }

        [TestMethod, TestCategory("Unit")]
        public void StringToCharShouldThrowArgumentException()
        {
            var testString = "12a";

            Action act = () => { testString.StringToChar(); };

            act.Should().Throw<ArgumentException>();
        }

        [TestMethod, TestCategory("Unit")]
        public void StringToCharShouldReturnCorrectNumber()
        {
            var testString = "a";

            var result = testString.StringToChar();

            result.Should().Be('a');
        }
    }
}
