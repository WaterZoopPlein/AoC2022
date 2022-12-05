using AoC2022Class.Day04;
using AoC2022Common;

namespace AoC2022Day
{
    public class Day04 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day04.txt", "\n");

        private static readonly List<AssignmentPair> ConvertedInputList = 
            InputList.ConvertAll(x => new AssignmentPair(x));


        public void SolvePartOne()
        {
            int fullyOverlapCount = 0;
            for (int i = 0; i < ConvertedInputList.Count; i++)
            {
                if (ConvertedInputList[i].IsFullyOverlap())
                {
                    fullyOverlapCount++;
                }
            }
            Console.WriteLine(fullyOverlapCount);
        }

        public void SolvePartTwo()
        {
            int overlapCount = 0;
            for (int i = 0; i < ConvertedInputList.Count; i++)
            {
                if (ConvertedInputList[i].IsOverlap())
                {
                    overlapCount++;
                }
            }
            Console.WriteLine(overlapCount);
        }
    }
}
