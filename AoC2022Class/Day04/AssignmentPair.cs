namespace AoC2022Class.Day04
{
    public class AssignmentPair
    {
        public AssignmentPair(Section elfOneSection, Section elfTwoSection)
        {
            ElfOneSection = elfOneSection;
            ElfTwoSection = elfTwoSection;
        }

        public AssignmentPair(string pairstring)
        {
            var sections = pairstring.Split(',');
            ElfOneSection = new Section(sections[0]);
            ElfTwoSection = new Section(sections[1]);
        }

        public bool IsFullyOverlap() => (ElfOneSection.LowerBound >= ElfTwoSection.LowerBound
                && ElfOneSection.UpperBound <= ElfTwoSection.UpperBound)
                || (ElfOneSection.LowerBound <= ElfTwoSection.LowerBound
                && ElfOneSection.UpperBound >= ElfTwoSection.UpperBound);

        public bool IsNotOverlap() => (ElfOneSection.UpperBound < ElfTwoSection.LowerBound)
                | (ElfOneSection.LowerBound > ElfTwoSection.UpperBound);

        public bool IsOverlap() => !IsNotOverlap();

        public override string ToString()
        {
            return $"{ElfOneSection},{ElfTwoSection}";
        }

        public Section ElfOneSection { get; set; }
        public Section ElfTwoSection { get; set; }
    }
}
