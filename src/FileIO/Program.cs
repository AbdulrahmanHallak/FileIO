namespace FileIO;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        var path = Path.Join(Directory.GetCurrentDirectory(), "Quotes.txt");
        BlockReader.ReadLines(path);
    }
}
