using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day4 : ISolution
    {
        private const string FilePath = "../../../../../data/day4_data.txt";

        public async Task Solve()
        {
            var lines = FuseMultiLine(await FileOperations.ReadAllLines(FilePath));

            var ansPart1 = 0;
            var ansPart2 = 0;
            var required = new List<string> {"byr", "iyr", "eyr", "hgt", "hcl", "ecl", "pid"};

            foreach (var line in lines)
            {
                var splitted = line.Split(' ');

                var keyCount = (from item in splitted let key = item.Split(':')[0]
                    let value = item.Split(':')[1] select key).Count(key => required.Contains(key));

                var validFields = (from item in splitted let key = item.Split(':')[0]
                    let value = item.Split(':')[1] where CheckValidEntry(key, value) select key).Count();

                if (validFields == required.Count)
                    ansPart2++;

                if (keyCount > 6)
                    ansPart1++;
            }

            Console.WriteLine($"[DAY 4] Answer for part 1 is: {ansPart1}");
            Console.WriteLine($"[DAY 4] Answer for part 2 is: {ansPart2}");
        }

        private bool CheckValidEntry(string key, string value)
        {
            switch (key)
            {
                case "byr":
                    return CheckNumberBetween(value, 1920, 2002);
                case "iyr":
                    return CheckNumberBetween(value, 2010, 2020);
                case "eyr":
                    return CheckNumberBetween(value, 2020, 2030);
                case "hgt":
                {
                    if (value.EndsWith("cm"))
                        return CheckNumberBetween(value.TrimEnd('c', 'm'), 150, 193);
                    if (value.EndsWith("in"))
                        return CheckNumberBetween(value.TrimEnd('i', 'n'), 59, 76);
                    break;
                }
                case "hcl":
                    return Regex.IsMatch(value, "^#([a-fA-F0-9]{6})$");
                case "ecl":
                    return Regex.IsMatch(value, "amb|blu|brn|gry|grn|hzl|oth");
                case "pid":
                    return Regex.IsMatch(value, "^\\d{9}$");
            }
            return false;
        }

        private static bool CheckNumberBetween(string value, int min, int max)
        {
            if (int.TryParse(value, out var number))
                return number >= min && number <= max;

            return false;
        }

        private static IEnumerable<string> FuseMultiLine(IReadOnlyList<string> lines)
        {
            List<string> ans = new();

            string currentLine = "";

            for (int i = 0; i < lines.Count; i++)
            {
                if (string.IsNullOrEmpty(lines[i]))
                {
                    if (string.IsNullOrEmpty(currentLine))
                        continue;

                    ans.Add(currentLine);
                    currentLine = "";
                    continue;
                }
                if (string.IsNullOrEmpty(currentLine))
                    currentLine += lines[i];
                else
                    currentLine += " " + lines[i];
            }

            ans.Add(currentLine);

            return ans;
        }
    }
}
