class item
{
    public int Value;
    public int Index;
    public item(int value, int index)
    {
        this.Value = value;
        this.Index = index;
    }
    public override string ToString()
    {
        return $"({Value},{Index}) ";
    }

    public static item[] GetListItem(int size, int minvalue, int maxvalue)
    // dùng static để khỏi thẳng hàm từ class (dạng class.method())
    {
        item[] arr = new item[size];
        Random r = new Random();
        for (int i = 0; i < size; i++)
        {
            arr[i] = new item(r.Next(minvalue, maxvalue), i);
        }
        return arr;
    }
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = temp;
    }
}

class ItemQuickSort
{
    static int Partition(item[] arr, int low, int high)
    {
        int pivot = arr[high].Value;
        int i = low;
        for (int j = low; j < high; j++)
        {
            if (arr[j].Value < pivot)
            {
                item.Swap(ref arr[i], ref arr[j]);
                i++;
            }
        }
        item.Swap(ref arr[i], ref arr[high]);
        return i;
    }
    static void Quicksort(item[] arr, int low, int high)
    {
        if (low < high)
        {
            int p = Partition(arr, low, high);
            if (p > 1)
                Quicksort(arr, low, p - 1);
            if (p + 1 < high)
                Quicksort(arr, p + 1, high);
        }
    }

    /*static void Main(string[] args)
    {
        item[] arr = item.GetListItem(10, 1, 10);
        var arr1 = (item[])arr.Clone();
        Console.WriteLine("truoc khi sort: ");
        Console.WriteLine(string.Join<item>(", ", arr));
        Quicksort(arr1, 0, arr.Length - 1);
        Console.WriteLine("sau khi sort: ");
        Console.WriteLine(string.Join<item>(", ", arr1));
    }*/
}
