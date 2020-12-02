using System;
using System.Threading.Tasks;
using Advent.Solutions.Helper;

namespace Advent.Solutions
{
    public class Day2 : ISolution
    {
        private const string FilePath = "../../../../../data/day2_data.txt";

        public async Task Solve()
        {
            var lines = await FileOperations.ReadAllLines(FilePath);

            int ansPart1 = 0;
            int ansPart2 = 0;

            for (int i = 0; i < lines.Length; i++)
            {
                var splitted = lines[i].Split(' ');

                var x = splitted[0].Split('-');
                var min = int.Parse(x[0]);
                var max = int.Parse(x[1]);

                var key = char.Parse(splitted[1].TrimEnd(':'));
                var password = splitted[2];

                var keyCount = 0;

                foreach (var letter in password)
                {
                    if (letter == key)
                        keyCount++;
                }

                if (keyCount >= min && keyCount <= max)
                    ansPart1++;

                if (password[min - 1] == key && password[max - 1] == key ||
                    password[min - 1] != key && password[max - 1] != key)
                    continue;

                ansPart2++;
            }

            Console.WriteLine($"[DAY 2] Answer for part 1 is: {ansPart1}");
            Console.WriteLine($"[DAY 2] Answer for part 2 is: {ansPart2}");
        }
    }
}
