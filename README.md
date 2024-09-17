# GeoLocUtil
GeoLocUtil is a command-line utility that retrieves geolocation data using the OpenWeather Geocoding API. It supports querying locations by city/state combination or ZIP code, and returns information such as place name, state (for city/state inputs), country, latitude, and longitude.

## Prerequisites

- .NET 8 SDK or later
- An API key for OpenWeatherMap (included in the code by default, but you should replace it with your own for production use)
- Command line prompt or powershell to execute the provided commands

## Installation

1. **Clone the Repository**

    Clone the repository to your local machine.


2. **Restore Dependencies**

   Navigate to the root directory of the project and run:
   > dotnet restore

3. **Build the Project**

    After restoring dependencies, build the project using:
    > dotnet build

## Running the Utility

To run the GeoLocUtil command-line utility, from the GeoLocUtil folder and run:

> cd GeoLocUtil
> dotnet run "City, State_Code" "zipcode" "Another City, State_Code" "another_zip_code"

## Running Tests

To run the tests, from the root directory of the project and run:

> dotnet test

+ **List Tests**
    To view available tests without running them, add the `--list-tests` flag:

    > dotnet test --list-tests