using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day7 : ISolution
    {
        private const string FilePath = "../../../../../data/day7_data.txt";
        private int _ansPart1;
        private int _ansPart2;
        private readonly HashSet<string> _bags = new();
        
        public async Task Solve()
        {
            var lines =  await FileOperations.ReadAllLines(FilePath);

            CountBagsContaingBagName("shiny gold", lines);
            CountContentsOfBag("shiny gold", lines, 1, 1);
            
            Console.WriteLine($"[DAY 7] Answer for part 1 is: {_ansPart1}");
            Console.WriteLine($"[DAY 7] Answer for part 2 is: {_ansPart2}");
        }

        private void CountBagsContaingBagName(string bagName, string[] lines)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split("contain");
                if (!line[1].Contains(bagName)) 
                    continue;

                var bag = line[0].Split(" ");
                var bagColor = bag[0] + " " + bag[1];
                if (!_bags.Contains(bagColor))
                {
                    _bags.Add(bagColor);
                    _ansPart1++;
                }
                
                var text = lines[i].Split(" ");
                var bagToCheck = text[0] + " " + text[1];
                
                CountBagsContaingBagName(bagToCheck, lines);
            }
        }
        
        private void CountContentsOfBag(string bagName, string[] lines, int bagCount, int lastLevel)
        {
            for (int i = 0; i < lines.Length; i++)
            {
                var line = lines[i].Split("contain");
                if (!line[0].Contains(bagName)) 
                    continue;

                if (line[1].Contains(" no other bags."))
                    return;
                
                var bagArray = line[1].Replace("contain", "").Split(",");
                int currentAns = 0;
                foreach (var bag in bagArray)
                {
                    var currentBagCount = int.Parse(bag.Trim().Split(' ')[0]);
                    var newBagName = bag.Replace(currentBagCount.ToString(), "").Trim('.').Trim();
                    var sta = lastLevel;
                    lastLevel *= currentBagCount;
                    CountContentsOfBag(newBagName, lines, currentBagCount, lastLevel);
                    currentAns += lastLevel;
                    lastLevel = sta;
                }

                _ansPart2 += currentAns;
            }
        }
    }
}
