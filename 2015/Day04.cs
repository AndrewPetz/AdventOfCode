using System.Security.Cryptography;
using System.Text;
using Utils;

namespace _2015
{
    public class Day04
    {
        public static async Task<long> Part1()
        {
            var input = await Files.ReadFileAsync(4);
            long addon = 0;
            var hash = "11111111111";
            while (hash[..5] != "00000")
            {
                addon++;
                var testNumber = input + addon;
                hash = ComputeMd5Hash(testNumber);
            }

            return addon;
        }

        public static async Task<long> Part2()
        {
            var input = await Files.ReadFileAsync(4);
            long addon = 0;
            var hash = "11111111111";
            while (hash[..6] != "000000")
            {
                addon++;
                var testNumber = input + addon;
                hash = ComputeMd5Hash(testNumber);
            }

            return addon;
        }

        public static string ComputeMd5Hash(string message)
        {
            using var md5 = MD5.Create();
            var input = Encoding.ASCII.GetBytes(message);
            var hash = md5.ComputeHash(input);

            var sb = new StringBuilder();
            foreach (var h in hash)
            {
                sb.Append(h.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
