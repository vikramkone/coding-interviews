namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LRUCache<T, S>
    {
        private int cacheSize;

        private Dictionary<T, CacheNode> cache;

        private CacheNode head = new CacheNode();

        private CacheNode tail = new CacheNode();

        public LRUCache(int capacity)
        {
            this.cacheSize = capacity;
            this.cache = new Dictionary<T, CacheNode>();
        }

        public S Get(T key)
        {
            S result = default(S);

            if (this.cache.ContainsKey(key))
            {
                var node = this.cache[key];
                result = node.Value;
                this.MoveToHead(node);
            }

            return result;
        }

        public void Set(T key, S value)
        {
            CacheNode node;

            if (!this.cache.ContainsKey(key))
            {
                node = new CacheNode { Key = key, Value = value };

                // If reached capavity, remove node from tail
                if (this.cache.Count == this.cacheSize)
                {
                    // Remove node from tail
                    tail = tail.Previous;
                    tail.Next = null;
                }
            }
            else
            {
                node = this.cache[key];
                node.Value = value;
            }

            // Move to head
            this.MoveToHead(node);
        }

        private void MoveToHead(CacheNode node)
        {
            var prevNode = node.Previous;
            var nextNode = node.Next;

            // If existing node, then adjust the pointers
            if (prevNode != null && nextNode != null)
            {
                prevNode.Next = nextNode;
                nextNode.Previous = prevNode;
            }

            node.Previous = null;
            head.Previous = node;
            node.Next = head;
            head = node;
        }

        private class CacheNode
        {
            public CacheNode Previous;

            public CacheNode Next;

            public T Key;

            public S Value;
        }
    }
}
