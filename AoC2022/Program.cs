using AoC2022Day;
using System.Diagnostics;

namespace AoC2022
{
    public class Program
    {
        public static void Main()
        {
            var day = new Day06(); // Replace date number here

            Solve(day);
        }

        private static void Solve(IDay day)
        {
            Console.WriteLine("Initialise");
            var watchInnit = Stopwatch.StartNew();
            day.Initialise();
            watchInnit.Stop();

            Console.WriteLine("Part 1");
            var watch1 = Stopwatch.StartNew();
            day.SolvePartOne();
            watch1.Stop();

            Console.WriteLine("Part 2");
            var watch2 = Stopwatch.StartNew();
            day.SolvePartTwo();
            watch2.Stop();

            Console.WriteLine($"Innit took {watchInnit.Elapsed}");
            Console.WriteLine($"Part One took {watch1.Elapsed}");
            Console.WriteLine($"Part Two took {watch2.Elapsed}");

            Console.ReadLine();
        }
    }
}