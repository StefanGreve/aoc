using LanguageExt;

using static LanguageExt.Prelude;

namespace AoC2022.Day3
{
    public class Day3
    {
        public static int ConvertToAscii(char c) => c - (char.IsUpper(c) ? 38 : 96);

        public static IEnumerable<(string Left, string Right)> ParseInput(string[] input)
        {
            return input.Map(x => (Left: x[..(x.Length / 2)], Right: x[(x.Length / 2)..]));
        }

        public static int Task1(IEnumerable<(string Left, string Right)> sequence)
        {
            return sequence
                .Map(x => x.Left.Intersect(x.Right))
                .Flatten()
                .Map(ConvertToAscii)
                .Sum();
        }

        public static int Task2(string[] input)
        {
            return input
                .Chunk(3)
                .Map(x => x[0].Intersect(x[1]).Intersect(x[2]))
                .Flatten()
                .Map(ConvertToAscii)
                .Sum();
        }

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input3.txt");
            var data = ParseInput(input);

            var result1 = Task1(data);
            var result2 = Task2(input);

            Console.WriteLine($"Task 1 = {result1}");
            Console.WriteLine($"Task 2 = {result2}");
        }
    }
}

