//using System.Collections.Generic;
//using FluentAssertions;
//using Xunit;

//namespace Hr.Assignment.Tests
//{
//    public class WhenExecutingAXUnitTest
//    {
//        [Fact]
//        public void GivenAScentence_AListOfCountsIsReturned()
//        {
//            var input = "This is the sample input for the application";

//            // Do something here
//            var listOfCounts = CountWordsIn(input);

//            listOfCounts
//                .Should()
//                .NotBeEmpty();
//        }

//        [Fact]
//        public void GivenAScentence_TheWordTheIsCountedTwice()
//        {
//            var input = "This is the sample input for the application";

//            // Do something here
//            var listOfCounts = CountWordsIn(input);

//            listOfCounts["the"]
//                .Should()
//                .Be(2);
//        }

//        private Dictionary<string, int> CountWordsIn(string input)
//        {
//            var countWordsIn = new Dictionary<string, int>();

//            var words = input.Split(' ');

//            foreach (var word in words)
//            {
//                if (countWordsIn.ContainsKey(word))
//                {
//                    countWordsIn[word] += 1;
//                }
//                else
//                {
//                    countWordsIn.Add(word, 1);
//                }
//            }
            
//            return countWordsIn;
//        }
//    }
//}
