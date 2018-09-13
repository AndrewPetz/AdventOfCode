using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            //Day1();
            //Day2();
            //Day3();
            //Day4();
            Day5();
        }

        private static int Day1()
        {
            int retVaL = 0;
            string input = GetSimpleInput(1);
            int pos = 0;

            //input = "(())";

            foreach (char c in input)
            {
                pos++;
                if (Equals(c, '('))
                {
                    retVaL++;
                }
                else if (Equals(c, ')'))
                {
                    retVaL--;
                }
                if (retVaL == -1)
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

        private static int Day3()
        {
            int retVal = 0;
            string input = GetSimpleInput(3);
            int mapSize = 1000;
            int startingPoint = mapSize / 2;
            int[,] map = new int[mapSize, mapSize];

            //input = ">";
            //input = "^>v<";
            //input = "^v^v^v^v^v";

            map[startingPoint, startingPoint] = 2;

            int santaX = startingPoint;
            int santaY = startingPoint;
            int roboX = startingPoint;
            int roboY = startingPoint;
            int step = 1;

            foreach (char c in input)
            {
                if (Equals(c, '^'))
                {
                    if (step % 2 == 0)
                    {
                        roboY++;
                        map[roboX, roboY]++;
                    }
                    else
                    {
                        santaY++;
                        map[santaX, santaY]++;
                    }
                }
                else if (Equals(c, '>'))
                {
                    if (step % 2 == 0)
                    {
                        roboX++;
                        map[roboX, roboY]++;
                    }
                    else
                    {
                        santaX++;
                        map[santaX, santaY]++;
                    }
                }
                else if (Equals(c, 'v'))
                {
                    if (step % 2 == 0)
                    {
                        roboY--;
                        map[roboX, roboY]++;
                    }
                    else
                    {
                        santaY--;
                        map[santaX, santaY]++;
                    }
                }
                else if (Equals(c, '<'))
                {
                    if (step % 2 == 0)
                    {
                        roboX--;
                        map[roboX, roboY]++;
                    }
                    else
                    {
                        santaX--;
                        map[santaX, santaY]++;
                    }
                }
                step++;
            }

            for (int k = 0; k < mapSize; k++)
            {
                for (int l = 0; l < mapSize; l++)
                {
                    if (map[k, l] > 0)
                    {
                        retVal++;
                    }
                }
            }

            return retVal;
        }

        private static int Day4()
        {
            int retVal = 0;
            string input = GetSimpleInput(4);
            bool finished = false;
            string hash = "";
            string md5Input = "";

            while (!finished)
            {
                retVal++;
                md5Input = input + retVal;
                hash = CalculateMD5Hash(md5Input);
                if (hash.IndexOf("000000") == 0)
                {
                    finished = true;
                }
            }

            return retVal;
        }

        private static int Day5()
        {
            string filepath = Directory.GetCurrentDirectory() + "/Inputs/day5.txt";
            var strings = File.ReadAllLines(filepath);
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            HashSet<string> includes = new HashSet<string>();

            foreach (var s in strings)
            {
                int vowelCount = s.Count(c => vowels.Contains(c));

                if (vowelCount < 3)
                    continue;

                foreach (var c in alphabet.Where(c => s.Contains($"{c}{c}")))
                    includes.Add(s);
            }

            HashSet<string> niceStrings = new HashSet<string>(includes);
            string[] badStrings = { "ab", "cd", "pq", "xy" };
            foreach (var s in from s in includes from b in badStrings.Where(s.Contains) select s)
                niceStrings.Remove(s);

            return niceStrings.Count;
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

        private static string CalculateMD5Hash(string input)

        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hash.Length; i++)

            {

                sb.Append(hash[i].ToString("X2"));

            }

            return sb.ToString();

        }
    }
}
