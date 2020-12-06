using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day6 : ISolution
    {
        private const string FilePath = "../../../../../data/day6_data.txt";
        
        public async Task Solve()
        {
            var lines = FileOperations.FuseMultiLine(await FileOperations.ReadAllLines(FilePath));
            var ansPart1 = 0;
            var ansPart2 = 0;
            
            foreach (var line in lines)
            {
                var dict = new Dictionary<char, int>();

                foreach (var letter in line.Replace(" ", ""))
                {
                    if (!dict.ContainsKey(letter))
                    {
                        dict.Add(letter, 1);
                        continue;
                    }

                    dict[letter]++;
                }

                ansPart1 += dict.Count;
                
                var splitted = line.Split(' ');
                var item = splitted[0];

                if (splitted.Length == 1)
                {
                    ansPart2 += item.Length;
                    continue;

                }

                foreach (var l in item)
                {
                    int hitCount = 1;
                    for (int i = 1; i < splitted.Length; i++)
                    {
                        if (splitted[i].Contains(l))
                        {
                            hitCount++;
                        }
                    }

                    if (hitCount == splitted.Length)
                        ansPart2++;
                }

                
            }

            Console.WriteLine($"[DAY 6] Answer for part 1 is: {ansPart1}");
            Console.WriteLine($"[DAY 6] Answer for part 2 is: {ansPart2}");
        }
    }
}
