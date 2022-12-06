using System.Linq;

using LanguageExt;

namespace AoC2022.Day5
{
    public class Day5
    {
        // 1st get crates as list
        // 2nd parse instructions

        public static IEnumerable<List<(int Min, int Max)>> ParseInput(string[] input)
        {
            throw new NotImplementedException();
        }

        public static int Task1(IEnumerable<List<(int Min, int Max)>> sequence)
        {
            throw new NotImplementedException();
        }

        public static int Task2(IEnumerable<List<(int Min, int Max)>> sequence)
        {
            throw new NotImplementedException();
        }

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input4.txt");
            var data = ParseInput(input);

            var result1 = Task1(data);
            var result2 = Task2(data);

            Console.WriteLine($"Task 1 = {result1}");
            Console.WriteLine($"Task 2 = {result2}");
        }
    }
}

