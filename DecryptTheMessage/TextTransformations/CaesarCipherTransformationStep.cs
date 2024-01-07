using DecryptTheMessage.Ciphers;
using System.Text;

namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Abstracts an operation (decode, or encode) that implies using Caesar cipher over an input text.
    /// </summary>
    internal abstract class CaesarCipherTransformationStep : TextTransformationStep
    {
        private readonly string _key;

        /// <summary>
        /// Initializes a new instance of the <see cref="CaesarCipherTransformationStep"/> class.
        /// </summary>
        /// <param name="key">The key to be used for the cipher operation.</param>
        /// <exception cref="ArgumentNullException">Thrown when the key is null or empty.</exception>
        public CaesarCipherTransformationStep(
            string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            EnsureKeyUsesOnlyAlphabetLetters(keyName: nameof(key), keyValue: key);

            Cipher = new CaesarCipher(Constants.Alphabet);
            _key = key;
        }

        /// <summary>
        /// Gets the Caesar cipher.
        /// </summary>
        public CaesarCipher Cipher { get; }

        /// <summary>
        /// Executes the cipher operation (decode, or encode).
        /// Must be overriden by the derived classes in order to specify the operation.
        /// </summary>
        /// <param name="input">The input character.</param>
        /// <param name="shift">The shift to be applied.</param>
        /// <returns>The result character.</returns>
        protected abstract char ApplyCipherOperation(char input, int shift);

        /// <inheritdoc/>
        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            StringBuilder output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                // each letter in the key serves as a shift for the cipher
                // input most likely exceeds the key size
                // a simple way of adjusting the key to the size of the input
                // is to use modulo operator
                char cipher = _key[i % _key.Length];

                int indexOfChiper = Constants.Alphabet.IndexOf(cipher);

                char clearTextChar = ApplyCipherOperation(input[i], indexOfChiper);

                output.Append(clearTextChar);
            }

            return output.ToString();
        }

        /// <summary>
        /// Validates that all the characters from the key are part of the known alphabet.
        /// </summary>
        /// <param name="keyName">The key paramter name.</param>
        /// <param name="keyValue">The key value.</param>
        /// <exception cref="ArgumentException">Thrown if any unknown character found in the key.</exception>
        private static void EnsureKeyUsesOnlyAlphabetLetters(
            string keyName,
            string keyValue)
        {
            StringBuilder nonAlphabeticCharsBuilder = new StringBuilder();
            foreach (char c in keyValue.ToCharArray())
            {
                if (!Constants.Alphabet.Contains(c))
                {
                    nonAlphabeticCharsBuilder.Append(c + ", ");
                }
            }

            if (nonAlphabeticCharsBuilder.Length > 0)
            {
                string nac = nonAlphabeticCharsBuilder.ToString()
                                                      .TrimEnd();
                throw new ArgumentException(
                    $"The key '{keyName}'='{keyValue}' contains the following non-alphabetic characters: {nac}");
            }
        }
    }
}
