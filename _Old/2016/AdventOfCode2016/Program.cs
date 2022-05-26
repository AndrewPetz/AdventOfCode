using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Action> days = new List<Action> {
                () => Day01.Run()
            };
            for (int i = 0; i < days.Count; i++)
            {
                Console.WriteLine("Day " + (i + 1) + ":");
                days[i].Invoke();
                Console.WriteLine();
            }
            Console.WriteLine("Finished!");
            Console.ReadKey();
        }
    }
}
