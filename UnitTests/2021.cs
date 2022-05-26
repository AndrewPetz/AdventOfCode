using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class UnitTest1
    {
        private static List<int> GetDay1Part1Data =>
        new List<int>
        {
            199,
            200,
            208,
            210,
            200,
            207,
            240,
            269,
            260,
            263
        };

        [Fact]
        public void Day1Part1()
        {
            var testList = new List<int>
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            };
            Assert.Equal(7, Day1.Day1Part1(testList));
        }

        [Fact]
        public void Day1Part2()
        {
            var testList = new List<int>
            {
                199,
                200,
                208,
                210,
                200,
                207,
                240,
                269,
                260,
                263
            };
            Assert.Equal(5, Day1.Day1Part2(testList));
        }
    }
}