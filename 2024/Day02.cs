using Utils;

namespace _2024
{
    public class Day02
    {
        public static async Task<int> Part1()
        {
            var lines = await Files.ReadLinesAsync(2);
            var totalSafe = 0;

            foreach (var line in lines)
            {
                var lineList = line.Split(' ').ToList();
                totalSafe += CheckReport(lineList) ? 1 : 0;
            }

            return totalSafe;
        }

        public static async Task<int> Part2()
        {
            var lines = await Files.ReadLinesAsync(2);
            var totalSafe = 0;

            foreach (var line in lines)
            {
                var lineList = line.Split(' ').ToList();
                var isSafe = CheckReport(lineList);
                if (!isSafe)
                {
                    for (var i = 0; i < lineList.Count; i++)
                    {
                        var newList = new List<string>(lineList);
                        newList.RemoveAt(i);
                        if (CheckReport(newList))
                        {
                            isSafe = true;
                            break;
                        }
                    }
                }
                totalSafe += isSafe ? 1 : 0;
            }

            return totalSafe;
        }

        private static bool CheckReport(List<string> lineList)
        {
            var isSafe = true;
            var isIncreasing = false;
            var isDecreasing = false;

            var prev = int.Parse(lineList[0]);
            for (var i = 1; i < lineList.Count; i++)
            {
                var current = int.Parse(lineList[i]);
                var diff = current - prev;
                if (diff == 0)
                {
                    isSafe = false;
                    break;
                }
                if (Math.Abs(diff) > 3)
                {
                    isSafe = false;
                    break;
                }
                if (diff > 0) isIncreasing = true;
                if (diff < 0) isDecreasing = true;
                prev = current;
            }
            if (isIncreasing && isDecreasing)
            {
                isSafe = false;
            }

            return isSafe;
        }
    }
}
