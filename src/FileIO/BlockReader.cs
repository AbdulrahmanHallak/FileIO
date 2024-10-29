using System.Buffers;
using System.Text;

namespace FileIO;

public class BlockReader
{
    public static void ReadLines(string path)
    {
        using var streamReader = new StreamReader(path);
        var buffer = new char[4096]; // default buffer size that FileStream uses.
        int numberRead;
        var stringBuilder = new StringBuilder();

        while ((numberRead = streamReader.ReadBlock(buffer, 0, buffer.Length)) > 0)
        {
            stringBuilder.Append(buffer[..numberRead]);
        }
    }
    public void UseStreamReaderReadBlockWithArrayPool(string path)
    {
        using var streamReader = new StreamReader(path);
        var buffer = ArrayPool<char>.Shared.Rent(4096);
        int numberRead;
        var stringBuilder = new StringBuilder();

        while ((numberRead = streamReader.ReadBlock(buffer, 0, buffer.Length)) > 0)
        {
            stringBuilder.Append(buffer[..numberRead]);
        }
    }

    public void UseStreamReaderReadBlockWithSpan(string path)
    {
        using var streamReader = new StreamReader(path);
        var buffer = new char[4096].AsSpan();
        int numberRead;
        var stringBuilder = new StringBuilder();

        while ((numberRead = streamReader.ReadBlock(buffer)) > 0)
        {
            stringBuilder.Append(buffer[..numberRead]);
        }
    }
}