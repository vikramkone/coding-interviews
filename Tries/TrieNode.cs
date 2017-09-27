namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;


    public class TrieNode
    {
        public Dictionary<char, TrieNode> Children { get; set; }

        public bool IsWord
        {
            get { return this.WordCount > 0; }
        }

        public char Character { get; set; }

        public int WordCount { get; set; }

        public TrieNode(char c)
        {
            this.Character = c;
            this.Children = new Dictionary<char, TrieNode>();
        }

        public TrieNode GetChild(char c)
        {
            TrieNode node;
            this.Children.TryGetValue(c, out node);
            return node;
        }

        public void SetChild(TrieNode child)
        {
            if (child == null)
            {
                throw new ArgumentNullException();
            }

            this.Children[child.Character] = child;
        }
    }

    public class Trie
    {
        public TrieNode Root { get; private set; }

        public Trie()
        {
            this.Root = new TrieNode(' ');
        }

        public void AddWord(string word)
        {
            TrieNode trieNode = this.Root;

            foreach (char c in word)
            {
                var child = trieNode.GetChild(c);

                if (child == null)
                {
                    child = new TrieNode(c);
                    trieNode.SetChild(child);
                }
                trieNode = child;
            }
            trieNode.WordCount++;
        }

        /// <summary>
		/// Get the equivalent TrieNode in the Trie for given prefix. 
		/// If prefix not present, then return null.
		/// </summary>
		private TrieNode GetTrieNode(string prefix)
        {
            var trieNode = this.Root;

            foreach (var prefixChar in prefix)
            {
                trieNode = trieNode.GetChild(prefixChar);
                if (trieNode == null)
                {
                    break;
                }
            }
            return trieNode;
        }

        public IList<string> GetWords(string prefix, int count)
        {
            return this.GetWords(prefix)
            .Select(x => new { Prefix = x, Node = this.GetTrieNode(x) })
            .OrderByDescending(x => x.Node.WordCount)
            .ThenBy(x => x.Prefix, StringComparer.Ordinal)
            .Take(count)
            .Select(x => x.Prefix)
            .ToList();
        }

        /// <summary>
        /// Get words for given prefix.
        /// </summary>
        public ICollection<string> GetWords(string prefix)
        {
            if (prefix == null)
            {
                throw new ArgumentNullException(nameof(prefix));
            }

            // Empty list if no prefix match
            var words = new List<string>();
            var buffer = new StringBuilder();
            buffer.Append(prefix);
            TrieNode node = GetTrieNode(prefix);

            this.GetWords(node, words, buffer);
            return words;
        }

        /// <summary>
		/// Recursive method to get all the words starting from given TrieNode.
		/// </summary>
		private void GetWords(TrieNode trieNode, ICollection<string> words, StringBuilder buffer)
        {
            if (trieNode == null)
            {
                return;
            }
            if (trieNode.IsWord)
            {
                words.Add(buffer.ToString());
            }
            foreach (var child in trieNode.Children.Values)
            {
                buffer.Append(child.Character);
                this.GetWords(child, words, buffer);

                // Remove recent character
                buffer.Length--;
            }
        }
    }
}