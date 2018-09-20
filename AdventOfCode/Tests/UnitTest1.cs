using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventOfCode;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestDay6_00_999999()
        {
            Program program = new Program();
            Assert.AreEqual(1000000, program.Day6("turn on 0,0 through 999,999"));
        }

        [TestMethod]
        public void TestSimpleInput()
        {
            Assert.AreEqual("This is a test input file.", Program.GetSimpleInput("test"));
        }

        [TestMethod]
        public void TestDay7()
        {
            string[] input = {  "123 -> x",
                                "456 -> y",
                                "x AND y -> d",
                                "x OR y -> e",
                                "x LSHIFT 2 -> f",
                                "y RSHIFT 2 -> g",
                                "NOT x -> h",
                                "NOT y -> i" };

            Program program = new Program();
            Assert.AreEqual(1000000, program.Day7(input));
        }
    }
}
