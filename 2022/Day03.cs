using Utils;

namespace _2022
{
    public class Day03
    {
        private const string AllLetters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static async Task<int> Part1()
        {
            var lines = await Files.ReadLinesAsync(3);
            var total = 0;
            foreach (var line in lines)
            {
                // split the line in two halves
                var firstHalf = line[..(line.Length / 2)].ToList();
                var secondHalf = line.Substring(line.Length / 2, line.Length / 2).ToList();

                var commonLetter = firstHalf.Intersect(secondHalf).ToList();

                total += AllLetters.IndexOf(commonLetter[0]) + 1;
            }
            return total;
        }

        public static async Task<int> Part2()
        {
            var lines = await Files.ReadLinesAsync(3);
            var total = 0;

            // get lines in groups of three
            var groups = GroupLines(lines);

            foreach (var group in groups)
            {
                var list = group.ToList();
                var commonLetter = list[0].Intersect(list[1].Intersect(list[2])).ToList();

                total += AllLetters.IndexOf(commonLetter[0]) + 1;
            }
            return total;
        }

        private static IEnumerable<IEnumerable<string>> GroupLines(IReadOnlyList<string> lines)
        {
            for (var i = 0; i < lines.Count; i += 3)
            {
                yield return new[] { lines[i], lines[i + 1], lines[i + 2] };
            }
        }
    }
}
