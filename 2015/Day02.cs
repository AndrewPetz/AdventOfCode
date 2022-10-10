using Utils;

namespace _2015
{
    public class Day02
    {
        public static async Task<int> Part1()
        {
            var lines = await Files.ReadLinesAsync(2);

            var answer = 0;
            foreach (var line in lines)
            {
                // split the line into usable numbers
                var lineSplit = line.Split('x');
                var length = int.Parse(lineSplit[0]);
                var width = int.Parse(lineSplit[1]);
                var height = int.Parse(lineSplit[2]);
                var list = new List<int> { length, width, height }.OrderBy(x => x).ToList();

                var area1 = 2 * length * width;
                var area2 = 2 * width * height;
                var area3 = 2 * height * length;
                var extra = list[0] * list[1];

                var area = area1 + area2 + area3 + extra;

                answer += area;
            }

            return answer;
        }

        public static async Task<int> Part2()
        {
            var lines = await Files.ReadLinesAsync(2);

            var answer = 0;
            foreach (var line in lines)
            {
                // split the line into usable numbers
                var lineSplit = line.Split('x');
                var length = int.Parse(lineSplit[0]);
                var width = int.Parse(lineSplit[1]);
                var height = int.Parse(lineSplit[2]);
                var list = new List<int> { length, width, height }.OrderBy(x => x).ToList();

                var ribbonLength = 0;
                ribbonLength += (list[0] * 2) + (list[1] * 2);
                ribbonLength += list[0] * list[1] * list[2];

                answer += ribbonLength;
            }

            return answer;
        }
    }
}
