using AoC2022Common;

namespace AoC2022Day
{
    public class Day01 : IDay
    {
        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day01.txt", "\n\n");

        private static readonly List<List<int>> ConvertedInputList
            = InputList.ConvertAll(x => x.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());

        public void SolvePartOne()
        {
            int currentMaxIndex = 0;
            int currentMax = 0;
            for (int currentELfIndex = 0; currentELfIndex < ConvertedInputList.Count; currentELfIndex++)
            {
                var currentElfTotal = ConvertedInputList[currentELfIndex].Sum();
                if (currentElfTotal > currentMax)
                {
                    currentMax = currentElfTotal;
                    currentMaxIndex = currentELfIndex;
                }
            }
            Console.WriteLine($"Elf {currentMaxIndex} carrying {currentMax} cal.");
        }

        public void SolvePartTwo()
        {
            const int TOP = 3;
            var currentMaxIndex = new int[TOP];
            var currentMax = new int[TOP];

            for (int currentElfIndex = 0; currentElfIndex < ConvertedInputList.Count; currentElfIndex++)
            {
                var currentElfTotal = ConvertedInputList[currentElfIndex].Sum();

                var maxInsertionIndex = 0;
                while (maxInsertionIndex < TOP && currentElfTotal < currentMax[maxInsertionIndex])
                {
                    maxInsertionIndex += 1;
                }

                if (maxInsertionIndex < TOP)
                {
                    for (int i = TOP - 1; i > maxInsertionIndex; i--)
                    {
                        currentMax[i] = currentMax[i - 1];
                        currentMaxIndex[i] = currentMaxIndex[i - 1];
                    }
                    currentMax[maxInsertionIndex] = currentElfTotal;
                    currentMaxIndex[maxInsertionIndex] = currentElfIndex;
                }
            }

            Console.WriteLine($"Top {TOP} elves");
            int totalTop = 0;
            for (int i = 0; i < TOP; i++)
            {
                Console.WriteLine($"Number {i + 1} - Elf {currentMaxIndex[i]} carrying {currentMax[i]} cal.");
                totalTop += currentMax[i];
            }
            Console.WriteLine($"Total Top {TOP} = {totalTop}");
        }
    }
}
