
public interface IRainfallService
{
    Task<RainfallReadingResponse> GetRainfallReadingsAsync(string stationId, int count);
}
