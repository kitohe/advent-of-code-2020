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
                new Day1()
            };

            foreach (var task in tasks)
            {
                await task.Solve();
            }
        }
    }
}
