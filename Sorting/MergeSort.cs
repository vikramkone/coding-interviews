using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrayToBeSorted = new int[] { 14, 5, 2, 1, 66, 3, 27, 4, 5, 6, 7 };
            int[] outputArray = new int[arrayToBeSorted.Length];

            Random r = new Random();
            int[] largeArray = new int[10 * 1000 * 1000];
            for (int i = 0; i < largeArray.Length - 1; i++)
            {
                largeArray[i] = r.Next(20000);
            }

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();
            MergeSort(largeArray, 0, largeArray.Length - 1, outputArray);
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);

            Console.Read();
        }

        public static void MergeSort(int[] arrayToBeSorted, int start, int end, int[] outputArray)
        {
            //Console.WriteLine("Mergint start = " + start + " with end = " + end);

            if (start == end) return;

            int mid = start + (end - start) / 2;
            MergeSort(arrayToBeSorted, start, mid, outputArray);
            MergeSort(arrayToBeSorted, mid + 1, end, outputArray);
            Merge(start, mid + 1, end, arrayToBeSorted, outputArray);
        }

        public static void MergeSortParallel(int[] arrayToBeSorted, int start, int end, int[] outputArray)
        {
            if (start == end) return;

            int mid = start + (end - start) / 2;
            ParallelOptions p = new ParallelOptions();
            p.MaxDegreeOfParallelism = 4;
            Parallel.Invoke(p, () => MergeSortParallel(arrayToBeSorted, start, mid, outputArray),
                           () => MergeSortParallel(arrayToBeSorted, mid + 1, end, outputArray));
            Merge(start, mid + 1, end, arrayToBeSorted, outputArray);
        }

        public static void Merge(int start, int mid, int end, int[] input, int[] output)
        {
            int[] tempArray = new int[end - start + 1];

            int i = start;
            int j = mid;
            int k = 0;

            while (i < mid && j <= end)
            {
                if (input[i] < input[j])
                {
                    tempArray[k] = input[i];
                    i++;
                    k++;
                }
                else
                {
                    tempArray[k] = input[j];
                    k++;
                    j++;
                }
            }

            while (i < mid)
            {
                tempArray[k] = input[i];
                i++;
                k++;
            }

            while (j <= end)
            {
                tempArray[k] = input[j];
                j++;
                k++;
            }

            for (int n = 0; n < tempArray.Length; n++)
            {
                input[start + n] = tempArray[n];
            }
        }

        private static void MergeSortImpl(int[] input, int start, int end, int[] output)
        {
            if (start < end)
            {
                int mid = start + (end - start) / 2;
                MergeSortImpl(input, start, mid, output);
                MergeSortImpl(input, mid + 1, end, output);
                Merge2(start, mid, end, input, output);
            }

            Merge2(start, end / 2, end, input, output);
        }

        private static void Merge2(int start, int mid, int end, int[] input, int[] output)
        {
            for (int n = start; n <= end; n++)
            {
                output[n] = input[n];
            }

            int i = start;
            int j = mid + 1;
            int k = start;

            while (i <= mid && j <= end)
            {
                if (output[i] <= output[j])
                {
                    input[k++] = output[i++];
                }
                else
                {
                    input[k++] = output[j++];
                }
            }

            // copy left over elements if any from left side
            while (i <= mid)
            {
                input[k++] = output[i++];
            }
        }
    }
}
