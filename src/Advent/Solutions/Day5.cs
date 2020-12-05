using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day5 : ISolution
    {
        private const string FilePath = "../../../../../data/day5_data.txt";
        
        public async Task Solve()
        {
            var lines = await FileOperations.ReadAllLines(FilePath);
            
            var maxId = int.MinValue;
            var cnt = 0;
            var ids = new List<int>();
            foreach (var line in lines)
            {
                int f = 0;
                int b = 127;
                int l = 0;
                int r = 7;

                foreach (var letter in line)
                {
                    switch (letter)
                    {
                        case 'F':
                            b = f + (b - f) / 2;
                            break;
                        case 'B':
                            f = (f + b) / 2 + 1;
                            break;
                        case 'L':
                            r = l + (r - l) / 2;
                            break;
                        case 'R':
                            l = (l + r) / 2 + 1;
                            break;
                    }
                }

                var currentId = f * 8 + l;
                
                maxId = Math.Max(maxId, currentId);

                if ((cnt != 0 || cnt != lines.Length - 1))
                {   
                    ids.Add(currentId);
                }
                cnt++;
            }

            Console.WriteLine($"[DAY 5] Answer for part 1 is: {maxId}");
            ids.Sort();

            for (var i = 1; i < ids.Count; i++)
            {
                if (ids[i - 1] + 1 != ids[i])
                    Console.WriteLine($"[DAY 5] Answer for part 2 is: {ids[i] - 1}");
            }

        }
    }
}
