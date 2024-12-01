using Utils;

namespace _2024
{
    public class Day02
    {
        private const int rockScore = 1;
        private const int paperScore = 2;
        private const int scissorsScore = 3;

        private const int winScore = 6;
        private const int loseScore = 0;
        private const int drawScore = 3;
        public static async Task<int> Part1()
        {
            var lines = await Files.ReadLinesAsync(2);

            var score = 0;
            foreach (var line in lines)
            {
                var lineSplit = line.Split(' ');
                var opponent = lineSplit[0];
                var you = lineSplit[1];

                switch (you)
                {
                    case "X": // Rock
                        score += rockScore;
                        switch (opponent)
                        {
                            case "A": // Rock (tie)
                                score += drawScore;
                                break;
                            case "B": // Paper (loss)
                                score += loseScore;
                                break;
                            case "C": // Scissors (win)
                                score += winScore;
                                break;
                        }
                        break;
                    case "Y": // Paper
                        score += paperScore;
                        switch (opponent)
                        {
                            case "A": // Rock (win)
                                score += winScore;
                                break;
                            case "B": // Paper (tie)
                                score += drawScore;
                                break;
                            case "C": // Scissors (loss)
                                score += loseScore;
                                break;
                        }
                        break;
                    case "Z": // Scissors
                        score += scissorsScore;
                        switch (opponent)
                        {
                            case "A": // Rock (loss)
                                score += loseScore;
                                break;
                            case "B": // Paper (win)
                                score += winScore;
                                break;
                            case "C": // Scissors (tie)
                                score += drawScore;
                                break;
                        }
                        break;
                }
            }

            return score;
        }

        public static async Task<int> Part2()
        {
            var lines = await Files.ReadLinesAsync(2);

            var score = 0;
            foreach (var line in lines)
            {
                var lineSplit = line.Split(' ');
                var opponent = lineSplit[0];
                var you = lineSplit[1];

                switch (you)
                {
                    case "X": // Lose
                        score += loseScore;
                        switch (opponent)
                        {
                            case "A": // Rock (I play scissors)
                                score += scissorsScore;
                                break;
                            case "B": // Paper (I play rock)
                                score += rockScore;
                                break;
                            case "C": // Scissors (I play paper)
                                score += paperScore;
                                break;
                        }
                        break;
                    case "Y": // Draw
                        score += drawScore;
                        switch (opponent)
                        {
                            case "A": // Rock (I play rock)
                                score += rockScore;
                                break;
                            case "B": // Paper (I play paper)
                                score += paperScore;
                                break;
                            case "C": // Scissors (I play scissors)
                                score += scissorsScore;
                                break;
                        }
                        break;
                    case "Z": // Win
                        score += winScore; // 6 for win
                        switch (opponent)
                        {
                            case "A": // Rock (I play paper)
                                score += paperScore;
                                break;
                            case "B": // Paper (I play scissors)
                                score += scissorsScore;
                                break;
                            case "C": // Scissors (I play rock)
                                score += rockScore;
                                break;
                        }
                        break;
                }
            }

            return score;
        }
    }
}
