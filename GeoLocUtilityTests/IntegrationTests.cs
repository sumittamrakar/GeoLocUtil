using GeoLocUtility;
using GeoLocUtility.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace GeoLocUtilityTests;

public class IntegrationTests
{
    [Fact]
    public async Task Utility_ValidCityStateAndZip_ShouldReturnValidResults()
    {
        // Arrange
        var application = new Application();
        var args = new string[] { "Madison, WI", "02169" };

        //Act
        var result = await application.Run(args);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.Errors.Count == 0);
        Assert.IsType<List<GeocodingResponse>>(result.ValidResults);

        Assert.Equal(43.074761, result.ValidResults[0].Lat);
        Assert.Equal(-89.3837613, result.ValidResults[0].Lon);
        Assert.Equal("Wisconsin", result.ValidResults[0].State); // State is returned for City input

        Assert.Equal(42.2491, result.ValidResults[1].Lat);
        Assert.Equal(-70.9978, result.ValidResults[1].Lon);
        Assert.Null(result.ValidResults[1].State); // State is NOT returned for zipcode input
    }

    [Theory]
    [InlineData("Boston, MA")]
    [InlineData("Seattle, Washington")]
    [InlineData("97201")]
    public async Task Utility_SingleValidLocation_ShouldReturnValidResult(params string[] args)
    {
        // Arrange
        var application = new Application();

        //Act
        var result = await application.Run(args);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.ValidResults.Count == 1);
        Assert.True(result.Errors.Count == 0);
    }

    [Fact]
    public async Task Utility_MixedValidAndInvalidLocations_ShouldReturnMixedResults()
    {
        // Arrange
        var application = new Application();
        var args = new string[] { "Madison, WI", "InvalidCity, XYZ", "80210", "0216Q", "1111111" };

        //Act
        var result = await application.Run(args);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.ValidResults.Count == 2);  // ensure 2 valid results
        Assert.True(result.Errors.Count == 3); // ensure 3 invalid results
    }

    [Theory]
    [InlineData(null)]
    [InlineData([""])]
    public async Task Utility_NullOrEmptyLocation_ShouldReturnError(params string[] args)
    {
        // Arrange
        var application = new Application();

        //Act
        var result = await application.Run(args);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.ValidResults.Count == 0);
        Assert.True(result.Errors.Count == 1);
        Assert.Contains("No data found for location", result.Errors[0]);
    }

    [Theory]
    [InlineData("00000")]
    [InlineData("123@BCD")]
    [InlineData("Inv@lidCity, XYZB")]
    [InlineData("Portland, 1234")]
    [InlineData("Inv@lidCity, XY", "99999")]
    [InlineData("Inv@lidCity, OR", "00001", "Boston, CC")]
    [InlineData("Inv@lidCity, XY", "12bC456")]
    public async Task Utility_InvalidLocations_ShouldReturnErrors(params string[] args)
    {
        // Arrange
        var application = new Application();

        //Act
        var result = await application.Run(args);

        // Assert
        Assert.NotNull(result);
        Assert.True(result.ValidResults.Count == 0);
        Assert.True(result.Errors.Count > 0);
        Assert.Contains("No data found for location", result.Errors[0]);
    }
}
