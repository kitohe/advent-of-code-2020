using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day10 : ISolution
    {
        private const string FilePath = "../../../../../data/day10_data.txt";

        public async Task Solve()
        {
            var lines = await FileOperations.ReadAllLines(FilePath);
            var ints = lines.Select(int.Parse).ToList();
            ints.Sort();

            var oneDiff = 0;
            var threeDiff = 0;

            if (ints[0] == 1)
                oneDiff++;
            else
                threeDiff++;

            for (int i = 1; i < ints.Count; i++)
            {
                if (ints[i - 1] == ints[i] - 1)
                    oneDiff++;
                else if (ints[i - 1] == ints[i] - 3)
                    threeDiff++;
            }

            threeDiff++;

            Console.WriteLine($"[DAY 10] Answer for part 1 is: {oneDiff * threeDiff}");
            Console.WriteLine($"[DAY 10] Answer for part 2 is: {Part2(ints)}");
        }

        // Credit:
        // https://github.com/FrankBakkerNl/AdventOfCode2020/blob/master/AdventOfCode2020/Puzzles/Day10.cs
        private long Part2(List<int> ints)
        {
            var inputSet = ints.Append(0).ToHashSet();

            var pathCounts = new long[ints.Count * 3 + 4];
            pathCounts[0] = 1;

            var skipped = 0;

            for (var i = 0;; i++)
            {
                if (!inputSet.Contains(i))
                {
                    if (++skipped == 3)
                        return pathCounts[i - skipped]; // If we skipped 3 times in a row we are passed the end
                    continue;
                }

                var paths = pathCounts[i];
                pathCounts[i + 1] += paths;
                pathCounts[i + 2] += paths;
                pathCounts[i + 3] += paths;

                skipped = 0;
            }
        }
    }
}
