using System.Collections.Generic;
using System.Threading.Tasks;
using Advent.Solutions;

namespace Advent
{
    class Program
    {
        static async Task Main(string[] args)
        {
            List<ISolution> tasks = new()
            {
                new Day1(),
                new Day2(),
                new Day3(),
                new Day4(),
                new Day5(),
                new Day6(),
                new Day7(),
                new Day8()
            };

            foreach (var task in tasks)
            {
                await task.Solve();
            }
        }
    }
}
