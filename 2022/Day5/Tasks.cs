using LanguageExt;

namespace AoC2022.Day5
{
    public record Move
    {
        public int Amount { get; set; }

        public int From { get; set; }

        public int To { get; set; }
    }

    public class Day5
    {
        public static List<List<char>> ParseCrates(string[] input)
        {
            return input
                .TakeWhile(s => s.Contains("["))
                .Map(s => s.ToCharArray())
                .Transpose()
                .Filter(x => x.Any(char.IsLetter))
                .Map(x => x.Filter(y => !char.IsWhiteSpace(y)).Reverse().ToList())
                .ToList();
        }

        public static IEnumerable<Move> ParseMoves(string[] input)
        {
            return input
                .SkipWhile(x => !x.StartsWith("move"))
                .Map(x => x.Split(" ").Filter(y => y.All(char.IsDigit)))
                .Map(x => x.Map(Convert.ToInt32).ToList())
                .Select(x => new Move { Amount = x[0], From = x[1] - 1, To = x[2] - 1 });
        }

        public static string Task1(string[] input, int crateMover)
        {
            var crates = ParseCrates(input);
            var moves = ParseMoves(input);

            foreach (var move in moves)
            {
                var tmp = crates[move.From].Pop(move.Amount);
                crates[move.To].Push(crateMover == 9000 ? tmp : tmp.Reverse());
            }

            return string.Join(string.Empty, crates.Map(x => x.Last()));
        }

        public static string Task2(string[] input)
        {
            return Task1(input, 9001);
        }

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input5.txt");

            var result1 = Task1(input, crateMover: 9000);
            var result2 = Task2(input);

            Console.WriteLine($"Task 1 = {result1}");
            Console.WriteLine($"Task 2 = {result2}");
        }
    }
}

