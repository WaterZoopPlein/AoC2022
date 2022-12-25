namespace AoC2022Class.Day10
{
    public class Command
    {
        public Command(string cmdString)
        {
            var cmdList = cmdString.Split(' ');
            switch (cmdList[0])
            {
                case "noop":
                    Type = CommandType.NOOP;
                    break;
                case "addx":
                    Type = CommandType.ADDX;
                    Param = int.Parse(cmdList[1]);
                    break;
                default:
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Type} {Param}";
        }

        public CommandType Type;
        public int Param;
    }
}
