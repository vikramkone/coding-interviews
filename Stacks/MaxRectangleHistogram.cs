namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MaxRectangleHistogram : ISolution
    {
        private int[] input;

        public MaxRectangleHistogram(int[] x)
        {
            this.input = x;
        }

        public void Run()
        {
            int maxArea = this.LargestRectangleArea(this.input);

            // print it
            Console.WriteLine(maxArea);
        }

        public int LargestRectangleArea(int[] height)
        {
            int len = height.Length;
            Stack<int> s = new Stack<int>();
            int maxArea = 0;
            for (int i = 0; i <= len; i++)
            {
                int h = (i == len ? 0 : height[i]);
                if (s.Count == 0 || h >= height[s.Peek()])
                {
                    s.Push(i);
                }
                else
                {
                    int length = height[s.Pop()];
                    int width = s.Count == 0 ? i : i - 1 - s.Peek();
                    int curArea = length * width;

                    maxArea = Math.Max(maxArea, curArea);
                    i--;
                }
            }
            return maxArea;
        }
    }
}