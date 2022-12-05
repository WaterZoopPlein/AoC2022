namespace AoC2022Class.Day02
{
    public class RpsRules
    {
        public static RpsOutcome EvalRound(RpsRound round) => EvalRound(round.OpponentMove, round.MyMove);

        private static RpsOutcome EvalRound(RpsMove opponent, RpsMove mine)
        {
            if (IsTieing(opponent, mine))
            {
                return RpsOutcome.Tie;
            }
            if (IsWinning(opponent, mine))
            {
                return RpsOutcome.Win;
            }
            if (IsLosing(opponent, mine))
            {
                return RpsOutcome.Lose;
            }

            return RpsOutcome.Invalid;
        }

        public static RpsMove FindWinningMove(RpsMove opponent)
        {
            switch (opponent)
            {
                case RpsMove.Rock:
                    return RpsMove.Paper;
                case RpsMove.Paper:
                    return RpsMove.Scissors;
                case RpsMove.Scissors:
                    return RpsMove.Rock;
                case RpsMove.Invalid:
                    return RpsMove.Invalid;
                default:
                    return RpsMove.Invalid;
            }
        }

        public static RpsMove FindLosingMove(RpsMove opponent)
        {
            switch (opponent)
            {
                case RpsMove.Rock:
                    return RpsMove.Scissors;
                case RpsMove.Paper:
                    return RpsMove.Rock;
                case RpsMove.Scissors:
                    return RpsMove.Paper;
                case RpsMove.Invalid:
                    return RpsMove.Invalid;
                default:
                    return RpsMove.Invalid;
            }
        }


        private static bool IsWinning(RpsMove opponent, RpsMove mine)
        {
            return (opponent == RpsMove.Rock & mine == RpsMove.Paper)
                || (opponent == RpsMove.Paper & mine == RpsMove.Scissors)
                || (opponent == RpsMove.Scissors & mine == RpsMove.Rock);
        }

        private static bool IsLosing(RpsMove opponent, RpsMove mine)
        {
            return (opponent == RpsMove.Rock & mine == RpsMove.Scissors)
                || (opponent == RpsMove.Paper & mine == RpsMove.Rock)
                || (opponent == RpsMove.Scissors & mine == RpsMove.Paper);
        }

        private static bool IsTieing(RpsMove opponent, RpsMove mine)
        {
            return opponent == mine;
        }

    }
}
