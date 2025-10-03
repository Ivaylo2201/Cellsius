namespace Infrastructure.Utilities;

public static class ColorConsole
{
    public static void WriteLine(string message, ConsoleColor color = ConsoleColor.Green)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }
}