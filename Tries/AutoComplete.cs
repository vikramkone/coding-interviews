namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class AutoComplete
    {
        private Trie trie = new Trie();

        private StringBuilder sb = new StringBuilder();

        public AutoComplete(string[] sentences, int[] times)
        {
            if (sentences == null || times == null || sentences.Length != times.Length)
            {
                throw new ArgumentException("Invalid input");
            }

            for (int i = 0; i < sentences.Length; i++)
            {
                for (int j = 0; j < times[i]; j++)
                {
                    trie.AddWord(sentences[i]);
                }
            }
        }

        public IList<string> Input(char c)
        {
            List<string> result = new List<string>();

            if (c == '#')
            {
                string sentence = sb.ToString();
                trie.AddWord(sentence);

                // clear the buffer
                sb.Clear();
            }
            else
            {
                sb.Append(c);
                result = trie.GetWords(sb.ToString()).ToList();
            }

            return result;
        }
    }
}