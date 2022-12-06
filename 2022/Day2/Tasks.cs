using LanguageExt;

namespace AoC2022.Day2
{
    public class Day2
    {
        /// <summary>
        /// <para>Determines the outcome of a rock-paper-scissors game betwen two players.</para>
        /// 0 = Rock <br/>
        /// 1 = Paper <br/>
        /// 2 = Scissors
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <seealso cref="https://stackoverflow.com/a/7279123/10827244"/>
        /// <returns>1 if <c>player1</c> wins, 2 if <c>player2</c> loses, and 0 for a tie</returns>
        public static int RockPaperScissors(int player1, int player2) => (3 + player1 - player2) % 3;

        public static int DecodeColumn(string column)
        {
            return column switch
            {
                "A" or "X" => 1, // Rock
                "B" or "Y" => 2, // Paper
                "C" or "Z" => 3, // Scissors
            };
        }

        public static int ComputeScore(int player1, int player2)
        {
            int outcome = RockPaperScissors(player1 - 1, player2 - 1);

            int bonus = outcome switch
            {
                0 => 3, // tie
                1 => 0, // player 1 loses
                2 => 6, // player 2 wins
            };

            return player2 + bonus;
        }

        public static int ComputeScore2(int player1, int player2)
        {
            int newMove = player2 switch
            {
                1 => player1 > 1 ? player1 - 1 : 3, // player 1 loses
                2 => player1, // tie
                3 => player1 < 3 ? player1 + 1 : 1, // player 3 wins 
            };

            return ComputeScore(player1, newMove);
        }

        public static IEnumerable<(int Player1, int Player2)> ParseInput(string[] input)
        {
            return input
                .Map(x => x.Split(" "))
                .Select(x => (Player1: DecodeColumn(x[0]), Player2: DecodeColumn(x[1])));
        }

        public static int Task1(IEnumerable<(int Player1, int Player2)> sequence)
        {
            return sequence.Map(x => ComputeScore(x.Player1, x.Player2)).Sum();
        }

        public static int Task2(IEnumerable<(int Player1, int Player2)> sequence)
        {
            return sequence.Map(x => ComputeScore2(x.Player1, x.Player2)).Sum();
        }

        public static void Main(string[] args)
        {
            var input = File.ReadAllLines("input2.txt");
            var data = ParseInput(input);

            int result1 = Task1(data);
            int result2 = Task2(data);

            Console.WriteLine($"Task 1 = {result1}");
            Console.WriteLine($"Task 2 = {result2}");
        }
    }
}

