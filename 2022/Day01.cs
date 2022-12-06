using Utils;

namespace _2022
{
    public class Day01
    {
        public static async Task<int> Part1()
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
            var highest = elves.Max(x => x.Total);
            return highest;

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
