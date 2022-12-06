using AoC2022Common;
using System.IO;

namespace AoC2022Day
{
    public class Day06 : IDay
    {
        private string input;

        private bool isInitialised;

        public void Initialise()
        {
            var path = @"..\..\..\..\Inputs\Day06.txt";

            var sr = new StreamReader(path);

            input = sr.ReadToEnd();

            sr.Close();

            isInitialised = true;
        }

        public void SolvePartOne()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            findFirstMarker(4);
        }

        public void SolvePartTwo()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            findFirstMarker(14);
        }

        private int findFirstMarker(int sampleSize)
        {
            for (int i = 0; i < input.Length - sampleSize + 1; i++)
            {
                var sample = input.Substring(i, sampleSize);

                if (isAllCharUnique(sample))
                {
                    Console.WriteLine($"Sample {sample}. First marker at {i + sampleSize}");
                    return i;
                }
            }

            Console.WriteLine($"None found. Return -1.");
            return -1;
        }

        private bool isAllCharUnique(string str)
        {
            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i+1; j < str.Length; j++)
                {
                    if (str[i] == str[j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
