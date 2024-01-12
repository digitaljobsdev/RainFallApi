
using RainfallApi.Core.Entities;
using RainfallApi.Core.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

public class RainfallRepository : IRainfallRepository
{
    private readonly List<RainfallReading> _data; // This is an in-memory implementation

    public RainfallRepository()
    {
        // Initialize data or connect to your data storage
        _data = new List<RainfallReading>
        {
            // Add some sample data
            //new RainfallReading { DateMeasured = DateTime.Now.AddDays(-1), AmountMeasured = 10.5M },
            //new RainfallReading { DateMeasured = DateTime.Now, AmountMeasured = 15.2M }
            // Add more data as needed
        };
    }

    public async Task<IEnumerable<RainfallReading>> GetReadingsAsync(string stationId)
    {
        // Implement logic to retrieve data from your data storage
        // For this example, we're using an in-memory list
        return _data;
    }

    Task<List<RainfallReading>> IRainfallRepository.GetReadingsAsync(string stationId, int count)
    {
        throw new NotImplementedException();
    }
}
