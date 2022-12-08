using LanguageExt;

namespace AoC2022.Day6
{
    public class Day6
    {
        public static int Task1(char[] input, int size = 4)
        {
            for (int i = 0; i < input.Length - size - 1; i++)
            {
                var window = input.Skip(i).Take(size);

                if (window.Duplicates().Any()) continue;

                return i + size;
            }

            return -1;
        }

        public static int Task2(char[] input) => Task1(input, 14);

        public static void Main(string[] args)
        {
            var input = File.ReadAllText("input6.txt").ToCharArray();

            var result1 = Task1(input);
            var result2 = Task2(input);

            Console.WriteLine($"Task 1 = {result1}");
            Console.WriteLine($"Task 2 = {result2}");
        }
    }
}

