namespace Utils
{
    public static class Files
    {
        public static async Task<string> ReadFileAsync(int day)
        {
            var filename = GetDayFilename(day);

            try
            {
                using StreamReader? sr = new(filename);
                return await sr.ReadToEndAsync();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                throw e;
            }
        }
        public static async Task<List<string>> ReadLinesAsync(int day)
        {
            // get file name
            string filename;
            if (day < 10)
            {
                filename = $"inputs/day0{day}.txt";
            }
            else
            {
                filename = $"inputs/day{day}.txt";
            }

            var lines = new List<string>();
            try
            {
                var linesEnum = await File.ReadAllLinesAsync(filename);
                lines = linesEnum.ToList();
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return lines;
        }

        public static async Task<List<int>> ReadLinesIntAsync(int day)
        {
            var lines = await ReadLinesAsync(day);
            return lines.Select(int.Parse).ToList();
        }

        private static string GetDayFilename(int day)
        {
            // get file name
            string filename;
            if (day < 10)
            {
                filename = $"inputs/day0{day}.txt";
            }
            else
            {
                filename = $"inputs/day{day}.txt";
            }

            return filename;
        }
    }
}
