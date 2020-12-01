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
    }
}
