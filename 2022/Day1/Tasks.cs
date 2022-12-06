using LanguageExt;

namespace AoC2022.Day1
{
    public class Day1
    {
        public static List<List<int>> ParseInput(string[] input)
        {
            var elf = new List<int>();
            var calories = new List<List<int>>();

            foreach (string calory in input)
            {
                if (string.IsNullOrEmpty(calory))
                {
                    calories.Add(elf);
                    elf = new();
                }
                else
                {
                    elf.Add(int.Parse(calory));
                }
            }

            return calories;
        }

        public static int Task1(List<List<int>> sequence)
        {
            return sequence
                .Map(x => x.Sum())
                .Max();
        }

        public static int Task2(List<List<int>> sequence)
        {
            return sequence
                .Map(x => x.Sum())
                .OrderByDescending(x => x)
                .Take(3)
                .Sum();
        }

        public static void Main(string[] args)
        {
            var input = File.ReadAllText("input1.txt").Split(Environment.NewLine, StringSplitOptions.None);
            var data = ParseInput(input);

            int result1 = Task1(data);
            int result2 = Task2(data);

            Console.WriteLine($"Task 1 = {result1}");
            Console.WriteLine($"Task 2 = {result2}");
        }
    }
}

