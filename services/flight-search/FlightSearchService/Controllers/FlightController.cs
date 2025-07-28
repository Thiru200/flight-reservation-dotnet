[ApiController]
[Route("api/[controller]")]
public class FlightController : ControllerBase
{
    private readonly IFlightSearchService _flightSearchService;
    public FlightController(IFlightSearchService flightSearchService)
    {
        _flightSearchService = flightSearchService;
    }
    [HttpPost("search")]
    public async Task<IActionResult> SearchFlightAsync([FromBody] FlightSearchRequest request)
    {
        if (request == null)
        {
            return BadRequest("Invalid flight search request.");
        }
        var results = await _flightSearchService.SearchFlightAsync(request);
        if (results == null || results.Count == 0)
        {
            return NotFound("No flights found for the given search criteria.");
        }
        return Ok(results);
    }
}