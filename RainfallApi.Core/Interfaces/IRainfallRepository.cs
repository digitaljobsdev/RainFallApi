using System.Collections.Generic;
using System.Threading.Tasks;

namespace RainfallApi.Core.Interfaces
{
    public interface IRainfallRepository
    {
        Task<List<Entities.RainfallReading>> GetReadingsAsync(string stationId, int count);
    }
}
