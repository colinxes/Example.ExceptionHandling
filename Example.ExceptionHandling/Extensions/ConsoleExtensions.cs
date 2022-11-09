namespace Example.ExceptionHandling.Extensions
{
    public static class ConsoleExtensions
    {
        public static bool Confirm(string pQuestion)
        {
            ConsoleKey response;

            do
            {
                Console.Write($"{pQuestion} [y/n] ");
                response = Console.ReadKey(false).Key;

                if (response != ConsoleKey.Enter)
                    Console.WriteLine();
            } while (response != ConsoleKey.Y && response != ConsoleKey.N);

            return (response == ConsoleKey.Y);
        }
    }
}