using GeoLocUtil.Services;
using GeoLocUtil.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace GeoLocUtil
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            // setting Dependency Injection (DI) to make GeocodingService easily testable
            var serviceProvider = new ServiceCollection() // Registering GeocodingService
                .AddSingleton<IGeocodingService, GeocodingService>().BuildServiceProvider();

            var geocodingService = serviceProvider.GetService<IGeocodingService>();

            // if no arguments provided
            if (args.Length == 0)
            {
                Console.WriteLine("Missing input: Please provide location inputs in the form of valid 'city, state' or 'zipcode'.");
                return;
            }

            var locations = InputParser.ParseInputLocations(args);
            foreach (var location in locations)
            {
                var result = geocodingService.GetCoordinates(location).Result;
                Console.WriteLine(result); // display results to the user
            }

        }
    }
}
