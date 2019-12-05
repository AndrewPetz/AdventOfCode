using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2019
{
    class Day3
    {
        public static void Run()
        {
            // get input
            var input = Utils.GetLineInput("3");

            var wire1Text = input[0];
            var wire2Text = input[1];

            var wire1Commands = wire1Text.Split(',');
            var wire2Commands = wire2Text.Split(',');

            List<Coords> intersections = new List<Coords>();

            var currentWire1Coords = new Coords(0, 0);
            var currentWire2Coords = new Coords(0, 0);

            List<Coords> wire1Coords = new List<Coords>();
            //wire1Coords.Add(new Coords(0, 0));


            List<Coords> wire2Coords = new List<Coords>();
            //wire2Coords.Add(new Coords(0, 0));

            foreach (var s in wire1Commands)
            {
                // get command
                var direction = s[0];

                // get distance to go
                var distanceToGo = int.Parse(s.Substring(1, s.Length - 1));

                switch (direction)
                {
                    case 'U':
                        // go up
                        for(int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire1Coords.Y++;
                            newCoords = new Coords(currentWire1Coords.X, currentWire1Coords.Y);
                            wire1Coords.Add(newCoords);
                        }
                        break;

                    case 'D':
                        // go down
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire1Coords.Y--;
                            newCoords = new Coords(currentWire1Coords.X, currentWire1Coords.Y);
                            wire1Coords.Add(newCoords);
                        }
                        break;

                    case 'L':
                        // go left
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire1Coords.X--;
                            newCoords = new Coords(currentWire1Coords.X, currentWire1Coords.Y);
                            wire1Coords.Add(newCoords);
                        }
                        break;

                    case 'R':
                        // go right
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire1Coords.X++;
                            newCoords = new Coords(currentWire1Coords.X, currentWire1Coords.Y);
                            wire1Coords.Add(newCoords);
                        }
                        break;
                }
            }

            foreach (var s in wire2Commands)
            {
                // get command
                var direction = s[0];

                // get distance to go
                var distanceToGo = int.Parse(s.Substring(1, s.Length - 1));

                switch (direction)
                {
                    case 'U':
                        // go up
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire2Coords.Y++;
                            newCoords = new Coords(currentWire2Coords.X, currentWire2Coords.Y);
                            wire2Coords.Add(newCoords);
                        }
                        break;

                    case 'D':
                        // go down
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire2Coords.Y--;
                            newCoords = new Coords(currentWire2Coords.X, currentWire2Coords.Y);
                            wire2Coords.Add(newCoords);
                        }
                        break;

                    case 'L':
                        // go left
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire2Coords.X--;
                            newCoords = new Coords(currentWire2Coords.X, currentWire2Coords.Y);
                            wire2Coords.Add(newCoords);
                        }
                        break;

                    case 'R':
                        // go right
                        for (int i = 0; i < distanceToGo; i++)
                        {
                            Coords newCoords = null;
                            currentWire2Coords.X++;
                            newCoords = new Coords(currentWire2Coords.X, currentWire2Coords.Y);
                            wire2Coords.Add(newCoords);
                        }
                        break;
                }
            }

            // get all intersections
            intersections = wire1Coords.Intersect(wire2Coords, new CustomComparer()).ToList();

            var closest = int.MaxValue;
            foreach (var intersect in intersections)
            {
                var distance = CalculateDistance(new Coords(0, 0), intersect);
                if(distance < closest)
                {
                    closest = distance;
                    if(closest == 159)
                    {
                        Console.Read();
                    }
                }
            }

            // 562, -4757
            //var masterCoord = new Coords(562, -4757);
            var masterCoord = new Coords(155, 4);
            int k = 0;
            int l = 0;
            foreach (var coord in wire1Coords)
            {
                k++;
                if (coord.X == masterCoord.X && coord.Y == masterCoord.Y)
                {
                    Console.Read();
                }
            }

            foreach (var coord in wire2Coords)
            {
                l++;
                if (coord.X == masterCoord.X && coord.Y == masterCoord.Y)
                {
                    Console.Read();
                }
            }
        }

        public static int CalculateDistance(Coords wire1, Coords wire2)
        {
            return Math.Abs(wire1.X + wire2.X) + Math.Abs(wire1.Y + wire2.Y);
        }

        class CustomComparer : IEqualityComparer<Coords>
        {
            #region IEqualityComparer<Coords> Members

            public bool Equals(Coords x, Coords y)
            {
                return x.X == y.X && x.Y == y.Y;
            }

            public int GetHashCode(Coords obj)
            {
                //a hash code based on the specific comparison
                return (obj.X * obj.Y).GetHashCode();
            }

            #endregion
        }

        public class Coords
        {
            public int X { get; set; }
            public int Y { get; set; }

            public Coords(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }
}