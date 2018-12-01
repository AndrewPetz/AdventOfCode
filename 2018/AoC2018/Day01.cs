using System.Collections.Generic;
using System.Linq;

namespace AoC2018
{
    class Day01
    {
        public static int Run()
        {
            int rVal = 0;

            List<string> input = Utilities.GetLineInput("01");
            List<int> frequencies = new List<int>();
            
            while (true)
            {
                foreach (string c in input)
                {
                    rVal += int.Parse(c);
                    if (frequencies.Contains(rVal))
                        return rVal;
                    frequencies.Add(rVal);
                }
            }
        }
    }
}
