namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CollectCoins : ISolution
    {
        private List<int> coins = null;

        private int steps = 0;

        public CollectCoins(int[] input)
        {
            this.coins = new List<int>(input);
        }

        public void Run()
        {
            if (this.coins.Count > 0)
            {
                // break up into smaller lists
                foreach (var list in GetSubLists(this.coins))
                {
                    RemoveCoins(list);
                }
            }

            Console.WriteLine("Min steps to collect all coins {0}", steps);
        }

        public List<List<int>> GetSubLists(List<int> subCoins)
        {
            List<List<int>> subLists = new List<List<int>>();

            List<int> subList = new List<int>();

            foreach (int coin in subCoins)
            {
                if (coin == 0)
                {
                    subLists.Add(subList);
                    subList = new List<int>();
                }
                else
                {
                    subList.Add(coin);
                }
            }

            if (subList.Count > 0)
            {
                subLists.Add(subList);
            }

            return subLists;
        }

        public void RemoveCoinsHorizontal(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i]--;
            }
        }

        public void RemoveCoins(List<int> list)
        {
            if (list.All(x => x == 0))
            {
                return;
            }

            // get max height
            int maxHeight = list.Max();

            // Remove coins horizontally if max is less than length
            if (maxHeight < list.Count)
            {
                RemoveCoinsHorizontal(list);
            }
            else // remove vertically
            {
                list.Remove(maxHeight);
            }

            this.steps++;

            // break up into smaller lists
            foreach (var subList in GetSubLists(list))
            {
                RemoveCoins(subList);
            }
        }
    }
}