# GeoLocUtil
GeoLocUtil is a command-line utility that retrieves geolocation data using the OpenWeather Geocoding API. It supports querying locations by city/state combination or ZIP code, and returns information such as place name, state (for city/state inputs), country, latitude, and longitude.

## Prerequisites

- **[.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)** or later
- An API key for OpenWeatherMap (included in the code by default, but you should replace it with your own for production use)
- Command line prompt or powershell to execute the provided commands

## Folder Structure

```plaintext
GeoLocUtility/
├── GeoLocUtility.csproj    # Project file
├── Program.cs              # Entry point for the application
├── Application.cs          # Main application logic and service configuration
├── Models/
│   └── GeocodingResponse.cs # Data models for API responses
├── Services/
│   └── GeocodingService.cs  # Service to fetch geolocation data from the API
├── Utilities/
│   └── InputParser.cs       # Utility to parse user input (city, state, or ZIP code)
└── README.md             # Project documentation

GeoLocUtilityTests/
├── GeoLocUtilityTests.csproj # Test project file
└── IntegrationTests.cs       # Integration tests for geolocation functionality
```

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

To run the GeoLocUtility command-line utility, from the root directory of the project, run:

> cd GeoLocUtility

> dotnet run "City, State_Code" "zipcode" "Another City, State_Code" "another_zip_code"

+ **Example**
    > dotnet run "Denver, CO" "90210" "New York, NY"

## Running Tests

To run the tests, from the root directory of the project, run:

> dotnet test

+ **List Tests**
    To view available tests without running them, add the `--list-tests` flag:

    > dotnet test --list-tests



## Demo Screen Record
![](GeoLocUtility_Demo.gif)