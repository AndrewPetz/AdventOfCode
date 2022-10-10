using Utils;

namespace _2015
{
    public class Day02
    {
        public static async Task<int> Part1()
        {
            var test = await Files.GetInput(2015, 25);
            var lines = await Files.ReadLinesAsync(2);

            var answer = 0;
            foreach (var line in lines)
            {
                // split the line into usable numbers
                var lineSplit = line.Split('x');
                var length = int.Parse(lineSplit[0]);
                var width = int.Parse(lineSplit[1]);
                var height = int.Parse(lineSplit[2]);
                var smallest = 0;
                if (length < width && length < height)
                {
                    smallest = length;
                }
                else if (width < height)
                {
                    smallest = width;
                }
                else
                {
                    smallest = height;
                }

                var area1 = 2 * length * width;
                var area2 = 2 * width * height;
                var area3 = 2 * height * length;
                var extra = smallest * smallest;

                var area = area1 + area2 + area3 + extra;

                answer += area;
            }

            return answer;
        }

        public static async Task Part2()
        {

        }
    }
}
