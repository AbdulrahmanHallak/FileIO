using System.Text;
using Microsoft.Win32.SafeHandles;

namespace FileIO;

public class RandomAccessHandler
{
    public static async Task ReadFile(string path)
    {
        using SafeFileHandle handle =
             File.OpenHandle(
                path: path,
                mode: FileMode.Open,
                access: FileAccess.Read);

        var length = RandomAccess.GetLength(handle);
        Memory<byte> contentBytes = new(new byte[length]);
        await RandomAccess.ReadAsync(handle, contentBytes, fileOffset: 0);
        string content = Encoding.UTF8.GetString(contentBytes.ToArray());
    }

    public static async Task WriteToFile(string path)
    {
        using SafeFileHandle handle =
             File.OpenHandle(
                path: path,
                mode: FileMode.Open,
                access: FileAccess.Read);
        var content = "Hello World";
        ReadOnlyMemory<byte> buffer = new(Encoding.UTF8.GetBytes(content));
        await RandomAccess.WriteAsync(handle, buffer, fileOffset: 0);
    }
}