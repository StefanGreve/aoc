using LanguageExt;

namespace AoC2022.Day4
{
    public class Day4
    {
        public static (int Min, int Max) ConvertBoundaries(string section)
        {
            var bound = section.Split('-').Map(int.Parse).ToList();
            return (bound[0], bound[1]);
        }

        public static IEnumerable<List<(int Min, int Max)>> ParseInput(string[] input)
        {
            return input
                .Map(x => x.Split(','))
                .Map(x => x.Map(ConvertBoundaries).ToList());
        }

        public static int Task1(IEnumerable<List<(int Min, int Max)>> sequence)
        {
            return sequence
                .Where(x => ((x[0].Min <= x[1].Min && x[1].Max <= x[0].Max ) || x[1].Min <= x[0].Min && x[0].Max <= x[1].Max))
                .Count();
        }

        public static int Task2(IEnumerable<List<(int Min, int Max)>> sequence)
        {
            return sequence
                .Where(x => (x[1].Min <= x[0].Min && x[0].Min <= x[1].Max) || (x[1].Max <= x[0].Min && x[0].Max <= x[1].Max) || x[0].Min <= x[1].Min && x[1].Min <= x[0].Max || (x[0].Max <= x[1].Min && x[1].Max <= x[0].Max))
                .Count();
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

