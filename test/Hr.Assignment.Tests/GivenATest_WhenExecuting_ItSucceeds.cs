using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace Hr.Assignment.Tests
{
    public class WhenExecutingAXUnitTest
    {
        [Fact]
        public void GivenASampleSentence_Then_ShouldReturnCountedWords()
        {
            // Arrange
            string sampleSentence = "This is the sample input for the application";
            var systemUnderTest = new WoordenTeller(new StubWoordenSplitter());

            // Act
            Dictionary<string, int> result = systemUnderTest.CountWords(sampleSentence);

            // Assert
            result["this"].Should().Be(1);
            result["is"].Should().Be(1);
            result["the"].Should().Be(2);
            result["sample"].Should().Be(1);
            result["input"].Should().Be(1);
            result["for"].Should().Be(1);
            result["application"].Should().Be(1);
        }

        [Fact]
        public void GivenASampleSentenceCapitalizedDifferently_Then_ShouldReturnCountedWords()
        {
            // Arrange
            string sampleSentence = "ThIs Is ThE SaMpLe InPuT FoR tHe ApPlicatIoN";
            var systemUnderTest = new WoordenTeller(new StubWoordenSplitter());

            // Act
            var result = systemUnderTest.CountWords(sampleSentence);

            // Assert
            result["this"].Should().Be(1);
            result["is"].Should().Be(1);
            result["the"].Should().Be(2);
            result["sample"].Should().Be(1);
            result["input"].Should().Be(1);
            result["for"].Should().Be(1);
            result["application"].Should().Be(1);
        }

        [Fact]
        public void GivenASampleSentenceSplitBySomething_Then_ShouldReturnCountedWords()
        {
            // Arrange
            string sampleSentence = "This|is|the|sample|input|for|the|application";
            var systemUnderTest = new WoordenTeller(new StubWoordenSplitter());

            // Act
            var result = systemUnderTest.CountWords(sampleSentence);

            // Assert
            result["this"].Should().Be(1);
            result["is"].Should().Be(1);
            result["the"].Should().Be(2);
            result["sample"].Should().Be(1);
            result["input"].Should().Be(1);
            result["for"].Should().Be(1);
            result["application"].Should().Be(1);
        }

        [Fact]
        public void StubWoordenTeller()
        {
            // Arrange
            var systemUnderTest = new WoordenTeller(new StubWoordenSplitter());

            // Act
            var result = systemUnderTest.CountWords("sdfghjkl;hgfdssdfghj");

            // Assert
            result["the"].Should().Be(2);
        }

        [Fact]
        public void GivenAMock()
        {
            // Arrange
            string input = "sdfghjkl;hgfdssdfghj";
            var mockSplitter = new Mock<IWoordenSplitter>(MockBehavior.Strict);
            mockSplitter.Setup(splitter => splitter.SplitWords(input)).Returns(new[]
            {
                "this",
                "the",
                "the",
                "the",
                "input",
                "for",
                "the",
            });
            var systemUnderTest = new WoordenTeller(mockSplitter.Object);

            // Act
            var result = systemUnderTest.CountWords(input);

            // Assert
            result["the"].Should().Be(4);
        }

        [Fact]
        public void GivenASentance_Then_ShouldReturnTop5()
        {
            // Arrange
            string sentence = "Building on the previous example, the application should return a list of words sorted decending on occurrence. In addition the list should only return the top-5 list of words.";
            var systemUnderTest = new WoordenTeller(new CaseWoordenSplitter(' ', sentence));

            // Act
            var result = systemUnderTest.CountWords(sentence, 5);

            // Assert
            result.Count.Should().Be(5, "Because are expecting a maximum of 5 words.");
        }

        [Fact]
        public void GivenASentance_Then_ShouldReturnTop5OrdereredByCount()
        {
            // Arrange
            string sentence = "1 2 2 3 3 3 4 4 4 4 5 5 5 5 5 6 6 6 6 6 6";
            var systemUnderTest = new WoordenTeller(new CaseWoordenSplitter(' ', sentence));

            // Act
            var result = systemUnderTest.CountWords(sentence, 5);

            // Assert
            result["6"].Should().Be(6);
            result["5"].Should().Be(5);
            result["4"].Should().Be(4);
            result["3"].Should().Be(3);
            result["2"].Should().Be(2);
            result.Keys.Should().NotContain("1");
        }

        [Fact]
        public void GivenASentence_Then_ShouldReturnTheNumberOfTimesWordWasCountedInSentence()
        {
            // Arrange
            string sentence = "1 2 2 3 3 3 4 4 4 4 5 5 5 5 5 6 6 6 6 6 6";
            var systemUnderTest = new WoordenTeller(new CaseWoordenSplitter(' ', sentence));

            // Act
            int result = systemUnderTest.CountWordInSentence(sentence, "6");

            // Assert
            result.Should().Be(6, "because '6' is counted 6 times");
        }

        [Fact]
        public void GivenASentence_Then_ShouldNotThrowException()
        {
            // Arrange
            string sentence = "1 2 2 3 3 3 4 4 4 4 5 5 5 5 5 6 6 6 6 6 6";
            var systemUnderTest = new WoordenTeller(new CaseWoordenSplitter(' ', sentence));

            // Act
            Action action = () => systemUnderTest.CountWordInSentence(sentence, "0");

            // Assert
            action.ShouldNotThrow<KeyNotFoundException>();
        }

        public void GivenASentence_Then_ShouldReturnZero()
        {
            // Arrange
            string sentence = "1 2 2 3 3 3 4 4 4 4 5 5 5 5 5 6 6 6 6 6 6";
            var systemUnderTest = new WoordenTeller(new CaseWoordenSplitter(' ', sentence));

            // Act
            int result = systemUnderTest.CountWordInSentence(sentence, "0");

            // Assert
            result.Should().Be(0);
        }
    }

    public class CaseWoordenSplitter : IWoordenSplitter
    {
        private readonly char _splitter;
        private readonly string _input;

        public CaseWoordenSplitter(char splitter, string input)
        {
            _splitter = splitter;
            _input = input;
        }

        public string[] SplitWords(string input)
        {
            return _input.ToLower().Split(_splitter);
        }
    }

    public class StubWoordenSplitter : IWoordenSplitter
    {
        public string[] SplitWords(string input)
        {
            return new[]
            {
                "this",
                "the",
                "input",
                "for",
                "sentence",
                "application",
                "sample",
                "is",
                "the",
            };
        }
    }
}
