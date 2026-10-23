namespace CountryRouteApi.Tests;

public class RouteServiceTests
{
    private readonly RouteService service;

    public RouteServiceTests() 
    {
        BorderData borderData = new BorderData();
        service = new RouteService(borderData);
    }

    [Fact]
    public void FindRoute_ToBelize_ReturnsExpectedRoute() 
    {
        string[] result = service.FindRoute("BLZ");

        string[] expected = { "USA", "MEX", "BLZ" };

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindRoute_ToPanama_ReturnsExpectedRoute() 
    {
        string[] result = service.FindRoute("PAN");

        string[] expected = { "USA", "MEX", "GTM", "HND", "NIC", "CRI", "PAN" };

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindRoute_ToCanada_ReturnsDirectRoute()
    {
        string[] result = service.FindRoute("CAN");

        string[] expected = { "USA", "CAN" };

        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindRoute_ToUSA_ReturnsOnlyUSA()
    {
        string[] result = service.FindRoute("USA");

        string[] expected = { "USA" };

        Assert.Equal(expected, result);
    }

    [Fact]
    public void IsValidDestination_WithSupportedCountry_ReturnsTrue()
    {
        bool result = service.IsValidDestination("PAN");

        Assert.True(result);
    }

    [Fact]
    public void IsValidDestination_WithUnsupportedCountry_ReturnsFalse()
    {
        bool result = service.IsValidDestination("ABC");

        Assert.False(result);
    }
}
