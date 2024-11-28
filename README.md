# PhonePad

`PhonePad` is a utility class that simulates the behavior of old mobile phone keypads. It allows processing a sequence of keypresses to produce text.

## Keypad Mapping

| Key | Characters |
| --- | ---------- |
| 0   | (space)    |
| 1   | & ' (      |
| 2   | ABC        |
| 3   | DEF        |
| 4   | GHI        |
| 5   | JKL        |
| 6   | MNO        |
| 7   | PQRS       |
| 8   | TUV        |
| 9   | WXYZ       |

## Key Features

- **Multi-tap Key Input**: Simulates character selection based on multiple keypresses.
- **Special Characters**:
  - `#`: Stops processing and finalizes the output.
  - `*`: Acts as a backspace.
  - (space): Finalizes the current sequence.

## Methods

### `public static string OldPhonePad(string input)`

Processes a sequence of keypresses and returns the resulting text.

#### Parameters

- `input` *(string)*: A string representing the sequence of keypresses.

#### Returns

- *(string)*: The decoded text.

## Code Explanation

### Key Components
- **`keypad` Dictionary:** Maps each digit to its corresponding characters.
- **`GetCharacterFromSequence` Method:**
  - Calculates the character based on the number of keypresses.
  - Handles invalid or empty sequences gracefully.
- **`OldPhonePad` Method:**
  - Iterates through the input string.
  - Processes special characters (`*`, `#`, and spaces).
  - Appends or modifies the result based on input conditions.

### XML Documentation for Code

```csharp
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
```

## Example Usage

```csharp
using System;

class Program
{
    static void Main()
    {
        string result = PhonePad.OldPhonePad("4433555 555666#");
        Console.WriteLine(result); // Output: HELLO
    }
}
```

## Testing

### Running Tests

Run the following command to execute all unit tests:

```bash
dotnet test
```

### Sample Test Cases

| Input                | Output  | Explanation                                                  |
|----------------------|---------|--------------------------------------------------------------|
| `33#`                | `E`     | `33` produces `E`                                            |
| `227*#`              | `B`     | `22` produces `B`, '7' produces 'P', backspace removes it    |
| `4433555 555666#`    | `HELLO` | Complete input decodes to 'HELLO'.                                           |
| ``                   | (empty) | an empty sequence produces nothing.                          |

## Contributing

Contributions are welcome! Submit a pull request or open an issue for improvements or bug fixes.

## License

This project is licensed under the MIT License.

