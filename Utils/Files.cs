using RestSharp;
using RestSharp.Serialization.Json;

namespace Utils
{
    public static class Files
    {
        private static readonly HttpClient _httpClient = new();

        /// <summary>
        /// Returns the input for the specified year and day as a string.
        /// Downloads the file if it doesn't already exist on disk.
        /// </summary>
        /// <param name="year">The year to get the input for.</param>
        /// <param name="day">The day to get the input for.</param>
        /// <returns>A string with the requested input.</returns>
        public static async Task<string> GetInput(int year, int day)
        {
            try
            {
                var uri = $"https://adventofcode.com/{year}/day/{day}";

                var client = new RestClient(uri);

                var request = new RestRequest("input")
                {
                    RequestFormat = DataFormat.None
                };

                client.AddHandler("text/plain", new JsonDeserializer());

                request.AddCookie("session", "53616c7465645f5fd2e7555fa016e68753524d04c23275c4816e70655aa980c10732b4ccdf2f1deab0e7888c312dc5ca");

                var response = await client.ExecuteAsync(request);

                string fileName = GetDayFilename(day);

                if (!File.Exists(fileName))
                {
                    byte[] fileBytes = response.RawBytes;
                    File.WriteAllBytes(fileName, fileBytes);
                }

                return await ReadFileAsync(day);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

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
            return lines.Select(x => int.Parse(x)).ToList();
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
