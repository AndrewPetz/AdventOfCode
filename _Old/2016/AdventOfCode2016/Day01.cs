using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2016
{
    class Day01
    {
        public static void Run()
        {
            string input = Helpers.GetSimpleInput("01");
            Console.WriteLine("distance: " + FollowDirections(input));
        }

        private static int FollowDirections(string input)
        {
            int retVal = 0;
            Position pos = new Position();

            foreach(string s in input.Split(','))
            {
                string dir = s.Substring(0,1);
                string f = s.Substring(1);
                int blocks = int.Parse(f);
                pos.Move(dir, blocks);
            }

            retVal = Math.Abs(pos.x + pos.y);

            return retVal;
        }

        private class Position
        {
            public int x = 0;
            public int y = 0;
            public int dir = 0;

            public const int NORTH = 0;
            public const int EAST = 1;
            public const int SOUTH = 2;
            public const int WEST = 3;

            public void Move(string turnDir, int blocks)
            {
                if(string.Equals(turnDir, "L"))
                {
                    if(dir == NORTH)
                    {
                        dir = WEST;
                    } else
                    {
                        dir--;
                    }
                } else if(string.Equals(turnDir, "R"))
                {
                    if (dir == WEST)
                    {
                        dir = NORTH;
                    }
                    else
                    {
                        dir++;
                    }
                }
                switch(dir)
                {
                    case NORTH:
                        y += blocks;
                        break;
                    case EAST:
                        x += blocks;
                        break;
                    case SOUTH:
                        y -= blocks;
                        break;
                    case WEST:
                        x -= blocks;
                        break;
                }
            }
        }
    }
}
