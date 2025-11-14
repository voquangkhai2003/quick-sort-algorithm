using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Swap(Array arr, int i, int j)
        {
            int tmp = (int)arr.GetValue(i);
            arr.SetValue(arr.GetValue(j), i);
            arr.SetValue(tmp, j);
        }

        static int Partition(Array arr, int low, int high)
        {
            int mid = low + (high - low) / 2;
            Swap(arr, mid, high);

            int pivot = (int)arr.GetValue(high);
            int i = low - 1;

            for (int j = low; j <= high - 1; j++)
            {
                int vj = (int)arr.GetValue(j);
                if (vj < pivot)
                {
                    i++;
                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return i + 1;
        }

        static void QuickSort(Array arr, int low, int high)
        {
            if (low < high)
            {
                int pi = Partition(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }
        static void Main(string[] args)
        {
            var rand = new Random();
            int n = 100000;
            int loop = 10;
            Array aRandom = Array.CreateInstance(typeof(int), n);
            for (int i = 0; i < n; i++)
                aRandom.SetValue(rand.Next(0, 999999), i);
            Array aAsc = (Array)aRandom.Clone();
            QuickSort(aAsc, 0, aAsc.Length - 1);
            Array aDesc = Array.CreateInstance(typeof(int), n);
            for (int i = 0; i < n; i++)
                aDesc.SetValue((int)aAsc.GetValue(n - 1 - i), i);
            var timer = new Timing();
            double tot, te, tong;
            Array b = null;

            tot = double.PositiveInfinity; te = double.NegativeInfinity; tong = 0;
            for (int k = 0; k < loop; k++)
            {
                var tmp = (Array)aRandom.Clone();
                timer.startTime();
                QuickSort(tmp, 0, tmp.Length - 1);
                timer.StopTime();

                double ms = timer.Result().Milliseconds;

                if (ms < tot) tot = ms;
                if (ms > te) te = ms;
                tong += ms;

                if (k == loop - 1) b = tmp;
            }
            Console.WriteLine("Random");
            Console.WriteLine("Tốt nhất: " + tot + " ms");
            Console.WriteLine("Tệ nhất: " + te + " ms");
            Console.WriteLine("Trung bình: " + (tong / loop) + " ms");
            Console.WriteLine();

            tot = double.PositiveInfinity; te = double.NegativeInfinity; tong = 0;
            for (int k = 0; k < loop; k++)
            {
                var tmp = (Array)aAsc.Clone();
                timer.startTime();
                QuickSort(tmp, 0, tmp.Length - 1);
                timer.StopTime();

                double ms = timer.Result().Milliseconds;

                if (ms < tot) tot = ms;
                if (ms > te) te = ms;
                tong += ms;

                if (k == loop - 1) b = tmp;
            }
            Console.WriteLine("Ascending");
            Console.WriteLine("Tốt nhất: " + tot + " ms");
            Console.WriteLine("Tệ nhất: " + te + " ms");
            Console.WriteLine("Trung bình: " + (tong / loop) + " ms");
            Console.WriteLine();

            tot = double.PositiveInfinity; te = double.NegativeInfinity; tong = 0;
            for (int k = 0; k < loop; k++)
            {
                var tmp = (Array)aDesc.Clone();
                timer.startTime();
                QuickSort(tmp, 0, tmp.Length - 1);
                timer.StopTime();

                double ms = timer.Result().Milliseconds;

                if (ms < tot) tot = ms;
                if (ms > te) te = ms;
                tong += ms;

                if (k == loop - 1) b = tmp;
            }
            Console.WriteLine("Descending");
            Console.WriteLine("Tốt nhất: " + tot + " ms");
            Console.WriteLine("Tệ nhất: " + te + " ms");
            Console.WriteLine("Trung bình: " + (tong / loop) + " ms");
            Console.WriteLine();
        }
    }
}
