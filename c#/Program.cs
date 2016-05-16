using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Test
{
    class Program
    {
        public const string PROVIDER = "@gmx.de";
        public const string PREFIX = "c0ffee";
        public const int LENGTH = 15;

        static void Main(string[] args)
        {
            TalentMatchChallenge();
        }

        private static void TalentMatchChallenge()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";
            var q = alphabet.Select(x => x.ToString());
            for (int i = 0; i < LENGTH - 1; i++)
                q = q.SelectMany(x => alphabet, (x, y) => x + y);

            string sha1Hash;
            foreach (var currentString in q)
            {
                sha1Hash = SHA1HashForString(currentString + PROVIDER);
                if (sha1Hash.StartsWith(PREFIX))
                    Console.WriteLine(currentString + PROVIDER + " : " + sha1Hash);
            }
        }

        private static string SHA1HashForString(string s)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(s);

            var sha1 = SHA1.Create();
            byte[] hashBytes = sha1.ComputeHash(bytes);

            return HexStringFromBytes(hashBytes);
        }

        private static string HexStringFromBytes(byte[] bytes)
        {
            var sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                var hex = b.ToString("x2");
                sb.Append(hex);
            }
            return sb.ToString();
        }
    }
}
