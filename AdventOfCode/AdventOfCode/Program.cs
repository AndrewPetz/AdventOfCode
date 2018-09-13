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
            //Day1();
            Day2();
        }

        private static int Day1()
        {
            int retVaL = 0;
            string input = GetSimpleInput(1);
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

        private static int Day2()
        {
            int retVal = 0;
            int ribbon = 0;
            string line;
            string filepath = Directory.GetCurrentDirectory() + "/Inputs/day2.txt";

            if (File.Exists(filepath))
            {
                StreamReader file = new StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    string[] dimensions = line.Split('x');
                    int[] intDimensions = new int[3];

                    intDimensions[0] = int.Parse(dimensions[0]);
                    intDimensions[1] = int.Parse(dimensions[1]);
                    intDimensions[2] = int.Parse(dimensions[2]);

                    Array.Sort(intDimensions);

                    int l = intDimensions[0];
                    int w = intDimensions[1];
                    int h = intDimensions[2];
                    int lw = l * w;
                    int wh = w * h;
                    int lh = l * h;
                    int minArea = Math.Min(lw, Math.Min(wh, lh));
                    int vol = l * w * h;

                    ribbon += vol + l + l + w + w;

                    retVal += (2 * lw) + (2 * wh) + (2 * lh) + minArea;
                }

                file.Close();
            }

            return retVal;
        }

        private static string GetSimpleInput(int day)
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
