using AoC2022Common;

namespace AoC2022Day
{
    public class Day01 : IDay
    {
        private List<string> inputList;

        private List<List<int>> convertedInputList;

        private bool isInitialised;

        public void Initialise()
        {
            inputList = 
                ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day01.txt", "\n\n");
            convertedInputList = 
                inputList.ConvertAll(x => x.Split('\n', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList());
            isInitialised = true;
        }

        public void SolvePartOne()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            int currentMaxIndex = 0;
            int currentMax = 0;
            for (int currentElfIndex = 0; currentElfIndex < convertedInputList.Count; currentElfIndex++)
            {
                var currentElfTotal = convertedInputList[currentElfIndex].Sum();
                if (currentElfTotal > currentMax)
                {
                    currentMax = currentElfTotal;
                    currentMaxIndex = currentElfIndex;
                }
            }
            Console.WriteLine($"Elf {currentMaxIndex} carrying {currentMax} cal.");
        }

        public void SolvePartTwo()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            const int TOP = 3;
            var currentMaxIndex = new int[TOP];
            var currentMax = new int[TOP];

            for (int currentElfIndex = 0; currentElfIndex < convertedInputList.Count; currentElfIndex++)
            {
                var currentElfTotal = convertedInputList[currentElfIndex].Sum();

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
