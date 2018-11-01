using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    public class Helpers
    {
        public static string GetSimpleInput(string day)
        {
            string retVal = null;
            string filepath = Directory.GetCurrentDirectory() + "/Input" + day + ".txt";
            retVal = File.ReadAllText(filepath);
            
            return retVal;
        }
    }
}
