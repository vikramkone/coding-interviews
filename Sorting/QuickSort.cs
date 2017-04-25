namespace CodingQuestions
{
    using System;
    using System.Linq;

    public class QuickSort : ISolution
    {
        private int[] input;

        public QuickSort()
        {
            this.input = new int[] { 13, 1, 4, 1, 5, 9, 2, 6, 5, 3 };
        }

        public void Run()
        {
            input.ToList().ForEach(x => Console.Write("{0},",x));
            Console.WriteLine();
            this.QuickSortImpl(this.input, 0, this.input.Length - 1);
            input.ToList().ForEach(x => Console.Write("{0},",x));
        }

        private void QuickSortImpl(int[] array, int lo, int hi)
        {
            if (lo < hi)
            {
                int p = this.Partition(array, lo, hi);
                this.QuickSortImpl(array, lo, p - 1);
                this.QuickSortImpl(array, p + 1, hi);
            }
        }

        private int Partition(int[] input, int low, int high)
        {
            int pivot = input[high];
            int pIndex = low;

            for (int i = low; i < high; i++)
            {
                if (input[i] <= pivot)
                {
                    this.Swap(input, i, pIndex);
                    pIndex++;
                }
            }

            this.Swap(input, pIndex, high);
            return pIndex;
        }

        private void Swap(int[] ar, int a, int b)
        {
            int temp = ar[a];
            ar[a] = ar[b];
            ar[b] = temp;
        }
    }
}