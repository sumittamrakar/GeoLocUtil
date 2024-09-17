# GeoLocUtil
This repo contains a command-line utility that retrieves geolocation data using the OpenWeather Geocoding API. This tool supports querying locations by city/state or ZIP code and returns information such as latitude, longitude, and place name.

## Prerequisites

- .NET 8 SDK or later
- An API key for OpenWeatherMap (included in the code by default, but you should replace it with your own for production use)
- Clone the repo to your local machine
- Use command line prompt or powershell to execute the provided commands

## Installation

1. **Restore Dependencies**

   Navigate to the root directory of the project and run:
   > dotnet restore

2. **Build the Project**

    After restoring dependencies, build the project using:
    > dotnet build

## Running the Utility

To run the GeoLocUtil command-line utility, from the GeoLocUtil folder and run:

> cd GeoLocUtil
> dotnet run "City, State_Code" "zipcode" "Another City, State_Code" "another_zip_code"

## Running the Tests

To run the tests, from the root directory of the project and run:

> dotnet test

Note: Add `--list-tests` flag to command above to see all the available tests (but not run them).