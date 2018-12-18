using System.Linq;

namespace System
{
    public static class StringExtensions
    {
        #region Public Methods

        public static bool IsSentenceValid(this string sentence)
        {
            if (string.IsNullOrWhiteSpace(sentence)) return false;
            if (!sentence.IsFirstLetterCapitalised()) return false;
            if (!sentence.HasEvenNumberOfQuotationMarks()) return false;
            if (!sentence.HasCorrectPeriodCharacters()) return false;
            if (!sentence.AreNumbersSpelledOut()) return false;
            else return true;
        }

        #endregion

        #region Private Methods

        private static bool AreNumbersSpelledOut(this string sentence)
        {
            var wordsInSentence = sentence.Split(' ');

            foreach (var word in wordsInSentence)
            {
                var punctuationRemovedFromWord = new string(word.Where(c => !char.IsPunctuation(c)).ToArray());

                if (int.TryParse(punctuationRemovedFromWord, out int wordAsInt))
                {
                    if (wordAsInt < 13)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static int GetCharacterCount(string sentence, char charToCount)
        {
            int charCount = 0;
            var charArray = sentence.ToCharArray().ToList();
            if (!charArray.Contains(charToCount)) return charCount;

            for (int i = 0; i < sentence.Length; i++)
            {
                if (charArray[i] == charToCount)
                {
                    charCount++;
                }
            }

            return charCount;
        }

        private static bool HasCorrectPeriodCharacters(this string sentence)
        {
            var isLastLetterPeriodChar = sentence.EndsWith(".");
            var fullStopCount = GetCharacterCount(sentence, '.');
            return isLastLetterPeriodChar && fullStopCount == 1;
        }

        private static bool HasEvenNumberOfQuotationMarks(this string sentence)
        {
            return GetCharacterCount(sentence, '"') % 2 == 0;
        }

        private static bool IsFirstLetterCapitalised(this string sentence)
        {
            char firstLetter = sentence[0];
            return char.IsLetter(firstLetter) && firstLetter == char.ToUpper(firstLetter);
        }

        #endregion
    }
}