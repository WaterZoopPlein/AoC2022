namespace AoC2022Class.Day10
{
    public class Computer
    {
        public Computer()
        {
            X = 1;
            CycleNumber = 0;
        }

        public void ExecuteCommand(Command cmd)
        {
            switch (cmd.Type)
            {
                case CommandType.NOOP:
                    IncrementCycle();
                    break;
                case CommandType.ADDX:
                    IncrementCycle();
                    IncrementCycle();
                    X += cmd.Param;
                    break;
                default:
                    throw new ArgumentException("Invalid Command");
            }
        }

        public virtual void IncrementCycle()
        {
            CycleNumber += 1;
            onIncrementCycle();
        }

        private void onIncrementCycle()
        {
            if (CycleNumber % 40 == 20)
            {
                Console.WriteLine($"Cycle {CycleNumber} - X {X} - Strength {CycleNumber * X}");
                SelectedSignalStrengthSum += CycleNumber * X;
            }

        }


        public int X;
        public int CycleNumber;
        public int SelectedSignalStrengthSum;
    }
}
