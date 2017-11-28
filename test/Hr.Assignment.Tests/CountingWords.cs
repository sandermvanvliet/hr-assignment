using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Hr.Assignment.Tests
{
    public class CountingWords
    {
        [Fact]
        public void GivenAScentence_AListOfWordsIsReturned()
        {
            // Given
            var scentence = "This is the sample input for the application";

            // Act
            var listOfWords = CountWords(scentence);

            // Assert
            listOfWords
                .Should()
                .NotBeEmpty();
        }

        [Fact]
        public void GivenAScentence_TheWordTheIsCountedTwice()
        {
            // Given
            var scentence = "This is the sample input for the application";

            // Act
            var listOfWords = CountWords(scentence);

            // Assert
            listOfWords["the"]
                .Should()
                .Be(2);
        }

        private static Dictionary<string, int> CountWords(string scentence)
        {
            var words = scentence.Split(' ');

            var count = new Dictionary<string, int>();

            foreach (var word in words)
            {
                if (count.ContainsKey(word))
                {
                    count[word] += 1;
                }
                else
                {
                    count.Add(word, 1);
                }
            }

            return count;
        }
    }
}
