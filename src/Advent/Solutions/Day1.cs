using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day1 : ISolution
    {
        private const string FilePath = "../../../../../data/day1_data.txt";

        public async Task Solve()
        {
            var input = TransformInput(await FileOperations.ReadAllLines(FilePath));

            for (int i = 0; i < input.Count; i++)
            {
                for (int j = i + 1; j < input.Count; j++)
                {
                    if (input[i] + input[j] == 2020)
                        Console.WriteLine($"[DAY 1] Answer for part 1 is: {input[i] * input[j]}");

                    for (int k = j + 1; k < input.Count; k++)
                    {
                        if (input[i] + input[j] + input[k] == 2020)
                            Console.WriteLine($"[DAY 1] Answer for part 2 is: {input[i] * input[j] * input[k]}");
                    }
                }
            }
        }

        private IList<int> TransformInput(string[] lines)
        {
            List<int> ans = new();

            foreach (var line in lines)
            {
                if(!int.TryParse(line, out var item))
                    break;
                
                ans.Add(item);
            }

            return ans;
        }
    }
}
