using System.Text;

namespace PhonePad
{
    /// <summary>
    /// A utility class that simulates old phone keypad behavior for text input.
    /// </summary>
    public static class PhonePad
    {
        /// <summary>
        /// The mapping of phone keypad digits to their corresponding characters.
        /// </summary>
        private static readonly Dictionary<char, string> keypad = new Dictionary<char, string>
        {
            { '0', " " },
            { '1', "&'(" },
            { '2', "ABC" },
            { '3', "DEF" },
            { '4', "GHI" },
            { '5', "JKL" },
            { '6', "MNO" },
            { '7', "PQRS" },
            { '8', "TUV" },
            { '9', "WXYZ" }
        };

        /// <summary>
        /// Retrieves a character from a given sequence of keypresses.
        /// </summary>
        /// <param name="sequence">The sequence of keypresses.</param>
        /// <returns>The corresponding character, or '\0' if invalid.</returns>
        private static char GetCharacterFromSequence(string sequence)
        {
            if (string.IsNullOrEmpty(sequence)) return '\0';

            if (keypad.TryGetValue(sequence[0], out string chars))
            {
                int index = (sequence.Length - 1) % chars.Length;
                return chars[index];
            }

            return '\0';
        }

        /// <summary>
        /// Processes a sequence of keypresses and returns the resulting text.
        /// </summary>
        /// <param name="input">The sequence of keypresses.</param>
        /// <returns>The decoded text.</returns>
        public static string OldPhonePad(string input)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            StringBuilder result = new StringBuilder();
            string currentSequence = "";

            foreach (char key in input)
            {
                if (key == '#')
                {
                    // Finalize and stop processing
                    if (currentSequence.Length > 0)
                    {
                        result.Append(GetCharacterFromSequence(currentSequence));
                    }
                    break;
                }
                else if (key == '*')
                {
                    // Handle backspace
                    if (currentSequence.Length > 1)
                    {
                        result.Append(GetCharacterFromSequence(currentSequence.Substring(0, currentSequence.Length - 1)));
                    }
                    currentSequence = "";
                }
                else if (key == ' ')
                {
                    // Reset sequence on space
                    if (currentSequence.Length > 0)
                    {
                        result.Append(GetCharacterFromSequence(currentSequence));
                        currentSequence = "";
                    }
                }
                else
                {
                    // Append to the current sequence
                    if (currentSequence.Length > 0 && currentSequence[0] != key)
                    {
                        result.Append(GetCharacterFromSequence(currentSequence));
                        currentSequence = "";
                    }
                    currentSequence += key;
                }
            }

            return result.ToString();
        }
    }
}