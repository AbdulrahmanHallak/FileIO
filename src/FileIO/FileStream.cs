using System.Text;

namespace FileIO;

public class FileStream
{
    public static async Task ReadFile(string path)
    {
        using System.IO.FileStream fileStream = File.Open(path, FileMode.Open);
        byte[] byteContent = new byte[fileStream.Length];
        await fileStream.ReadAsync(byteContent.AsMemory(start: 0, (int)fileStream.Length));
        var content = Encoding.UTF8.GetString(byteContent);
    }
    public static async Task WriteToFile(string path)
    {
        using System.IO.FileStream fileStream = File.Open(path, FileMode.OpenOrCreate);
        var content = "hello world";
        byte[] bytes = Encoding.UTF8.GetBytes(content);
        await fileStream.WriteAsync(bytes.AsMemory(start: 0, (int)fileStream.Length));
    }
}