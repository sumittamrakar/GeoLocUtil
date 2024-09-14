using System;
using System.Collections.Generic;
using System.Text;

namespace GeoLocUtil.Models
{
    public class BaseResponse
    {
        public string Name { get; set; }  // location name (city or place)
        public double Lat { get; set; }   // latitude
        public double Lon { get; set; }   // longitude
        public string Country { get; set; } // country code
    }

    public class CityResponse : BaseResponse
    {
        public string State { get; set; }  // state abbreviation (only for city/state)
    }

    public class ZipResponse : BaseResponse
    {
        public string Zip { get; set; }    // zipcode (only for ZIP code API response)
    }
}
