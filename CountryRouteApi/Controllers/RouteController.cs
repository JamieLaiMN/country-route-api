using CountryRouteApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CountryRouteApi.Controllers;

[ApiController]
public class RouteController : ControllerBase
{
    private readonly RouteService service;

    public RouteController(RouteService service)
    {
        this.service = service;
    }

    [HttpGet("/{destination}")]
    public ActionResult<string[]> GetRoute(string destination)
    {
        destination = destination.ToUpperInvariant();

        if (destination.Length != 3 || !destination.All(char.IsLetter))
        {
            return BadRequest("Country code must contain exactly three letters.");
        }

        if (!service.IsValidDestination(destination))
        {
            return NotFound($"Country '{destination}' is not supported.");
        }

        return service.FindRoute(destination);
    }
}