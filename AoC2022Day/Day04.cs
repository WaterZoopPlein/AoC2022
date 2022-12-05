using AoC2022Class.Day04;
using AoC2022Common;

namespace AoC2022Day
{
    public class Day04 : IDay
    {
        private static List<string> inputList;

        private static List<AssignmentPair> convertedInputList;

        private bool isInitialised;

        public void Initialise()
        {
            inputList =
                ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day04.txt", "\n");
            convertedInputList =
                inputList.ConvertAll(x => new AssignmentPair(x));
            isInitialised = true;
        }

        public void SolvePartOne()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            int fullyOverlapCount = 0;
            for (int i = 0; i < convertedInputList.Count; i++)
            {
                if (convertedInputList[i].IsFullyOverlap())
                {
                    fullyOverlapCount++;
                }
            }
            Console.WriteLine(fullyOverlapCount);
        }

        public void SolvePartTwo()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            int overlapCount = 0;
            for (int i = 0; i < convertedInputList.Count; i++)
            {
                if (convertedInputList[i].IsOverlap())
                {
                    overlapCount++;
                }
            }
            Console.WriteLine(overlapCount);
        }
    }
}
