namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxContiguousSubArray : ISolution
    {
        int[] arr;

        public MaxContiguousSubArray(int[] input)
        {
            this.arr = input;
        }

        public void Run()
        {
            int maxSum = this.MaxSubArray(this.arr, this.arr.Length);
            Console.WriteLine(maxSum);
        }

        public int MaxSubArray(int[] input, int N)
        {
            int max_sum = Int32.MinValue;
            int curr_sum = 0;

            for (int i = 0; i < N; i++)
            {
                curr_sum += input[i];
                max_sum = Math.Max(curr_sum, max_sum);

                if (curr_sum < 0)
                {
                    curr_sum = 0;
                }
            }

            return max_sum;
        }
    }

}
