using System.Text.RegularExpressions;
using Utils;

namespace _2023
{
    public class Day01
    {
        public static async Task<int> Part1()
        {
            var day1Text = await Files.ReadLinesAsync(1);
            var total = 0;
            var regex = new Regex(@"\b\d+\b");
            foreach (var line in day1Text)
            {
                var nums = regex.Matches(line);
                var num1 = nums.First().Value;
                var num2 = nums.Last().Value;

                var thisTotal = int.Parse($"{num1}{num2}");
                total += thisTotal;
            }
            return total;
        }

        public static async Task<int> Part2()
        {
            var day1Text = await Files.ReadLinesAsync(1);
            var elves = new List<Elf>();

            // split day1Text into groups based on the empty lines
            var group = new List<int>();
            foreach (var line in day1Text)
            {
                if (line == "")
                {
                    elves.Add(new Elf(group));
                    group = new List<int>();
                }
                else
                {
                    group.Add(int.Parse(line));
                }
            }

            // return the elf with the highest Total
            var topThreeTotal = elves.OrderByDescending(x => x.Total).Take(3).Sum(x => x.Total);
            return topThreeTotal;
        }

        public class Elf
        {
            public Elf(List<int> snackums)
            {
                Snackums = snackums;
            }

            public List<int> Snackums { get; set; }

            public int Total => Snackums.Sum();
        }
    }
}
