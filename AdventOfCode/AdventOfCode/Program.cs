using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            Day1();
        }

        private static int Day1()
        {
            int retVaL = 0;
            string input = GetInput(1);
            int pos = 0;

            //input = "(())";

            foreach(char c in input)
            {
                pos++;
                if(Equals(c, '('))
                {
                    retVaL++;
                } else if(Equals(c, ')'))
                {
                    retVaL--;
                }
                if(retVaL == -1)
                {
                    Console.WriteLine("retVaL -1 at " + pos);
                }
            }

            return retVaL;
        }

        private static string GetInput(int day)
        {
            string retVal = "";
            string filepath = Directory.GetCurrentDirectory() + "/Inputs/day" + day + ".txt";

            if (File.Exists(filepath))
            {
                string text = File.ReadAllText(filepath);
                retVal = text;
            }

            return retVal;
        }
    }
}
