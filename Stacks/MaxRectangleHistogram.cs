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
            int maxArea = Int32.MinValue;
            int currArea = 0;
            int width = 0;
            int length = 0;
            Stack<int> hStack = new Stack<int>();
            Stack<int> pStack = new Stack<int>();

            for (int i = 0; i < this.input.Length; i++)
            {
                int height = this.input[i];

                // if stack is empty or height is greater than top height, then push that height
                if (hStack.Count == 0 || height > hStack.Peek())
                {
                    hStack.Push(height);
                    pStack.Push(i);
                }
                else if (height < hStack.Peek()) // if height is less than top height, then pop that height
                {
                    while (hStack.Count != 0 && height < hStack.Peek())
                    {
                        length = hStack.Pop();
                        width = i - pStack.Pop();
                        currArea = length * width;
                        maxArea = Math.Max(currArea, maxArea);
                    }

                    // push that height
                    hStack.Push(height);
                    pStack.Push(width);
                }
            }

            // pop any remaining hright
            while (hStack.Count != 0)
            {
                length = hStack.Pop();
                width = this.input.Length - pStack.Pop();
                currArea = length * width;
                maxArea = Math.Max(currArea, maxArea);
            }

            // print that shit
            Console.WriteLine(maxArea);
        }
    }
}