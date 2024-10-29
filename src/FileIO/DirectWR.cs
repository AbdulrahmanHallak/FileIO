using System.Text;

namespace FileIO;

public class DirectWR
{
    public static async Task ReadLines(string path)
    {
        var file = File.ReadLinesAsync(path);
        var builder = new StringBuilder();
        await foreach (var line in file)
        {
            builder.AppendLine(line);
            builder.Length -= Environment.NewLine.Length;
        }
    }
    public static Task<string> ReadText(string path) => File.ReadAllTextAsync(path);

    public static async Task WriteToFile(string path)
    {
        await File.WriteAllLinesAsync(path, ["hello world"]);
    }
}