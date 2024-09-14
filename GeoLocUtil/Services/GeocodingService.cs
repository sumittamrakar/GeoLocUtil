using GeoLocUtil.Models;
using RestSharp;
using System.Threading.Tasks;

namespace GeoLocUtil.Services
{
    public class GeocodingService : IGeocodingService
    {
        private const string ApiKey = "f897a99d971b5eef57be6fafa0d83239";
        private const string BaseUrl = "http://api.openweathermap.org/geo/1.0/";

        public async Task<string> GetCoordinates(LocationInputType location)
        {
            var zipEndpoint = $"zip?zip={location.Value}&appid={ApiKey}";
            var cityStateEndpoint = $"direct?q={location.Value},US&limit=1&appid={ApiKey}"; // TODO: parameterize limit

            // Create request for getting location information
            var client = new RestClient(BaseUrl);
            RestRequest request;

            // If given zip code, use zip code endpoint otherwise use city state endpoint
            if (location.IsZipCode)
            {
                request = new RestRequest(zipEndpoint, Method.Get);
                // executing request and deserializing the json response into usable object (GeocodingResponse)
                var response = await client.ExecuteAsync<ZipResponse>(request);

                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    var place = response.Data; // getting first location result from the response
                    return $"Location: {place.Name}, Latitude: {place.Lat}, Longitude: {place.Lon}";
                }
            }
            else
            {
                request = new RestRequest(cityStateEndpoint, Method.Get);

                // executing request and deserializing the json response into usable object (GeocodingResponse)
                var response = await client.ExecuteAsync<CityResponse[]>(request);

                if (response.IsSuccessful && response.Data?.Length > 0)
                {
                    var place = response.Data[0]; // getting first location result from the response
                    return $"Location: {place.Name}, Latitude: {place.Lat}, Longitude: {place.Lon}";
                }
            }

            // if no data returned from the API, return error message 
            return $"No data found for the given location: {location.Value}. Please enter valid US location.";
        }  
    }
}
