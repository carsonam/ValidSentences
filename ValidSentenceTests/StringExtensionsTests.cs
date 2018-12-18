using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace System.Tests
{
    [TestClass()]
    public class StringExtensionsTests
    {
        #region Private Fields

        private List<string> invalidSentences = new List<string>() {
            "The quick brown fox said \"hello Mr. lazy dog\".",
            "the quick brown fox said \"hello Mr lazy dog\".",
            "The quick brown fox said \"hello Mr lazy dog.\"",
            "One lazy dog is too few, 12 is too many."
        };

        private List<string> validSentences = new List<string>() {
            "The quick brown fox said \"hello Mr lazy dog\".",
            "The quick brown fox said hello Mr lazy dog.",
            "One lazy dog is too few, 13 is too many.",
            "One lazy dog is too few, thirteen is too many."
        };

        #endregion

        #region Public Methods

        [TestMethod()]
        public void DoesNotEndWithFullStop()
        {
            var sentence = "This is an invalid sentence";
            var isValid = sentence.IsSentenceValid();

            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void DoesntHaveOtherPeriodCharacters()
        {
            var sentence = "This is a valid sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void EndsWithFullStop()
        {
            var sentence = "This is a valid sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void HasEvenQuotationMarks()
        {
            var sentence = "This is a valid \"sentence\".";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void HasOddQuotationMarks()
        {
            var sentence = "This is an invalid \"sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void HasOtherPeriodCharactersWithFullStop()
        {
            var sentence = "This is an invalid. sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void HasOtherPeriodCharactersWithoutFullStop()
        {
            var sentence = "This is an invalid. sentence";
            var isValid = sentence.IsSentenceValid();

            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void NumbersAboveThirteenAreNumbers()
        {
            var sentence = "There are more than 14 test cases.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void NumbersAboveThirteenAreSpeltOut()
        {
            var sentence = "There are more than fourteen test cases.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void NumbersBelowThirteenAreNotSpeltOut()
        {
            var sentence = "This 1 is a valid sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void NumbersBelowThirteenAreSpeltOut()
        {
            var sentence = "This one is a valid sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void SentenceDoesntStartsWithCapital()
        {
            var sentence = "this is an invalid sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsFalse(isValid);
        }

        [TestMethod()]
        public void SentenceStartsWithCapital()
        {
            var sentence = "This is a valid sentence.";
            var isValid = sentence.IsSentenceValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod()]
        public void TestSentencesValidateOrInvalidateCorrectly()
        {
            foreach (var invalidSentence in invalidSentences)
            {
                var isValid = invalidSentence.IsSentenceValid();

                Assert.IsFalse(isValid);
            }

            foreach (var validSentence in validSentences)
            {
                var isValid = validSentence.IsSentenceValid();

                Assert.IsTrue(isValid);
            }
        }

        #endregion
    }
}