using GeoLocUtil.Models;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeoLocUtil.Utilities;

public interface IInputParser
{
    List<LocationInputType> ParseInputLocations(string[] args);
}

public class InputParser : IInputParser
{
    public List<LocationInputType> ParseInputLocations(string[] args)
    {
        var locations = new List<LocationInputType>();
        var zipCodePattern = new Regex(@"^\d{5}$"); // regex pattern to identify five digit ZIP codes)

        var arguments = args;

        foreach (var arg in arguments)
        {
            // check if input is zip pattern
            if (zipCodePattern.IsMatch(arg))
            {
                locations.Add(new LocationInputType
                {
                    Value = arg,
                    IsZipCode = true
                });
            }
            else
            {
                if (!string.IsNullOrEmpty(arg))
                {
                    locations.Add(new LocationInputType
                    {
                        Value = arg,
                        IsZipCode = false
                    });
                }
            }
        }
        return locations;
    }
}
