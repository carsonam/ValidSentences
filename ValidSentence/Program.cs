using System;

namespace ValidSentence
{
    internal class Program
    {
        #region Private Methods

        private static void Main(string[] args)
        {
            try
            {
                while (Console.ReadKey(true).Key != ConsoleKey.Escape)
                {
                    Console.WriteLine("Sentence to validate: ");
                    ValidateSentence(Console.ReadLine().Trim());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException);
            }
        }

        private static void ValidateSentence(string sentenceToValidate)
        {
            if (sentenceToValidate.IsSentenceValid())
            {
                Console.WriteLine("Valid!");
            }
            else
            {
                Console.WriteLine("Invalid!");
            }
        }

        #endregion
    }
}