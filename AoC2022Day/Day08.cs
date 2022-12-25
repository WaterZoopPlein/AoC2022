using AoC2022Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC2022Day
{
    public class Day08 : IDay
    {
        private List<string> inputList;

        private int[,] visibleGrid;

        private int[,] convertedInputList;

        private int[,] scenicGrid;


        public void Initialise()
        {
            inputList =
                ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day08.txt", "\n");

            convertedInputList = ReadInput.ConvertInputStringListTo2DArray(inputList);

            visibleGrid = new int[convertedInputList.GetLength(0), convertedInputList.GetLength(1)];

            scenicGrid = new int[convertedInputList.GetLength(0), convertedInputList.GetLength(1)];
        }

        public void SolvePartOne()
        {
            for (int i = 0; i < visibleGrid.GetLength(0); i++)
            {
                var currentRowMaxFromLeft = -1;
                for (int j = 0; j < visibleGrid.GetLength(1); j++)
                {
                    if (convertedInputList[i, j] > currentRowMaxFromLeft)
                    {
                        currentRowMaxFromLeft = convertedInputList[i, j];
                        visibleGrid[i, j] |= 0b1000;
                    }
                }
            }

            for (int i = 0; i < visibleGrid.GetLength(0); i++)
            {
                var currentRowMaxFromRight = -1;
                for (int j = visibleGrid.GetLength(1) - 1; j >= 0; j--)
                {
                    if (convertedInputList[i, j] > currentRowMaxFromRight)
                    {
                        currentRowMaxFromRight = convertedInputList[i, j];
                        visibleGrid[i, j] |= 0b0100;
                    }
                }
            }

            for (int i = 0; i < visibleGrid.GetLength(0); i++)
            {
                var currentColMaxFromTop = -1;
                for (int j = 0; j < visibleGrid.GetLength(1); j++)
                {
                    if (convertedInputList[j, i] > currentColMaxFromTop)
                    {
                        currentColMaxFromTop = convertedInputList[j, i];
                        visibleGrid[j, i] |= 0b0010;
                    }
                }
            }

            for (int i = 0; i < visibleGrid.GetLength(0); i++)
            {
                var currentColMaxFromBottom = -1;
                for (int j = visibleGrid.GetLength(1) - 1; j >= 0; j--)
                {
                    if (convertedInputList[j, i] > currentColMaxFromBottom)
                    {
                        currentColMaxFromBottom = convertedInputList[j, i];
                        visibleGrid[j, i] |= 0b0001;
                    }
                }
            }

            var visibleTreeCounts = 0;
            foreach (var item in visibleGrid)
            {
                if (item != 0)
                {
                    visibleTreeCounts += 1;
                }
            }

            Console.WriteLine($"{visibleTreeCounts} visible trees.");
        }

        public void SolvePartTwo()
        {
            int currentMaxScenic = 0;
            int currentMaxScenicRow = 0;
            int currentMaxScenicCol = 0;

            for (int i = 1; i < scenicGrid.GetLength(0) - 1; i++)
            {
                for (int j = 1; j < scenicGrid.GetLength(1) - 1; j++)
                {
                    // Look left
                    int leftIndex = 0;
                    do
                    {
                        leftIndex++;
                    } while (j - leftIndex - 1 >= 0
                    && convertedInputList[i, j] > convertedInputList[i, j - leftIndex]);

                    // Look right
                    int rightIndex = 0;
                    do
                    {
                        rightIndex++;
                    } while (j + rightIndex + 1 < scenicGrid.GetLength(1)
                    && convertedInputList[i, j] > convertedInputList[i, j + rightIndex]);

                    // Look up
                    int upIndex = 0;
                    do
                    {
                        upIndex++;
                    } while (i - upIndex - 1 >= 0
                    && convertedInputList[i, j] > convertedInputList[i - upIndex, j]);

                    // Look down
                    int downIndex = 0;
                    do
                    {
                        downIndex++;
                    } while (i + downIndex + 1 < scenicGrid.GetLength(0)
                    && convertedInputList[i, j] > convertedInputList[i + downIndex, j]);

                    scenicGrid[i, j] += leftIndex * rightIndex * upIndex * downIndex;
                    if (scenicGrid[i, j] > currentMaxScenic)
                    {
                        currentMaxScenic = scenicGrid[i, j];
                        currentMaxScenicCol = j;
                        currentMaxScenicRow = i;
                    }
                }
            }

            Console.WriteLine($"Max scenic achieved at " +
                $"row {currentMaxScenicRow} col {currentMaxScenicCol}, " +
                $"score {currentMaxScenic}");
        }
    }
}