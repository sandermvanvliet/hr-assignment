using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hr.Assignment
{
    public class WordCounter
    {
        private readonly IWordSplitter _wordSplitter;

        public WordCounter(IWordSplitter wordSplitter)
        {
            _wordSplitter = wordSplitter;
        }

        public Dictionary<string, int> CountWords(string input)
        {
            string[] words = _wordSplitter.Split(input);
            words = _wordSplitter.Split(input);
            words = _wordSplitter.Split(input);
            var result = words.Distinct().ToDictionary(w => w, w => 0);
            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                result[word]++;
            }

            return result;
        }
    }

    public interface IWordSplitter
    {
        string[] Split(string input);
    }
}
