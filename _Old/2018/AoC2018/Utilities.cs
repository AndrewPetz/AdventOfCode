using System.Collections.Generic;
using System.IO;

namespace AoC2018
{
    class Utilities
    {
        public static string GetFullInput(string day)
        {
            string retVal = "";
            string filepath = Directory.GetCurrentDirectory() + string.Format("/input/input{0}.txt", day);

            if (File.Exists(filepath))
            {
                string text = File.ReadAllText(filepath);
                retVal = text;
            }

            return retVal;
        }

        public static List<string> GetLineInput(string day)
        {
            List<string> rVal = new List<string>();
            string filepath = Directory.GetCurrentDirectory() + string.Format("/input/input{0}.txt", day);

            string line;

            if (File.Exists(filepath))
            {
                StreamReader file = new StreamReader(filepath);
                while ((line = file.ReadLine()) != null)
                {
                    rVal.Add(line);
                }
            }
            return rVal;
        }
    }
}
