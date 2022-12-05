using AoC2022Class.Day02;
using AoC2022Common;

namespace AoC2022Day
{
    public class Day02 : IDay
    {
        private static readonly List<string> InputList =
    ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day02.txt", "\n");


        public void SolvePartOne()
        {
            List<RpsRound> convertedInputList = InputList.ConvertAll(x => new RpsRound(x));
            var totalScore = 0;
            for (int i = 0; i < convertedInputList.Count; i++)
            {
                totalScore += convertedInputList[i].EvaluateMyScore();
            }
            Console.WriteLine(totalScore);
        }

        public void SolvePartTwo()
        {
            List<RpsRound> convertedInputList = InputList.ConvertAll(x => new RpsRound(x, mode: 2));
            var totalScore = 0;
            for (int i = 0; i < convertedInputList.Count; i++)
            {
                totalScore += convertedInputList[i].EvaluateMyScore();
            }
            Console.WriteLine(totalScore);
        }
    }
}
