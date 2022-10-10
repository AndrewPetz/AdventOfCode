using Utils;

namespace _2015
{
    public class Day01
    {
        public static async Task<int> Part1()
        {
            var day1Text = await Files.ReadFileAsync(1);

            var floor = 0;
            var position = 0;
            foreach (var x in day1Text)
            {
                if (x == '(')
                {
                    floor++;
                }
                else if (x == ')')
                {
                    floor--;
                }

                position++;
            }

            return floor;
        }

        public static async Task<int> Part2()
        {
            var day1Text = await Files.ReadFileAsync(1);

            var floor = 0;
            var position = 0;
            foreach (var x in day1Text)
            {
                if (x == '(')
                {
                    floor++;
                }
                else if (x == ')')
                {
                    floor--;
                }

                position++;

                if (floor == -1) return position;
            }

            return 0;
        }
    }
}
