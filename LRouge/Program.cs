using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace LRouge
{
    class Program
    {
        static void Main(string[] args)
        {
          
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            var configuration = builder.Build();
            
            Game game = new Game(configuration);
            game.Run();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }
    }
}
   