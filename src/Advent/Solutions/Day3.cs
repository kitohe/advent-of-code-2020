using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day3 : ISolution
    {
        private const string FilePath = "../../../../../data/day3_data.txt";

        public async Task Solve()
        {
            var lines = await FileOperations.ReadAllLines(FilePath);
            var array = PrepareArray(lines);

            long ansPart1;
            long ans = CheckSlope(array, 1, 1);
            ans *= ansPart1 = CheckSlope(array, 1, 3);
            ans *= CheckSlope(array, 1, 5);
            ans *= CheckSlope(array, 1, 7);
            ans *= CheckSlope(array, 2, 1);
            
            Console.WriteLine($"[DAY 3] Answer for part 1 is: {ansPart1}");
            Console.WriteLine($"[DAY 3] Answer for part 2 is: {ans}");
            
        }

        private List<List<char>> PrepareArray(string[] array)
        {
            List<List<char>> ans = new();

            for (int i = 0; i < array.Length; i++)
            {
                ans.Add(new());
                for (int j = 0; j < array[i].Length; j++)
                {
                    ans[i].Add(array[i][j]);
                }
            }

            return ans;
        }

        private int CheckSlope(List<List<char>> array, int down, int right)
        {
            int j = 0;
            int ans = 0;
            for (int i = 0; i < array.Count; i += down)
            {
                if (array[i][j] == '#')
                    ans++;

                j += right;
                if (j >= array[i].Count)
                    j %= array[i].Count;
            }

            return ans;
        }
    }
}
