namespace Contracts.Extensions
{
    public static class ConsoleHelper
    {
        public static void WriteLine(string format, object arg, ConsoleColor color = default)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(format, arg);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}