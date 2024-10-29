using System.Text;

namespace FileIO;

public class DirectWR
{
    public static async Task ReadLines(string path)
    {
        var file = File.ReadLinesAsync(path);
        var builder = new StringBuilder();
        await foreach (var line in file)
            builder.Append(line);
    }
    public static async Task WriteToFile(string path)
    {
        await File.WriteAllLinesAsync(path, ["hello world"]);
    }
}