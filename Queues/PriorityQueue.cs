namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PriorityQueue<T> where T : IComparable<T>
    {
        private List<T> queue;

        public PriorityQueue()
        {
            this.queue = new List<T>();
        }

        public void Enqueue(T item)
        {
            // Add element to the end of the list
            this.queue.Add(item);

            // heapify from end
            this.HeapifyFromEnd();
        }

        public T Dequeue()
        {
            if (this.Count() == 0)
            {
                throw new ArgumentException("Queue is empty!!");
            }

            // Get element at the begining
            T first = this.queue[0];

            // Put the last element at the front and remove it
            int lastIndex = this.Count() - 1;
            this.queue[0] = this.queue[lastIndex];
            this.queue.RemoveAt(lastIndex);

            // Heapify from start
            this.HeapifyFromStart();

            return first;
        }

        public T Peek()
        {
            Console.WriteLine("Min element is {0}", this.queue[0]);
            return this.queue[0];
        }

        public int Count()
        {
            return this.queue.Count;
        }

        private void HeapifyFromEnd()
        {
            // Get child index
            int childIndex = this.Count() - 1;

            while (childIndex > 0)
            {
                // Get parent index
                int parentIndex = (childIndex - 1) / 2;

                // if child is greater >= parent, then we are good
                if (this.queue[childIndex].CompareTo(this.queue[parentIndex]) >= 0)
                {
                    return;
                }

                // If not then exchange child and parent
                this.Exchange(childIndex, parentIndex);
                childIndex = parentIndex;
            }
        }

        private void HeapifyFromStart()
        {
            int parentIndex = 0;
            int lastIndex = this.Count() - 1;

            while (true)
            {
                int leftChild = parentIndex * 2 + 1;
                int rightChild = parentIndex * 2 + 2;

                // No more children, so done
                if (leftChild > lastIndex)
                {
                    return;
                }

                // If right child is less than left child, then exchange
                if (rightChild <= lastIndex && this.queue[rightChild].CompareTo(this.queue[leftChild]) < 0)
                {
                    leftChild = rightChild;
                }

                // Parent is smaller than smallest child, done
                if (this.queue[parentIndex].CompareTo(this.queue[leftChild]) <= 0)
                {
                    return;
                }

                // If not then exchange parent and child
                this.Exchange(parentIndex, leftChild);
                parentIndex = leftChild;
            }
        }

        private void Exchange(int id1, int id2)
        {
            T temp = this.queue[id1];
            this.queue[id1] = this.queue[id2];
            this.queue[id2] = temp;
        }
    }
}