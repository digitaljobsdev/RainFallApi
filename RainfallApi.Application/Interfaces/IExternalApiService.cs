using System.Threading.Tasks;

namespace RainfallApi.Application.Interfaces
{
    public interface IExternalApiService
    {
        Task<string> GetData(string apiUrl);
    }
}