using System.Text;

namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Replaces a set of characters with a specified string.
    /// </summary>
    internal class ReplaceCharactersWithStringTransformationStep : TextTransformationStep
    {
        private readonly char[] _characters;
        private readonly string _replaceWith;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReplaceCharactersWithStringTransformationStep"/> class.
        /// </summary>
        /// <param name="replaceWith">The replacement string.</param>
        /// <param name="characters">The list of characters to be replaced.</param>
        public ReplaceCharactersWithStringTransformationStep(
            string replaceWith,
            params char[] characters)
        {
            _replaceWith = replaceWith ?? string.Empty;
            _characters = characters;
        }

        /// <inheritdoc/>
        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder(input);
            foreach (char c in _characters)
            {
                output.Replace(c.ToString(), _replaceWith);
            }

            return output.ToString();
        }
    }
}
