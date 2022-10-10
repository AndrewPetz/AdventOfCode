using Utils;

namespace _2015
{
    public class Day03
    {
        public static async Task<int> Part1()
        {
            var input = await Files.ReadFileAsync(3);

            var xPos = 0;
            var yPos = 0;
            var houses = new List<House> {
                new() { X = xPos, Y = yPos, Count = 1 } // start with delivering to the first house
            };

            foreach (var i in input)
            {
                switch (i)
                {
                    case '^': // up
                        yPos++;
                        break;
                    case 'v': // down
                        yPos--;
                        break;
                    case '<': // left
                        xPos--;
                        break;
                    case '>': // right
                        xPos++;
                        break;
                }

                var house = houses.FirstOrDefault(x => x.X == xPos && x.Y == yPos);
                if (house == null)
                {
                    house = new House { X = xPos, Y = yPos, Count = 1 };
                    houses.Add(house);
                }
                else
                {
                    house.Count++;
                }
            }

            return houses.Count;
        }

        public static async Task<int> Part2()
        {
            var input = await Files.ReadFileAsync(3);
            var cursor = 0;

            var santaXPos = 0;
            var santaYPos = 0;
            var roboXPos = 0;
            var roboYPos = 0;
            var houses = new List<House> {
                new() { X = santaXPos, Y = santaYPos, Count = 2 } // start with delivering to the first house
            };

            foreach (var i in input)
            {
                switch (i)
                {
                    case '^': // up
                        if (cursor % 2 == 0)
                            santaYPos++;
                        else
                            roboYPos++;
                        break;
                    case 'v': // down
                        if (cursor % 2 == 0)
                            santaYPos--;
                        else
                            roboYPos--;
                        break;
                    case '<': // left
                        if (cursor % 2 == 0)
                            santaXPos--;
                        else
                            roboXPos--;
                        break;
                    case '>': // right
                        if (cursor % 2 == 0)
                            santaXPos++;
                        else
                            roboXPos++;
                        break;
                }

                if (cursor % 2 == 0)
                {
                    var house = houses.FirstOrDefault(x => x.X == santaXPos && x.Y == santaYPos);
                    if (house == null)
                    {
                        house = new House { X = santaXPos, Y = santaYPos, Count = 1 };
                        houses.Add(house);
                    }
                    else
                    {
                        house.Count++;
                    }
                }
                else
                {
                    var house = houses.FirstOrDefault(x => x.X == roboXPos && x.Y == roboYPos);
                    if (house == null)
                    {
                        house = new House { X = roboXPos, Y = roboYPos, Count = 1 };
                        houses.Add(house);
                    }
                    else
                    {
                        house.Count++;
                    }
                }

                cursor++;
            }

            return houses.Count;
        }
    }

    internal class House
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Count { get; set; }
    }
}
