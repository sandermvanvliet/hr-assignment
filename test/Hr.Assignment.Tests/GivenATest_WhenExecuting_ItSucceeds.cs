using Moq;
using System.Collections.Generic;
using Xunit;

namespace Hr.Assignment.Tests
{
    public class WhenExecutingAXUnitTest
    {
        [Fact]
        public void GivenASampleSentence_Then_WeExpectTheCorrectOutput()
        {
            // Arrange
            var systemUnderTest = new WordCounter(new WordSplitterStub());
            string sampleSentence = "This is the sample input for the application";

            // Act
            Dictionary<string, int> output = systemUnderTest.CountWords(sampleSentence);

            // Assert
            Assert.Equal(output["the"], 2);
            Assert.Equal(output["is"], 1);
            Assert.Equal(output["for"], 1);
            Assert.Equal(output["this"], 1);
            Assert.Equal(output["sample"], 1);
            Assert.Equal(output["application"], 1);
        }

        [Fact]
        public void GivenASampleSentence_Then_WeExpectTheCorrectOutput2()
        {
            // Arrange
            var systemUnderTest = new WordCounter(new WordSplitterStub());
            string sampleSentence = "This|is|the|sample|input|for|the|application";

            // Act
            Dictionary<string, int> output = systemUnderTest.CountWords(sampleSentence);

            // Assert
            Assert.Equal(output["the"], 2);
            Assert.Equal(output["is"], 1);
            Assert.Equal(output["for"], 1);
            Assert.Equal(output["this"], 1);
            Assert.Equal(output["sample"], 1);
            Assert.Equal(output["application"], 1);
        }

        [Fact]
        public void GivenASampleSentence_Then_WeExpectTheCorrectOutput3()
        {
            // Arrange
            var systemUnderTest = new WordCounter(new WordSplitterStub());
            string sampleSentence = "This|is|the|sample|input|for|the|application";

            // Act
            Dictionary<string, int> output = systemUnderTest.CountWords(sampleSentence);

            // Assert
            Assert.Equal(output["the"], 2);
            Assert.Equal(output["is"], 1);
            Assert.Equal(output["for"], 1);
            Assert.Equal(output["this"], 1);
            Assert.Equal(output["sample"], 1);
            Assert.Equal(output["application"], 1);
        }

        [Fact]
        public void When_Mocking()
        {
            // Arrange
            //MOQ
            var mockSplitter = new Mock<IWordSplitter>(MockBehavior.Strict);
            var systemUnderTest = new WordCounter(mockSplitter.Object);
            string sampleSentence = "This|is|the|sample|input|for|the|application";
            mockSplitter.Setup(splitter => splitter.Split(sampleSentence))
                .Returns(new string[] { "application" });

            // Act
            Dictionary<string, int> output = systemUnderTest.CountWords(sampleSentence);

            // Assert
            mockSplitter.VerifyAll();
            mockSplitter.Verify(splitter => splitter.Split(sampleSentence), Times.Exactly(3));
            Assert.Equal(output["application"], 1);

        }

        public class WordSplitterStub : IWordSplitter
        {
            public string[] Split(string input)
            {
                return new [] {
                    "this",
                    "is",
                    "the",
                    "sample",
                    "input",
                    "for",
                    "the",
                    "application",
                };
            }
        }
    }
}
