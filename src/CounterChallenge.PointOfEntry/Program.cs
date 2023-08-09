using System;
using Microsoft.Extensions.DependencyInjection;
using CounterChallenge.Service.UniqueCharacterParser;

namespace CounterChallenge.PointOfEntry
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IUniqueCharacterParserService, RegexUniqueCharacterParserService>()
                .BuildServiceProvider();

            var uniqueCharacterParserService = serviceProvider.GetService<IUniqueCharacterParserService>();

            if (uniqueCharacterParserService == null)
            {
                Console.WriteLine("Could not locate the parser. Exiting from the program.");
                return;
            }

            do
            {
                Console.Write("\nInput: ");
                var input = Console.ReadLine();

                Console.WriteLine($"Output: {uniqueCharacterParserService.Parse(input)}");

                Console.Write("Press any key to continue or [ESC] to exit ...");
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
