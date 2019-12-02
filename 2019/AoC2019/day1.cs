using System;

namespace AoC2019
{
    class Day1
    {
        public static void Run()
        {
            // get input
            var input = Utils.GetLineInput("1");
            var total = 0.0;

            // solve problem
            foreach(var i in input)
            {
                // divide by three, round down, subtract 2
                // add to total
                total += Math.Floor(double.Parse(i) / 3) - 2;
            }
        }
        
    }
}
