namespace DecryptTheMessage.Ciphers
{
    /// <summary>
    /// Implements the Caesar cipher.
    /// </summary>
    internal class CaesarCipher
    {
        private readonly string _alphabet;

        /// <summary>
        /// Initializes a new instance of the <see cref="CaesarCipher"/> class.
        /// </summary>
        /// <param name="alphabet">Represents the known alphabet.</param>
        /// <exception cref="ArgumentNullException">Thrown when the alphabet is null or empty.</exception>
        public CaesarCipher(string alphabet)
        {
            if (string.IsNullOrEmpty(alphabet))
            {
                throw new ArgumentNullException(nameof(alphabet));
            }

            _alphabet = alphabet;
        }

        /// <summary>
        /// Encodes a clear-text character using specified shift.
        /// </summary>
        /// <param name="clearTextChar">The clear-text character.</param>
        /// <param name="shift">The shift to be used.</param>
        /// <returns>The encrypted character.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified character is not part of the known alphabet,
        /// or when the shift is negative.
        /// </exception>
        public char Encode(char clearTextChar, int shift)
        {
            if (!_alphabet.Contains(clearTextChar))
            {
                throw new ArgumentException($"Letter '{clearTextChar}' not contained in the alphabet.");
            }

            if (shift < 0)
            {
                throw new ArgumentException($"Shift '{shift}' must be positive.");
            }

            int indexOfClearTextChar = _alphabet.IndexOf(clearTextChar);

            int substitutionIndex = (indexOfClearTextChar + shift) % _alphabet.Length;

            char encryptedChar = _alphabet[substitutionIndex];

            if (!_alphabet.Contains(encryptedChar))
            {
                // mostly a self-check, Caesar being a substitution cipher
                // must produce an output that is inside the alphabet
                throw new ArgumentException($"Encrypted letter '{encryptedChar}' not contained in the alphabet.");
            }

            return encryptedChar;
        }

        /// <summary>
        /// Decodes an encrypted character using specified shift.
        /// </summary>
        /// <param name="encodedChar">The encrypted character.</param>
        /// <param name="shift">The shift to be used.</param>
        /// <returns>The clear-text character.</returns>
        /// <exception cref="ArgumentException">
        /// Thrown when the specified character is not part of the known alphabet,
        /// or when the shift is negative.
        /// </exception>
        public char Decode(char encodedChar, int shift)
        {
            if (!_alphabet.Contains(encodedChar))
            {
                throw new ArgumentException($"Encrypted letter '{encodedChar}' not contained in the alphabet.");
            }

            if (shift < 0)
            {
                throw new ArgumentException($"Shift '{shift}' must be positive.");
            }

            int indexOfEncodedChar = _alphabet.IndexOf(encodedChar);

            int substitutionIndex = (indexOfEncodedChar - shift) % _alphabet.Length;

            // given the shift may be bigger that the index,
            // we may need to cycle from the beginning a few times
            // till we reach to an index inside the alphabet
            while (substitutionIndex < 0)
            {
                substitutionIndex = _alphabet.Length + substitutionIndex;
            }

            char clearTextChar = _alphabet[substitutionIndex];

            if (!_alphabet.Contains(clearTextChar))
            {
                // mostly a self-check, Caesar being a substitution cipher
                // must produce an output that is inside the alphabet
                throw new ArgumentException($"Clear text letter '{clearTextChar}' not contained in the alphabet.");
            }

            return clearTextChar;
        }
    }
}
