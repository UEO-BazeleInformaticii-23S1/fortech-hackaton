namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Performs a Caesar decode operation.
    /// </summary>
    internal class CaesarDecodeTransformationStep : CaesarCipherTransformationStep
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaesarDecodeTransformationStep"/> class.
        /// </summary>
        /// <param name="key">The key to be used for decoding.</param>
        public CaesarDecodeTransformationStep(string key)
            : base(key)
        {
        }

        /// <summary>
        /// Overriden to specify the ceasar decode operation.
        /// </summary>
        /// <param name="input">The input character (encrypted).</param>
        /// <param name="shift">The shift to be used.</param>
        /// <returns>The decrypted character.</returns>
        protected override char ApplyCipherOperation(char input, int shift)
        {
            return Cipher.Decode(input, shift);
        }
    }
}
