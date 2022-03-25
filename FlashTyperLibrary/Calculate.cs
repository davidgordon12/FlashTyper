using System;

namespace FlashTyperLibrary
{
    public class Calculate
    {
        public static decimal Accuracy(char[] words, char[] input)
        {
            decimal finalAccuracy;
            decimal totalLetter = words.Length;
            decimal correctLetter = 0;

            for (int i = 0; i < totalLetter; i++)
            {
                try
                {
                    if (words[i] == input[i])
                    {
                        correctLetter++;
                    }
                }
                catch(IndexOutOfRangeException)
                {
                    
                }
            }

            finalAccuracy = Convert.ToDecimal(correctLetter / totalLetter) * 100;

            return finalAccuracy;
        }

        public static int WPM(string[] typedWords, float time)
        {
            return 0;
        }
    }
}
