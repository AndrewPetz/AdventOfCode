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
            program.Day6("turn on 0,0 through 999,999");
        }
    }
}
