public interface IFlightSearchService
{
    Task<List<FlightResult>> SearchFlightAsync(FlightSearchRequest request);
}