// See https://aka.ms/new-console-template for more information
using Utils;

var day1Lines = await Files.ReadLinesAsync(1);
Console.WriteLine(Day1.Day1Part1(day1Lines.Select(x => int.Parse(x)).ToList()));
Console.WriteLine(Day1.Day1Part2(day1Lines.Select(x => int.Parse(x)).ToList()));