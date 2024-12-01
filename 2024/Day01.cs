using System.Text.RegularExpressions;
using Utils;

namespace _2024;

public class Day01
{
    public static async Task<int> Part1()
    {
        var day1Text = await Files.ReadLinesAsync(1);
        var total = 0;
            
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var line in day1Text)
        {
            var splitLine = line.Split("   ");
            list1.Add(int.Parse(splitLine[0]));
            list2.Add(int.Parse(splitLine[1]));
        }
            
        list1.Sort();
        list2.Sort();

        var distances = list1.Select((t, i) => Math.Abs(t - list2[i])).ToList();
        total += distances.Sum();
        return total;
    }

    public static async Task<int> Part2()
    {
        var day1Text = await Files.ReadLinesAsync(1);
        var total = 0;
            
        var list1 = new List<int>();
        var list2 = new List<int>();
        foreach (var line in day1Text)
        {
            var splitLine = line.Split("   ");
            list1.Add(int.Parse(splitLine[0]));
            list2.Add(int.Parse(splitLine[1]));
        }

        foreach (var item in list1)
        {
            var list2Count = list2.Count(x => x == item);
            total += list2Count * item;
            list2.RemoveAll(x => x == item);
        }

        return total;
    }
}