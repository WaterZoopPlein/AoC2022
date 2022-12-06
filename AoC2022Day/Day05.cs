using AoC2022Common;

namespace AoC2022Day
{
    public class Day05 : IDay
    {
        private List<string> inputList;

        private Stack<char>[] cargoStacks;

        private string[] movesArr;

        private bool isInitialised;

        public void Initialise()
        {
            inputList =
                ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day05.txt", "\n\n");

            movesArr = inputList[1].Trim().Split('\n');

            isInitialised = true;
        }

        public void SolvePartOne()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            InitialiseCargoStacks();

            for (int i = 0; i < movesArr.Length; i++)
            {
                ExecuteMovePartOne(movesArr[i]);
            }

            foreach (var stack in cargoStacks)
            {
                Console.Write(stack.Peek());
            }
            Console.WriteLine();
        }

        public void SolvePartTwo()
        {
            if (!isInitialised)
            {
                throw new Exception("Obj not initialised");
            }

            InitialiseCargoStacks();

            for (int i = 0; i < movesArr.Length; i++)
            {
                ExecuteMovePartTwo(movesArr[i]);
            }

            foreach (var stack in cargoStacks)
            {
                Console.Write(stack.Peek());
            }
            Console.WriteLine();
        }

        private void InitialiseCargoStacks()
        {
            var containerString = inputList[0].Split('\n');
            int numberOfStacks = (containerString[containerString.Length - 1].Length + 1) / 4;

            cargoStacks = new Stack<char>[numberOfStacks];
            for (int i = 0; i < numberOfStacks; i++)
            {
                cargoStacks[i] = new Stack<char>();
            }

            for (int i = containerString.Length - 2; i >= 0; i--)
            {
                var cargoRow = containerString[i];
                var stackIndex = 0;
                for (int cargoIndex = 1; cargoIndex < cargoRow.Length; cargoIndex += 4)
                {
                    var cargo = cargoRow[cargoIndex];
                    if (!char.IsWhiteSpace(cargo))
                    {
                        cargoStacks[stackIndex].Push(cargo);
                    }
                    stackIndex++;
                }
            }
        }

        private void ExecuteMovePartOne(string move)
        {
            var splitMove = move.Split(' ');
            var fromStackIndex = int.Parse(splitMove[3]) - 1;
            var toStackIndex = int.Parse(splitMove[5]) - 1;
            var repeatTime = int.Parse(splitMove[1]);

            for (int i = 0; i < repeatTime; i++)
            {
                var cargoToBeMoved = cargoStacks[fromStackIndex].Pop();
                cargoStacks[toStackIndex].Push(cargoToBeMoved);
            }
        }

        private void ExecuteMovePartTwo(string move)
        {
            var splitMove = move.Split(' ');
            var fromStackIndex = int.Parse(splitMove[3]) - 1;
            var toStackIndex = int.Parse(splitMove[5]) - 1;
            var repeatTime = int.Parse(splitMove[1]);

            var tempStack = new Stack<char>();

            for (int i = 0; i < repeatTime; i++)
            {
                var cargoToBeMoved = cargoStacks[fromStackIndex].Pop();
                tempStack.Push(cargoToBeMoved);
            }

            while (tempStack.TryPop(out var cargo))
            {
                cargoStacks[toStackIndex].Push(cargo);
            }
        }

    }
}
