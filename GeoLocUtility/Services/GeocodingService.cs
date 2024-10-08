﻿using GeoLocUtility.Models;
using RestSharp;
using System;
using System.Threading.Tasks;

namespace GeoLocUtility.Services;

public class GeocodingService : IGeocodingService
{
    private const string ApiKey = "f897a99d971b5eef57be6fafa0d83239";
    private const string BaseUrl = "http://api.openweathermap.org/geo/1.0/";

    public async Task<GeocodingResponse> GetCoordinates(LocationInputType location)
    {   
        // Create request for getting location information
        var client = new RestClient(BaseUrl);
        RestRequest request;
        try 
        {
            // If given zip code, use zip code endpoint otherwise use city state endpoint
            if (location.IsZipCode)
            {
                var zipEndpoint = $"zip?zip={location.Value}&appid={ApiKey}";

                request = new RestRequest(zipEndpoint, Method.Get);
                // executing request and deserializing the json response into usable object (GeocodingResponse)
                var response = await client.ExecuteAsync<GeocodingResponse>(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return response.Data; // getting first location result from the response
                }
                else
                {
                    Console.WriteLine($" Error: Unable to fetch data from the Geocoding API for zip code {location.Value}. Status Code: {response.StatusCode}\n");
                    return null;
                }
            }
            else
            {
                var cityStateEndpoint = $"direct?q={location.Value},US&limit=1&appid={ApiKey}";
                request = new RestRequest(cityStateEndpoint, Method.Get);

                // executing request and deserializing the json response into usable object (GeocodingResponse)
                var response = await client.ExecuteAsync<GeocodingResponse[]>(request);

                if (response.IsSuccessful && response.Data?.Length > 0)
                {
                    return response.Data[0]; // getting first location result from the response
                }
                else
                {
                    Console.WriteLine($" Error: Unable to fetch data from the Geocoding API for {location.Value}. Status Code: {response.StatusCode}\n");
                    return null;
                }
            }
        }
        catch (Exception e)
        {
            // Handle exceptions
            Console.WriteLine($" An unexpected error occurred: {e.Message}\n");
            return null;
        }
    }  
}
