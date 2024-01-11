// RainfallApi.Core/Models/ErrorResponse.cs
public class ErrorResponse
{
    public string Message { get; set; }
    public IEnumerable<ErrorDetail> Details { get; set; }
}
