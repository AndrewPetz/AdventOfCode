using Utils;

namespace _2015
{
    public class Day06
    {
        public static async Task<int> Part1()
        {
            var input = await Files.ReadLinesAsync(6);
            var lights = new bool[1000, 1000];

            foreach (var i in input)
            {
                // parse instructions
                switch (i.Substring(0, 7))
                {
                    case "turn on":
                        TurnOn(lights, i);
                        break;
                    case "turn of":
                        TurnOff(lights, i);
                        break;
                    case "toggle ":
                        Toggle(lights, i);
                        break;
                }
            }

            var lightsOn = lights.Cast<bool>().Count(x => x);
            return lightsOn;
        }

        public static async Task Part2()
        {
            var input = await Files.ReadLinesAsync(6);

        }

        private static void TurnOn(ref bool[,] lights, string i)
        {
            var start = i.IndexOf(" ", 8) + 1;
            var end = i.IndexOf(" through ");
            var startCoords = i.Substring(start, end - start).Split(',').Select(int.Parse).ToArray();
            start = end + 9;
            end = i.Length;
            var endCoords = i.Substring(start, end - start).Split(',').Select(int.Parse).ToArray();

            for (int x = startCoords[0]; x <= endCoords[0]; x++)
            {
                for (int y = startCoords[1]; y <= endCoords[1]; y++)
                {
                    lights[x, y] = true;
                }
            }
        }

        private enum Instruction
        {
            TurnOn,
            TurnOff,
            Toggle
        }
    }
}
