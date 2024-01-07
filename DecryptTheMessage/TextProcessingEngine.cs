using DecryptTheMessage.TextTransformations;

namespace DecryptTheMessage
{
    /// <summary>
    /// Represents a text processing engine.
    /// </summary>
    internal static class TextProcessingEngine
    {
        /// <summary>
        /// Executes a set of transformation steps over the specified input
        /// in order to produce a transformed output.
        /// </summary>
        /// <param name="input">The original input string.</param>
        /// <param name="steps">The set of text transformation steps.</param>
        /// <returns>The result output text.</returns>
        public static string Execute(string input, params TextTransformationStep[] steps)
        {
            string result = input;
            foreach (TextTransformationStep step in steps)
            {
                result = step.Transform(result);
                // Console.WriteLine($"After applying step {step.GetType()}: {result}");
            }

            return result;
        }
    }
}
