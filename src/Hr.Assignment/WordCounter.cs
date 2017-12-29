using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hr.Assignment
{
    public class WoordenTeller
    {
        private readonly IWoordenSplitter _woordenSplitter;

        public WoordenTeller(IWoordenSplitter woordenSplitter)
        {
            _woordenSplitter = woordenSplitter;
        }

        public Dictionary<string, int> CountWords(string input, int top = int.MaxValue)
        {
            string[] words = _woordenSplitter.SplitWords(input);

            Dictionary<string, int> result = 
                words
                    .GroupBy(g => g)
                    .OrderByDescending(g => g.Count())
                    .Take(top)
                    .ToDictionary(s => s.Key, s => s.Count());

            return result;
        }

        public int CountWordInSentence(string sentence, string word)
        {
            Dictionary<string, int> wordsCounted = CountWords(sentence);
            //if (!wordsCounted.ContainsKey(word))
            //{
            //    return 0;
            //}
            return wordsCounted[word];
        }
    }

    public interface IWoordenSplitter
    {
        string[] SplitWords(string input);
    }
}
