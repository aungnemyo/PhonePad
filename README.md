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
