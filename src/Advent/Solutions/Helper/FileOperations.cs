using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Advent.Solutions.Helper
{
    public static class FileOperations
    {
        public static async Task<string[]> ReadAllLines(string filePath)
        {
            return await File.ReadAllLinesAsync(filePath);
        }

        public static IEnumerable<string> FuseMultiLine(IReadOnlyList<string> lines)
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
