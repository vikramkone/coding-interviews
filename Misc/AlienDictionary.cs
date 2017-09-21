namespace CodingQuestions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AlientDictionary
    {
        private List<string> input;

        public AlientDictionary(List<string> input)
        {
            this.input = input;
        }
        public List<Tuple<char, char>> CreateEdges()
        {
            List<Tuple<char, char>> result = new List<Tuple<char, char>>();

            for (int i = 0; i < this.input.Count - 1; i++)
            {
                string word1 = this.input[i];
                string word2 = this.input[i + 1];

                int minLength = Math.Min(word1.Length, word2.Length);

                for (int j = 0; j < minLength; j++)
                {
                    if (word1[j] != word2[j])
                    {
                        result.Add(Tuple.Create(word1[j], word2[j]));
                        break;
                    }
                }
            }

            return result;
        }
    }
}
