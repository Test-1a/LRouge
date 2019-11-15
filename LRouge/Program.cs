using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace LRouge
{
    class Program
    {
        public static IConfigurationRoot configuration;
        static void Main(string[] args)
        {
            //Create Service Collection
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            //Create Service Provider
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            serviceProvider.GetService<Game>().Run();
            //Game game = new Game(serviceProvider);
            //game.Run();

            Console.WriteLine("Thanks for playing");
            Console.ReadKey();
        }

        private static void ConfigureServices(IServiceCollection serviceCollection)
        {
            //Build Configuration
            configuration = GetConfig();

            //Add access to IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(configuration);
            serviceCollection.AddTransient<Map>();
            serviceCollection.AddTransient<Game>();
           
        }

        private static IConfigurationRoot GetConfig()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }
    }
}
   