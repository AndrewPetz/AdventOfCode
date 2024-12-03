using System.Text.RegularExpressions;
using Utils;

namespace _2024
{
    public class Day03
    {
        public static async Task<int> Part1()
        {
            var input = await Files.ReadFileAsync(3);
            var total = 0;
            var regex = new Regex("mul\\(\\d+\\,\\d+\\)");
            var matches = regex.Matches(input);
            foreach (var m in matches.Select(x => x.Value))
            {
                var s = m.Replace("mul", "")
                    .Replace("(", "")
                    .Replace(")", "");
                var nums = s.Split(",");
                total += int.Parse(nums[0]) * int.Parse(nums[1]);
            }
            return total;
        }

        public static async Task<int> Part2()
        {
            var input = await Files.ReadFileAsync(3);
            var total = 0;
            var regex = new Regex("mul\\(\\d+\\,\\d+\\)|do\\(\\)|don't\\(\\)");
            var matches = regex.Matches(input);

            var shouldMult = true;
            foreach (var m in matches.Select(x => x.Value))
            {
                if (string.Equals(m, "do()", StringComparison.OrdinalIgnoreCase))
                {
                    shouldMult = true;
                }
                else if (string.Equals(m, "don't()", StringComparison.OrdinalIgnoreCase))
                {
                    shouldMult = false;
                }

                if (shouldMult && m.Contains("mul"))
                {
                    var s = m.Replace("mul", "")
                        .Replace("(", "")
                        .Replace(")", "");
                    var nums = s.Split(",");
                    total += int.Parse(nums[0]) * int.Parse(nums[1]);
                }
            }

            return total;
        }
    }
}
