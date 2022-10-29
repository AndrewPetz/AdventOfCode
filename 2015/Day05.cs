using Utils;

namespace _2015
{
    public class Day05
    {
        public static async Task<int> Part1()
        {
            var strings = await Files.ReadLinesAsync(5);
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();
            var includes = new HashSet<string>();
            foreach (var s in strings)
            {
                var vowelCount = s.Count(c => vowels.Contains(c));
                if (vowelCount < 3)
                    continue;
                foreach (var c in alphabet.Where(c => s.Contains($"{c}{c}")))
                    includes.Add(s);
            }
            var niceStrings = new HashSet<string>(includes);
            string[] badStrings = { "ab", "cd", "pq", "xy" };
            foreach (var s in from s in includes from b in badStrings.Where(s.Contains) select s)
                niceStrings.Remove(s);
            return niceStrings.Count;
        }

        public static async Task<int> Part2()
        {
            var strings = await Files.ReadFileAsync(5);
            var ret = strings.Split('\n').Count(line =>
            {
                var appearsTwice = Enumerable.Range(0, line.Length - 1).Any(i => line.IndexOf(line.Substring(i, 2), i + 2) >= 0);
                var repeats = Enumerable.Range(0, line.Length - 2).Any(i => line[i] == line[i + 2]);
                return appearsTwice && repeats;
            });

            return ret;
        }
    }
}
