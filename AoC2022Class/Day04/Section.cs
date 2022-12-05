namespace AoC2022Class.Day04
{
    public class Section
    {
        public Section(string stringSection)
        {
            var boundArray = stringSection.Split('-');
            LowerBound = int.Parse(boundArray[0]);
            UpperBound = int.Parse(boundArray[1]);
        }

        public Section(int lowerBound, int upperBound)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

        public override string ToString()
        {
            return $"{LowerBound}-{UpperBound}";
        }

        public int LowerBound { get; set; }

        public int UpperBound { get; set; }
    }
}
