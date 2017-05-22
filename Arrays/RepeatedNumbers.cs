namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RepeatedNumbers : ISolution
    {
        private List<int> input;

        public RepeatedNumbers(List<int> x)
        {
            this.input = x;
        }

        public void Run()
        {
            var output = this.repeatedNumber(this.input);
            output.ForEach(x => Console.WriteLine(x));
        }

        public List<int> repeatedNumber(List<int> input)
        {
            ulong expected_sum = 0;
            ulong actual_sum = 0;
            ulong actual_sqr_sum = 0;
            ulong expected_sqr_sum = 0;
            bool is_reversed = false;

            for (int i = 1; i <= input.Count; i++)
            {
                expected_sum += (ulong)i;
                expected_sqr_sum += (ulong)(i * i);
                actual_sum += (ulong)input[i - 1];
                actual_sqr_sum += (ulong)(input[i - 1] * input[i - 1]);
            }

            ulong A = Math.Max(actual_sum, expected_sum);
            ulong B = Math.Min(actual_sum, expected_sum);
            ulong A2 = Math.Max(actual_sqr_sum, expected_sqr_sum);
            ulong B2 = Math.Min(actual_sqr_sum, expected_sqr_sum);

            if (expected_sum > actual_sum)
            {
                is_reversed = true;
            }

            ulong diff = A - B;
            ulong sum = (A2 - B2) / diff;

            ulong repeated = (diff + sum) / 2;
            ulong missing = (repeated - diff);

            if (is_reversed)
            {
                return new List<int>() { (int)missing, (int)repeated };
            }
            else
            {
                return new List<int>() { (int)repeated, (int)missing };
            }
        }
    }
}