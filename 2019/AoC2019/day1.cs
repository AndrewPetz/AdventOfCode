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

                // Part 1
                //total += ProcessModule(double.Parse(i));

                // Part 2
                total += ProcessModulePt2(double.Parse(i));
            }

        }

        private static double ProcessModulePt2(double module)
        {
            // get fuel for current module
            var curModule = ProcessModule(module);
            var total = curModule;

            // get fuel for that fuel until the amount required is zero
            var newCurModule = 1.0;
            while(newCurModule > 0)
            {
                newCurModule = ProcessModule(curModule);
                if(newCurModule > 0)
                {
                    total += newCurModule;
                    curModule = newCurModule;
                }
            }

            

            return total;
        }

        private static double ProcessModule(double module)
        {
            return Math.Floor(module / 3) - 2;
        }
    }
}