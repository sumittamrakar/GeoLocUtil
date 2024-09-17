namespace GeoLocUtility.Models;

public class GeocodingResponse
{
    public string Name { get; set; }  // location name (city or place)
    public double Lat { get; set; }   // latitude
    public double Lon { get; set; }   // longitude
    public string Country { get; set; } // country code
    public string State { get; set; }  // state abbreviation (only for city/state)
    public string Zip { get; set; }    // zipcode (only for ZIP code API response)

}
