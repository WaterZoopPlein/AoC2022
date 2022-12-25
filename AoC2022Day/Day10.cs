using AoC2022Class.Day10;
using AoC2022Common;

namespace AoC2022Day
{
    public class Day10 : IDay
    {

        private List<string> inputList;
        private List<Command> convertedInputList;
        private Computer computer;
        private ComputerWithCrt computerWithCrt;

        public void Initialise()
        {
            inputList =
                ReadInput.ConvertInputTextToStringList(@"..\..\..\..\Inputs\Day10.txt", "\n");
            convertedInputList = 
                inputList.ConvertAll(x => new Command(x));

        }

        public void SolvePartOne()
        {
            computer = new Computer();
            foreach (var cmd in convertedInputList)
            {
                computer.ExecuteCommand(cmd);
            }

            Console.WriteLine(computer.SelectedSignalStrengthSum);
        }

        public void SolvePartTwo()
        {
            computerWithCrt = new ComputerWithCrt();
            foreach (var cmd in convertedInputList)
            {
                computerWithCrt.ExecuteCommand(cmd);
            }

            computerWithCrt.PrintCrtMonitor();
        }
    }
}
