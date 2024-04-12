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
                switch (i[..7])
                {
                    case "turn on":
                        TurnOn(ref lights, i);
                        break;
                    case "turn of":
                        TurnOff(ref lights, i);
                        break;
                    case "toggle ":
                        Toggle(ref lights, i);
                        break;
                }
            }

            var lightsOn = lights.Cast<bool>().Count(x => x);
            return lightsOn;
        }

        public static async Task<int> Part2()
        {
            var input = await Files.ReadLinesAsync(6);
            var lights = new int[1000, 1000];

            foreach (var i in input)
            {
                // parse instructions
                switch (i[..7])
                {
                    case "turn on":
                        TurnOn2(ref lights, i);
                        break;
                    case "turn of":
                        TurnOff2(ref lights, i);
                        break;
                    case "toggle ":
                        Toggle2(ref lights, i);
                        break;
                }
            }

            // get the sum total of lights
            var lightsOn = lights.Cast<int>().Sum();

            return lightsOn;
        }

        private static void TurnOn(ref bool[,] lights, string instruction)
        {
            var instructionList = instruction.Split(' ');
            var startPlace = instructionList[2].Split(',');
            var endPlace = instructionList[4].Split(',');

            var startX = int.Parse(startPlace[0]);
            var startY = int.Parse(startPlace[1]);
            var endX = int.Parse(endPlace[0]);
            var endY = int.Parse(endPlace[1]);

            for (var x = startX; x <= endX; x++)
                for (var y = startY; y <= endY; y++)
                    lights[x, y] = true;
        }

        private static void TurnOff(ref bool[,] lights, string instruction)
        {
            var instructionList = instruction.Split(' ');
            var startPlace = instructionList[2].Split(',');
            var endPlace = instructionList[4].Split(',');

            var startX = int.Parse(startPlace[0]);
            var startY = int.Parse(startPlace[1]);
            var endX = int.Parse(endPlace[0]);
            var endY = int.Parse(endPlace[1]);

            for (var x = startX; x <= endX; x++)
                for (var y = startY; y <= endY; y++)
                    lights[x, y] = false;
        }

        private static void Toggle(ref bool[,] lights, string instruction)
        {
            var instructionList = instruction.Split(' ');
            var startPlace = instructionList[1].Split(',');
            var endPlace = instructionList[3].Split(',');

            var startX = int.Parse(startPlace[0]);
            var startY = int.Parse(startPlace[1]);
            var endX = int.Parse(endPlace[0]);
            var endY = int.Parse(endPlace[1]);

            for (var x = startX; x <= endX; x++)
                for (var y = startY; y <= endY; y++)
                    lights[x, y] = !lights[x, y];
        }

        private static void TurnOn2(ref int[,] lights, string instruction)
        {
            var instructionList = instruction.Split(' ');
            var startPlace = instructionList[2].Split(',');
            var endPlace = instructionList[4].Split(',');

            var startX = int.Parse(startPlace[0]);
            var startY = int.Parse(startPlace[1]);
            var endX = int.Parse(endPlace[0]);
            var endY = int.Parse(endPlace[1]);

            for (var x = startX; x <= endX; x++)
                for (var y = startY; y <= endY; y++)
                    lights[x, y]++;
        }

        private static void TurnOff2(ref int[,] lights, string instruction)
        {
            var instructionList = instruction.Split(' ');
            var startPlace = instructionList[2].Split(',');
            var endPlace = instructionList[4].Split(',');

            var startX = int.Parse(startPlace[0]);
            var startY = int.Parse(startPlace[1]);
            var endX = int.Parse(endPlace[0]);
            var endY = int.Parse(endPlace[1]);

            for (var x = startX; x <= endX; x++)
                for (var y = startY; y <= endY; y++)
                    if (lights[x, y] > 0)
                        lights[x, y]--;
        }

        private static void Toggle2(ref int[,] lights, string instruction)
        {
            var instructionList = instruction.Split(' ');
            var startPlace = instructionList[1].Split(',');
            var endPlace = instructionList[3].Split(',');

            var startX = int.Parse(startPlace[0]);
            var startY = int.Parse(startPlace[1]);
            var endX = int.Parse(endPlace[0]);
            var endY = int.Parse(endPlace[1]);

            for (var x = startX; x <= endX; x++)
                for (var y = startY; y <= endY; y++)
                    lights[x, y] += 2;
        }

        private enum Instruction
        {
            TurnOn,
            TurnOff,
            Toggle
        }
    }
}
