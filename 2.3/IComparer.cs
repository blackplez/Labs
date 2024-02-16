namespace Ex3;

internal class IComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        if (x is null || y is null) return 0;
        if (x.Length > y.Length) return 1;
        if (x.Length < y.Length) return -1;
        return 0;

    }

    public int Compare<T>(T? t1, T? t2)
    {
        if (t1 is null || t2 is null || t1 is not string || t2 is not string) return 0;
        return Compare(t1 as string, t2 as string);
    }
}