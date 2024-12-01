using Utils;

namespace _2024
{
    public class Day04
    {
        public static async Task<long> Part1()
        {
            var lines = await Files.ReadLinesAsync(4);
            var count = 0;
            foreach (var line in lines)
            {
                var ranges = line.Split(',');
                var range1Nums = ranges[0].Split('-');
                var range1Low = int.Parse(range1Nums[0]);
                var range1High = int.Parse(range1Nums[1]);
                var range2Nums = ranges[1].Split('-');
                var range2Low = int.Parse(range2Nums[0]);
                var range2High = int.Parse(range2Nums[1]);

                var range1Result = range2Low <= range1Low && range2High >= range1High;
                var range2Result = range1Low <= range2Low && range1High >= range2High;

                if (range1Result || range2Result)
                {
                    count++;
                }
            }
            return count;
        }

        public static async Task<long> Part2()
        {
            var lines = await Files.ReadLinesAsync(4);
            var count = 0;
            foreach (var line in lines)
            {
                var ranges = line.Split(',');
                var range1Nums = ranges[0].Split('-');
                var range1Low = int.Parse(range1Nums[0]);
                var range1High = int.Parse(range1Nums[1]);
                var range2Nums = ranges[1].Split('-');
                var range2Low = int.Parse(range2Nums[0]);
                var range2High = int.Parse(range2Nums[1]);

                var range1List = Enumerable.Range(range1Low, range1High - range1Low + 1).ToList();
                var range2List = Enumerable.Range(range2Low, range2High - range2Low + 1).ToList();

                var result = range1List.Intersect(range2List).ToList().Any();

                if (result)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
