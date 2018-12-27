using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018
{
    class Day02
    {
        public static int Run()
        {
            int rVal = 0;

            List<string> input = Utilities.GetLineInput("02");

            int twice = 0;
            int thrice = 0;

            foreach (string s in input)
            {
                bool hasTwo = false;
                bool hasThree = false;
                foreach (char c in s.ToCharArray())
                {
                    int count = s.Count(f => f == c);
                    if (count == 2)
                    {
                        hasTwo = true;
                    }
                    else if (count == 3)
                    {
                        hasThree = true;
                    }
                }
                if (hasTwo)
                {
                    twice++;
                }
                if (hasThree)
                {
                    thrice++;
                }
            }

            rVal = twice * thrice;
            return rVal;
        }
    }
}
