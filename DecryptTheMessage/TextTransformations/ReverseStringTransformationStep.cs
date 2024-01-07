namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Reverses a string.
    /// </summary>
    internal class ReverseStringTransformationStep : TextTransformationStep
    {
        /// <inheritdoc />
        public override string Transform(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return string.Empty;
            }

            return new string(input.ToCharArray()
                                   .Reverse()
                                   .ToArray());
        }
    }
}
