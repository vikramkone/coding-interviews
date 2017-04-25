namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MergeSort : ISolution
    {
        public void Run()
        {
            int[] input = new int[] { 13, 1, 4, 1, 5, 9, 2, 6, 5, 3, 12 };
            int[] output = new int[input.Length];
            this.MergeSortImpl(input, 0, input.Length - 1, output);
            output.ToList().ForEach(x => Console.WriteLine("{0}", x));
        }

        private void MergeSortImpl(int[] input, int start, int end, int[] output)
        {
            if (start < end)
            {
                int mid = start + (end - start) / 2;
                MergeSortImpl(input, start, mid, output);
                MergeSortImpl(input, mid + 1, end, output);
                Merge(start, mid, end, input, output);
            }

            Merge(start, end / 2, end, input, output);
        }

        private void Merge(int start, int mid, int end, int[] input, int[] output)
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