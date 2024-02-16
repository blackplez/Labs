using static Ex3.ArrayExtension;

namespace Ex3;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> sample = new() { "4", "2", "3", "1", "8", "5", "7", "6" };
        
        var strings = new List<string>(sample);
        strings.SortExtend(ref strings, Order.Ascending, Algorithm.Selection, new IComparer());
        Console.WriteLine("Selection: " + string.Join(" ", strings));

        strings = new List<string>(sample);
        strings.SortExtend(ref strings, Order.Ascending, Algorithm.Inserts, new IComparer());
        Console.WriteLine("Inserts: " + string.Join(" ", strings));

        strings = new List<string>(sample);
        strings.SortExtend(ref strings, Order.Ascending, Algorithm.Merge, new IComparer());
        Console.WriteLine("Merge: " + string.Join(" ", strings));

        strings = new List<string>(sample);
        strings.SortExtend(ref strings, Order.Ascending, Algorithm.Quick, new IComparer());
        Console.WriteLine("Quick: " + string.Join(" ", strings));

        strings = new List<string>(sample);
        strings.SortExtend(ref strings, Order.Ascending, Algorithm.Heap, new IComparer());
        Console.WriteLine("Heap: " + string.Join(" ", strings));
    }
}
