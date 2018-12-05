using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2018
{
    class Day03
    {
        public static void PartOne()
        {
            List<string> input = Utilities.GetLineInput("03");

            int[,] fabric = new int[5000, 5000];

            foreach (string s in input)
            {
                string[] splits = s.Split(' ');
                int start = int.Parse(splits[2].ToString().Replace(":", "").Split(',')[0]);
                int end = int.Parse(splits[2].ToString().Replace(":", "").Split(',')[1]);
                int width = int.Parse(splits[3].ToString().Split('x')[0]);
                int height = int.Parse(splits[3].ToString().Split('x')[1]);

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        fabric[start + i, end + j]++;
                    }
                }
            }

            int rVal = 0;

            for (int i = 0; i < 5000; i++)
            {
                for (int j = 0; j < 5000; j++)
                {
                    if (fabric[i, j] > 1)
                    {
                        rVal++;
                    }
                }
            }

            Console.ReadLine();
        }

        public static void PartTwo()
        {
            List<string> input = Utilities.GetLineInput("03");

            int[,] fabric = new int[5000, 5000];

            foreach (string s in input)
            {
                string[] splits = s.Split(' ');
                int start = int.Parse(splits[2].ToString().Replace(":", "").Split(',')[0]);
                int end = int.Parse(splits[2].ToString().Replace(":", "").Split(',')[1]);
                int width = int.Parse(splits[3].ToString().Split('x')[0]);
                int height = int.Parse(splits[3].ToString().Split('x')[1]);

                for (int i = 0; i < width; i++)
                {
                    for (int j = 0; j < height; j++)
                    {
                        fabric[start + i, end + j]++;
                    }
                }
            }
        }
    }
}
