namespace console.Services;

/// <summary>
/// Utility for reading user input from the console.
/// </summary>
public static class InputService
{
    /// <summary>
    /// Writes a prompt to the console and returns the user's input.
    /// Returns <c>null</c> if the input stream is closed.
    /// </summary>
    /// <param name="prompt">The message displayed to the user before reading input.</param>
    public static string? WithPrompt(string prompt)
    {
        Console.WriteLine(prompt);
        return Console.ReadLine();
    }
}