namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CombinationNumbers : ISolution
    {
        private int num;

        public CombinationNumbers(int n)
        {
            this.num = n;
        }

        public void Run()
        {
            if (this.num < 2)
            {
                throw new ArgumentException("Input can't be < 2");
            }

            // Initialize array of size 2*n
            int size = 2 * this.num;
            int[] input = new int[size];
            CombinationNumbersUtil(input, 1);
        }

        private  void CombinationNumbersUtil(int[] input, int n)
        {
            if (n == this.num + 1)
            {
                Console.WriteLine("Solution is {0}", string.Join(",", input));
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (CanPlace(input, n, i))
                {
                    // Place them
                    input[i] = n;
                    input[i + n + 1] = n;

                    // Place next num
                    CombinationNumbersUtil(input, n + 1);

                    // back track
                    input[i] = 0;
                    input[i + n + 1] = 0;
                }
            }

        }

        // Check if we can place the number 'n' at index 'i'
        private bool CanPlace(int[] input, int n, int i)
        {
            int j = i + n + 1;

            if (i < input.Length && j < input.Length && input[i] == 0 && input[j] == 0)
            {
                return true;
            }

            return false;
        }
    }
}