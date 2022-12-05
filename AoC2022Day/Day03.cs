using AoC2022Common;

namespace AoC2022Day
{
    public class Day03 : IDay
    {
        private static readonly List<string> RucksacksList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day03.txt", "\n");

        public void SolvePartOne()
        {
            int matchItemSum = 0;
            for (int i = 0; i < RucksacksList.Count; i++)
            {
                string currentRucksack = RucksacksList[i];
                int compartmentDivide = currentRucksack.Length / 2;

                var firstCompartment = currentRucksack.Substring(0, compartmentDivide);
                var secondCompartment = currentRucksack.Substring(compartmentDivide);

                char matchItem = findFirstMatchingItem(firstCompartment, secondCompartment);

                int matchItemNumber = getItemNumber(matchItem);

                if (matchItemNumber == -1)
                {
                    Console.WriteLine($"Found no match item at rucksack {i}.");
                }
                matchItemSum += matchItemNumber;

            }
            Console.WriteLine(matchItemSum);
        }

        public void SolvePartTwo()
        {
            int matchItemSum = 0;
            for (int i = 0; i < RucksacksList.Count - 2; i+=3)
            {
                char matchItem = findFirstMatchingItem(
                    RucksacksList[i], RucksacksList[i+1], RucksacksList[i+2]);

                int matchItemNumber = getItemNumber(matchItem);

                if (matchItemNumber == -1)
                {
                    Console.WriteLine($"Found no match item between rucksack {i}, {i+1}, and {i+2}.");
                }
                matchItemSum += matchItemNumber;

            }
            Console.WriteLine(matchItemSum);
        }

        private char findFirstMatchingItem(string firstCompartment, string secondCompartment)
        {
            char matchItem = ' ';
            foreach (var item1 in firstCompartment)
            {
                bool foundMatch = false;
                foreach (var item2 in secondCompartment)
                {
                    if (item1 == item2)
                    {
                        matchItem = item1;
                        foundMatch = true;
                        break;
                    }
                }

                if (foundMatch) break;
            }

            return matchItem;
        }

        private string findAllMatchingItems(string firstCompartment, string secondCompartment)
        {
            string matchItems = String.Empty;
            foreach (var item1 in firstCompartment)
            {
                foreach (var item2 in secondCompartment)
                {
                    if (!matchItems.Contains(item1) && item1 == item2)
                    {
                        matchItems += item1;
                        break;
                    }
                }
            }

            return matchItems;
        }


        private char findFirstMatchingItem(string rucksack1, string rucksack2, string rucksack3)
        {

            string firstTwoRucksacksMatchItems = findAllMatchingItems(rucksack1, rucksack2);
            char matchItem = findFirstMatchingItem(firstTwoRucksacksMatchItems, rucksack3);

            return matchItem;
        }


        private int getItemNumber(char itemChar)
        {
            int matchItemNumber;
            if (char.IsUpper(itemChar))
            {
                matchItemNumber = itemChar - 38;
            }
            else if (char.IsLower(itemChar))
            {
                matchItemNumber = itemChar - 96;
            }
            else
            {
                matchItemNumber = -1;
            }
            return matchItemNumber;
        }
    }
}
