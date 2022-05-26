// See https://aka.ms/new-console-template for more information

public static class Day1
{
    public static int Day1Part1(List<int> lines)
    {
        var increasedNum = 0;
        var decreasedNum = 0;

        var prevNum = -999;

        foreach (var line in lines)
        {
            if (prevNum == -999)
            {
                prevNum = line;
            }
            else
            {
                if (line > prevNum)
                {
                    increasedNum++;
                }
                else if (line < prevNum)
                {
                    decreasedNum++;
                }
                prevNum = line;
            }
        }

        return increasedNum;
    }

    public static int Day1Part2(List<int> lines)
    {
        var increasedNum = 0;

        var slidingWindow1 = 0;
        var slidingWindow2 = 0;

        for (var i = 0; i < lines.Count; i++)
        {
            var test = lines[lines.Count + 1];
            if (lines.ElementAt(i + 3) != null)
            {
                // logic
            }
            slidingWindow1 = lines[i] + lines[i + 1] + lines[i + 2];
            slidingWindow2 = lines[i + 1] + lines[i + 2] + lines[i + 3];
        }

        return 0;
    }
}
