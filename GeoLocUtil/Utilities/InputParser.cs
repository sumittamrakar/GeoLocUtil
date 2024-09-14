using GeoLocUtil.Models;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace GeoLocUtil.Utilities
{
    public class InputParser
    {
        public static List<LocationInputType> ParseInputLocations(string[] args)
        {
            var locations = new List<LocationInputType>();
            var zipCodePattern = new Regex(@"^\d{5}$"); // regex pattern to identify ZIP codes)

            var arguments = args;

            foreach (var arg in arguments)
            {
                Console.WriteLine($"The input argument is: {arg}");
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
}
