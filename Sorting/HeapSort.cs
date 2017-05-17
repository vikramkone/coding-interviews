using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingQuestions
{
    class HeapSort : ISolution
    {
        private static int[] input = new int[] { 0, 1, 2, 3, 4, 5, 6 };

        public void Run()
        {
            HeapSortImp(input, input.Length);
            foreach (var e in input) Console.WriteLine(e);
            Console.Read();
        }

        public void HeapSortImp(int [] array, int count)
        {
            Heapify(array, count);
            int end = count - 1;

            while (end > 0)
            {
                Swap(array, end, 0);
                end = end - 1;
                SiftDown(array, 0, end);
            }
        }

        public static void Heapify(int[] array, int count)
        {
            int start = iParent(count - 1);

            while(start >= 0)
            {
                SiftDown(array, start, count - 1);
                start--;
            }
        }

        public static void SiftDown(int[] array, int start, int end)
        {
            int root = start;
            
            while(iLeftChild(root) <= end)
            {
                int child = iLeftChild(root);
                int swap = root;

                if (array[swap] < array[child]) swap = child;
                if (child + 1 <= end && array[swap] < array[child + 1]) swap = child + 1;
                if (swap == root) return;
                else
                {
                    Swap(array, root, swap);
                    root = swap;
                }
            }
        }

        public static void Swap(int[] array, int a, int b)
        {
            int temp = array[a];
            array[a] = array[b];
            array[b] = temp;
        }

        public static int iParent(int i)
        {
            return (int)decimal.Floor((i - 1) / 2);
        }

        public static int iLeftChild(int i)
        {
            return 2 * i + 1;
        }

        public static int iRightChild(int i)
        {
            return 2 * i + 2;
        }
    }
}
