namespace Ex3;

internal static class ArrayExtension
{
    public delegate int ComparisonDelegate<in T>(T x, T y);

    #region Enums
    public enum Order
    {
        Ascending = 0,
        Descending = 1
    }
    public enum Algorithm
    {
        Inserts = 0, 
        Selection = 1, 
        Heap = 2, 
        Quick = 3, 
        Merge = 4
    }
    #endregion

    #region Public methods
    public static void SortExtend<T>(this ICollection<T> _, ref List<T> values, Order sorting, Algorithm algorithm, IComparer comparer)
    {
        SortExtend(_, ref values, sorting, algorithm, comparer.Compare);
    }
    public static void SortExtend<T>(this ICollection<T> _, ref List<T> values, Order sorting, Algorithm algorithm, Comparer comparer)
    {
        SortExtend(_, ref values, sorting, algorithm, comparer.Compare);
    }
    public static void SortExtend<T>(this ICollection<T> _, ref List<T> values, Order sorting, Algorithm algorithm, ComparisonDelegate<T> comparer)
    {
        switch (algorithm)
        {
            case Algorithm.Inserts:
                SortDataInserts(ref values, sorting, comparer);
                break;

            case Algorithm.Selection:
                SortDataSelection(ref values, sorting, comparer);
                break;

            case Algorithm.Heap:
                SortDataHeap(ref values, sorting, comparer);
                break;

            case Algorithm.Quick:
                SortDataQuick(ref values, sorting, comparer);
                break;

            case Algorithm.Merge:
                SortDataMerge(ref values, sorting, comparer);
                break;
        }
    }
    #endregion

    #region Sorting methods
    private static void SortDataInserts<T>(ref List<T> values, Order sorting, ComparisonDelegate<T> compare)
    {
        int n = values.Count;
        for (int i = 0; i < n; i++)
        {
            for (int j = i; j >0; j--)
            {
                if (LowerThen(values[j], values[j - 1], sorting, compare))
                {
                    (values[j], values[j - 1]) = (values[j - 1], values[j]);
                }
            }
        }
    }

    private static void SortDataSelection<T>(ref List<T> values, Order sorting, ComparisonDelegate<T> compare)
    {
        int n = values.Count;
        int recordNumber = 0;
        
        while (recordNumber < n)
        {
            var findValue = values[recordNumber];
            int findValueIndex = recordNumber;

            for (int i = recordNumber; i < n; i++)
            {
                if (LowerThen(values[i], findValue, sorting, compare))
                {
                    findValue = values[i];
                    findValueIndex = i;
                }
            }

            var swipe = findValue;
            values[findValueIndex] = values[recordNumber];
            values[recordNumber] = swipe;
            recordNumber++;
        }
    }

    private static void SortDataHeap<T>(ref List<T> values, Order sorting, ComparisonDelegate<T> compare)
    {
        int heapSize = values.Count;

        for (int p = (heapSize - 1) / 2; p >= 0; --p)
            SortDataHeap_Max(ref values, heapSize, p, sorting, compare);

        for (int i = values.Count - 1; i > 0; --i)
        {
            (values[i], values[0]) = (values[0], values[i]);

            --heapSize;
            SortDataHeap_Max(ref values, heapSize, 0, sorting, compare);
        }
    }

    private static void SortDataQuick<T>(ref List<T> values, Order sorting, ComparisonDelegate<T> compare)
    {
        SortDataQuick_Sort(ref values, 0, values.Count - 1, sorting, compare);  
    }

    private static void SortDataMerge<T>(ref List<T> values, Order sorting, ComparisonDelegate<T> compare)
    {
        var array = SortDataMerge_ReArrays(values);
        
        while (array.Count != 1) {
            var newArray = new List<List<T>>();
            for (int i = 0; i < array.Count - 1; i += 2)
            {
                newArray.Add(SortDataMerge_LowerThen(array[i], array[i + 1], sorting, compare)
                    ? SortDataMerge_UnionArrays(array[i], array[i + 1])
                    : SortDataMerge_UnionArrays(array[i + 1], array[i]));
            }

            array = new List<List<T>>(newArray);
        }

        values = new List<T>(array[0]);
    }

    private static void SortDataQuick_Sort<T>(ref List<T> values, int leftIndex, int rightIndex, Order sorting, ComparisonDelegate<T> compare)
    {
        var i = leftIndex;
        var j = rightIndex;
        var p = values[leftIndex];
        while (i <= j)
        {
            while (LowerThen(values[i], p, sorting, compare)) { i++; }
            while (LowerThen(p, values[j], sorting, compare)) { j--; }

            if (i <= j)
            {
                (values[i], values[j]) = (values[j], values[i]);
                i++;
                j--;
            }
        }

        if (leftIndex < j) SortDataQuick_Sort(ref values, leftIndex, j, sorting, compare);
        if (i < rightIndex) SortDataQuick_Sort(ref values, i, rightIndex, sorting, compare);
    }

    private static void SortDataHeap_Max<T>(ref List<T> data, int heapSize, int index, Order sorting, ComparisonDelegate<T> compare)
    {
        int left = (index + 1) * 2 - 1;
        int right = (index + 1) * 2;
        int largest;

        if (left < heapSize && LowerThen(data[index], data[left], sorting, compare)) largest = left;
        else largest = index;

        if (right < heapSize && LowerThen(data[largest], data[right], sorting, compare)) largest = right;

        if (largest != index)
        {
            (data[index], data[largest]) = (data[largest], data[index]);

            SortDataHeap_Max(ref data, heapSize, largest, sorting, compare);
        }
    }
    #endregion

    #region Helpers methods
    private static List<List<T>> SortDataMerge_ReArrays<T>(List<T> values)
    {
        var array = new List<List<T>>();
        foreach (var t in values)
        {
            array.Add(new List<T>() { t });
        }
        return array;
    }

    private static List<T> SortDataMerge_UnionArrays<T>(List<T> list1, List<T> list2)
    {
        var array = new List<T>();

        array.AddRange(list1);
        array.AddRange(list2);

        return array;
    }

    private static bool SortDataMerge_LowerThen<T>(List<T> values1, List<T> values2, Order sorting, ComparisonDelegate<T> compare)
    {
        bool smallest = true;
        for (int i = 0; i < values1.Count; i++)
        {

            smallest = smallest && LowerThen(values1[i], values2[i], sorting, compare);
                
        }
        return smallest;

    }

    private static bool LowerThen<T>(T value1, T value2, Order sorting, ComparisonDelegate<T> compare)
    {
        bool compRes = compare(value1, value2) < 0;
        
        return sorting == Order.Ascending 
            ? compRes 
            : !compRes;
    }

    #endregion
}