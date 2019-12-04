using System;
using System.Collections.Generic;

namespace AoC2019
{
    class Day2
    {
        public static void Run()
        {
            // get input
            var input = Utils.GetFullInput("2");

            var stringList = input.Split(',');

            var result = 0;

            while(result != 19690720)
            {
               
                // loop through from 0-99
                for(int i = 0; i <= 99; i++)
                {
                    for(int j = 2; j <= 99; j++)
                    {
                        var intList = new List<int>();
                        foreach (var s in stringList)
                        {
                            intList.Add(int.Parse(s));
                        }
                        // set two values
                        intList[1] = i;
                        intList[2] = j;

                        var currentOpCode = 0;
                        var currentPosition = 0;

                        while (currentOpCode != 99)
                        {
                            // set vars
                            currentOpCode = intList[currentPosition];
                            var param1 = intList[intList[currentPosition + 1]];
                            var param2 = intList[intList[currentPosition + 2]];
                            var indexToChange = intList[currentPosition + 3];

                            // do calculation on numbers
                            // if opcode is 99, break
                            if (currentOpCode == 99)
                            {
                                throw new Exception(intList[0].ToString());
                            }
                            else if (currentOpCode == 1)
                            {
                                // add together
                                intList[indexToChange] = param1 + param2;
                            }
                            else if (currentOpCode == 2)
                            {
                                // multiply
                                intList[indexToChange] = param1 * param2;
                            }
                            else
                            {
                                // there's an issue somewhere
                                throw new Exception();
                            }

                            currentPosition += 4;
                            currentOpCode = intList[currentPosition];
                        }
                        result = intList[0];
                        if(result == 19690720)
                        {
                            Console.WriteLine($"{i}, {j}");
                            Console.ReadLine();
                        }
                    }
                }
            }

            
        }
    }
}