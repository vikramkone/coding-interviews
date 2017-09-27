namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RandomSampling : ISolution
    {
        private int[] input;

        private int K;

        public RandomSampling(int[] stream, int k)
        {
            this.input = stream;
            this.K = k;
        }

        public void Run()
        {
            int[] reservoir = new int[this.K];

            for (int i = 0; i < this.K; i++)
            {
                reservoir[i] = this.input[i];
            }

            Random r = new Random();

            for (int i = this.K; i < this.input.Length; i++)
            {
                int j = r.Next(i + 1);

                if (j < K)
                {
                    reservoir[j] = this.input[i];
                }
            }

            Console.WriteLine("Random elements {0}", string.Join(",", reservoir));
        }
    }
}