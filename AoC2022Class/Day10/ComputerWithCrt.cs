namespace AoC2022Class.Day10
{
    public class ComputerWithCrt : Computer
    {
        public ComputerWithCrt() : base()
        {
            CrtMonitor = new char[6, 40];
        }

        public override void IncrementCycle()
        {
            CycleNumber += 1;
            var rowNumber = (CycleNumber - 1) / 40;
            var columnNumber = (CycleNumber - 1) % 40;

            if (columnNumber >= X - 1 && columnNumber <= X + 1)
            {
                CrtMonitor[rowNumber, columnNumber] = '#';
            }
            else
            {
                CrtMonitor[rowNumber, columnNumber] = '.';
            }
        }

        public void PrintCrtMonitor()
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 40; j++)
                {
                    Console.Write(CrtMonitor[i,j]);
                }
                Console.WriteLine();
            }
        }

        public char[,] CrtMonitor;
    }
}
