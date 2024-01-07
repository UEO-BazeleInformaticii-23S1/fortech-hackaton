namespace DecryptTheMessage.TextTransformations
{
    /// <summary>
    /// Abstracts a text transformation step.
    /// A text transformation is a function that receives an input string as an argument
    /// and produces a transformed text output.
    /// The concrete transformation is up to be specified by each derived class.
    /// </summary>
    internal abstract class TextTransformationStep
    {
        /// <summary>
        /// Applies the text transformation over the specified input and returns the output.
        /// </summary>
        /// <param name="input">The input text.</param>
        /// <returns>The transformed output text.</returns>
        public abstract string Transform(string input);
    }
}
