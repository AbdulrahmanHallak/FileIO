namespace FileIO;

public class StreamWR
{
    public static async Task ReadFile(string path)
    {
        using var streamReader = File.OpenText(path);
        var content = await streamReader.ReadToEndAsync();
    }

    public static async Task WriteToFile(string path)
    {
        using var streamWriter = File.AppendText(path);
        await streamWriter.WriteAsync("hello world");
    }
}