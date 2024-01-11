// Create these classes in the RainfallApi.Application.Services namespace or adjust the namespace accordingly

public class FloodMonitoringResponse
{
    public List<Item> Items { get; set; }
    // Add other properties as needed
}

public class Item
{
    public LatestReading LatestReading { get; set; }
    // Add other properties as needed
}

public class LatestReading
{
    public string Date { get; set; }
    public double Value { get; set; }
    // Add other properties as needed
}
