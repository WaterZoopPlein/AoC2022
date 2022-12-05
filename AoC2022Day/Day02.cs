using AoC2022Class.Day02;
using AoC2022Common;

namespace AoC2022Day
{
    public class Day02 : IDay
    {
        private static List<string> inputList;

        private bool isInitialised;

        public void Initialise()
        {
            inputList =
                ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day02.txt", "\n");
            isInitialised = true;
        }

        public void SolvePartOne()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }
            List<RpsRound> convertedInputList = inputList.ConvertAll(x => new RpsRound(x));
            var totalScore = 0;
            for (int i = 0; i < convertedInputList.Count; i++)
            {
                totalScore += convertedInputList[i].EvaluateMyScore();
            }
            Console.WriteLine(totalScore);
        }

        public void SolvePartTwo()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }
            List<RpsRound> convertedInputList = inputList.ConvertAll(x => new RpsRound(x, mode: 2));
            var totalScore = 0;
            for (int i = 0; i < convertedInputList.Count; i++)
            {
                totalScore += convertedInputList[i].EvaluateMyScore();
            }
            Console.WriteLine(totalScore);
        }
    }
}
