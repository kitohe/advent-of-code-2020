using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day9 : ISolution
    {
        private const string FilePath = "../../../../../data/day9_data.txt";
        
        public async Task Solve()
        {
            var strings = await FileOperations.ReadAllLines(FilePath);
            var lines = strings.Select(long.Parse).ToList();

            long ans = 0;
            var preambleLength = 25;

            for (int i = preambleLength; i < lines.Count; i++)
            {
                bool flag = false;
                
                for (int j = i - preambleLength; j < i; j++)
                {
                    for (int k = j + 1; k < preambleLength + j - 1; k++)
                    {
                        if (k >= lines.Count)
                            break;
                        
                        if (lines[j] + lines[k] == lines[i])
                        {
                            flag = true;
                            break;
                        }
                    }
                }

                if (!flag)
                {
                    ans = Math.Max(ans, lines[i]);
                }
                
            }

            Console.WriteLine($"[DAY 9] Answer for part 1 is: {ans}");
            Crack(lines, ans);
        }

        private void Crack(IList<long> lines, long key)
        { 
            List<long> numsChecked = new();
            int stride = 1;

            while (true)
            {
                for (int startPoint = 0; startPoint < lines.Count; startPoint++)
                {
                    long currentSum = 0;
                    for (int i = startPoint; i < stride && i < lines.Count; i++)
                    {
                        currentSum += lines[i];
                        numsChecked.Add(lines[i]);
                    }

                    if (currentSum == key && numsChecked.Count != 1)
                    {
                        Console.WriteLine($"[DAY 9] Answer for part 2 is: {numsChecked.Max() + numsChecked.Min()}");
                        return;
                    }
                    
                    numsChecked.Clear();
                }
                
                stride++;
                
            }
        }
    }
}
