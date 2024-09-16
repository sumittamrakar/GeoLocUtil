using GeoLocUtil.Models;
using GeoLocUtil.Services;
using GeoLocUtil.Utilities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeoLocUtil;

public class ResultWrapper
{
    public List<BaseResponse> ValidResults { get; set; } = new List<BaseResponse>();
    public List<string> Errors { get; set; } = new List<string>();
}

public class Application
{
    private readonly IGeocodingService _geocodingService;
    private readonly IInputParser _inputParser;

    public Application()
    {
        var serviceProvider = ConfigureServices();
        _geocodingService = serviceProvider.GetRequiredService<IGeocodingService>();
        _inputParser = serviceProvider.GetRequiredService<IInputParser>();
    }

    public async Task<ResultWrapper> Run(string[] args)
    {
        var resultWrapper = new ResultWrapper();

        // if no arguments provided
        if (args == null || args.Length == 0)
        {
            var errorMessage = $"No data found for location. Please provide location inputs in the form of valid 'city, state' or 'zipcode'.";
            resultWrapper.Errors.Add(errorMessage);
            Console.WriteLine(errorMessage);
            return resultWrapper;
        }

        var locations = _inputParser.ParseInputLocations(args);
        if (locations.Count == 0)
        {
            // Add an error message for the empty location
            var errorMessage = $"No data found for location. Please provide location inputs in the form of valid US 'city, state' combination or 'zipcode'.";
            resultWrapper.Errors.Add(errorMessage);
            Console.WriteLine(errorMessage);
        }

        foreach (var location in locations)
        {
            Console.WriteLine($"The input argument is: {location.Value}");
            var result = await _geocodingService.GetCoordinates(location);
            if (result != null)
            {
                resultWrapper.ValidResults.Add(result);
                // print results for user
                Console.WriteLine($" Location: {result.Name}\n Country: {result.Country}\n Latitude: {result.Lat}\n Longitude: {result.Lon}");
            }
            else
            {
                // Add an error message for the invalid location
                var errorMessage = $"Error: No data found for location: {location.Value}";
                resultWrapper.Errors.Add(errorMessage);
                Console.WriteLine(errorMessage);
            }
        }
        return resultWrapper;
    }

    private IServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        // Register dependencies
        services.AddSingleton<IInputParser, InputParser>();
        services.AddSingleton<IGeocodingService, GeocodingService>();

        return services.BuildServiceProvider();
    }
}
