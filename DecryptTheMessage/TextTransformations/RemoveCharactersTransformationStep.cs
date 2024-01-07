namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Removes a set of characters.
    /// </summary>
    internal class RemoveCharactersTransformationStep
        : ReplaceCharactersWithStringTransformationStep
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RemoveCharactersTransformationStep"/> class.
        /// </summary>
        /// <param name="characters">The characters to be removed.</param>
        public RemoveCharactersTransformationStep(params char[] characters)
            : base(string.Empty, characters)
        {
        }
    }
}
