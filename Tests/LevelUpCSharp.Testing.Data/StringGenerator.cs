using System;

namespace LevelUpCSharp.Testing.Data
{
	public class StringGenerator
    {
        private const int LettersAsciiOffset = 65;
        private static Lazy<StringGenerator> _instance = new Lazy<StringGenerator>(() => new StringGenerator());
        private readonly Random Rand = new Random((int)DateTime.Now.Ticks);

        public static StringGenerator Instance => _instance.Value;

        public string Nothing()
        {
            return (string)null;
        }

        public string Create(uint length = 1) 
        {
            string result = string.Empty;
            for (int i = 0; i < length; i++)
            {
                result += (char)(Rand.Next(25) + LettersAsciiOffset);
            }

            return result;
        }
    }
}
