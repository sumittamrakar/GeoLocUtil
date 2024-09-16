# GeoLocUtil
This repo contains a command-line utility that retrieves geolocation data using the OpenWeather Geocoding API. This tool supports querying locations by city/state or ZIP code and returns information such as latitude, longitude, and place name.

## Prerequisites

- .NET 8 SDK or later
- An API key for OpenWeatherMap (included in the code by default, but you should replace it with your own for production use)
- Use command line prompt or powershell to execute the provided commands

## Installation

1. **Restore Dependencies**

   Navigate to the root directory of the project and run:
   > dotnet restore

2. **Build the Project**

    After restoring dependencies, build the project using:
    > dotnet build

## Running the Utility

To run the GeoLocUtil command-line utility, from the , use the following syntax:

dotnet run --locations "City, ST" "ZIP_CODE" "Another City, ST" "ANOTHER_ZIP_CODE"