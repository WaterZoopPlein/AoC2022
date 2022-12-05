namespace AoC2022Class.Day02
{
    public class RpsRound
    {
        public RpsRound(string textMove, int mode = 1)
        {
            switch (textMove[0])
            {
                case 'A':
                    OpponentMove = RpsMove.Rock;
                    break;
                case 'B':
                    OpponentMove = RpsMove.Paper;
                    break;
                case 'C':
                    OpponentMove = RpsMove.Scissors;
                    break;
                default:
                    OpponentMove = RpsMove.Invalid;
                    break;
            }

            switch (mode)
            {
                case 1:
                    switch (textMove[2])
                    {
                        case 'X':
                            MyMove = RpsMove.Rock;
                            break;
                        case 'Y':
                            MyMove = RpsMove.Paper;
                            break;
                        case 'Z':
                            MyMove = RpsMove.Scissors;
                            break;
                        default:
                            MyMove = RpsMove.Invalid;
                            break;
                    }
                    break;
                case 2:
                    switch (textMove[2])
                    {
                        case 'X':
                            MyMove = RpsRules.FindLosingMove(OpponentMove);
                            break;
                        case 'Y':
                            MyMove = OpponentMove;
                            break;
                        case 'Z':
                            MyMove = RpsRules.FindWinningMove(OpponentMove);
                            break;
                        default:
                            MyMove = RpsMove.Invalid;
                            break;
                    }
                    break;
                default:
                    throw new ArgumentException("Invalid Part number. Part 1 or 2 only");
            }
        }

        public int EvaluateMyScore()
        {
            int score = 0;

            switch (MyMove)
            {
                case RpsMove.Rock:
                    score += 1;
                    break;
                case RpsMove.Paper:
                    score += 2;
                    break;
                case RpsMove.Scissors:
                    score += 3;
                    break;
                case RpsMove.Invalid:
                    Console.WriteLine("Invalid Move Found. No score");
                    break;
                default:
                    break;
            }

            var myOutcome = RpsRules.EvalRound(this);

            switch (myOutcome)
            {
                case RpsOutcome.Win:
                    score += 6;
                    break;
                case RpsOutcome.Lose:
                    score += 0;
                    break;
                case RpsOutcome.Tie:
                    score += 3;
                    break;
                case RpsOutcome.Invalid:
                    Console.WriteLine("Invalid Outcome Found. No score");
                    break;
                default:
                    break;
            }

            return score;
        }

        public override string ToString()
        {
            return $"Opponent: {OpponentMove} - Mine: {MyMove}";
        }

        public RpsMove OpponentMove { get; set; }

        public RpsMove MyMove { get; set; }

        public RpsOutcome MyOutcome { get; set; }

    }
}