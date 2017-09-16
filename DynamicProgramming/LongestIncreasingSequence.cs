namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestIncreasingSequence : ISolution
    {
        private int[] input;

        public LongestIncreasingSequence(int[] input)
        {
            this.input = input;
        }
        public void Run()
        {
            // initialize with 1s
            int[] result = input.Select(x => 1).ToArray();
            int max = 0;

            for (int i = 1; i < input.Length; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    if (input[i] > input[j] && result[i] < result[j] + 1)
                    {
                        result[i] = result[j] + 1;
                        max = Math.Max(result[i], max);
                    }
                }
            }

            max = LongestIncreasingSequence2(input, input.Length);
            Console.WriteLine("Length of longest squence is {0}", max);
        }

        private int LongestIncreasingSequence2(int[] A, int size)
        {
            int[] tailTable = new int[size];

            tailTable[0] = A[0];
            int len = 1;
            for (int i = 1; i < size; i++)
            {
                if (A[i] < tailTable[0])
                    // new smallest value
                    tailTable[0] = A[i];

                else if (A[i] > tailTable[len - 1])
                    // A[i] wants to extend largest subsequence
                    tailTable[len++] = A[i];

                else
                    // A[i] wants to be current end candidate of an existing
                    // subsequence. It will replace ceil value in tailTable
                    tailTable[CeilIndex(tailTable, -1, len - 1, A[i])] = A[i];
            }

            return len;
        }

        // Binary search (note boundaries in the caller)
        // A[] is ceilIndex in the caller
        static int CeilIndex(int[] A, int l, int r, int key)
        {
            while (r - l > 1)
            {
                int m = l + (r - l) / 2;
                if (A[m] >= key)
                    r = m;
                else
                    l = m;
            }

            return r;
        }
    }
}