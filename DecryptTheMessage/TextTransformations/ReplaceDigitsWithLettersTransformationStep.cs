using System.Text;

namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Replaces digits with corresponding letters.
    /// </summary>
    internal class ReplaceDigitsWithLettersTransformationStep : TextTransformationStep
    {
        /// <inheritdoc/>
        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            char firstLetter = 'A';
            StringBuilder output = new StringBuilder(input);
            for (int digit = 0; digit <= 9; digit++)
            {
                char letter = (char)(firstLetter + digit);
                output.Replace(digit.ToString(), letter.ToString());
            }

            return output.ToString();
        }
    }
}
