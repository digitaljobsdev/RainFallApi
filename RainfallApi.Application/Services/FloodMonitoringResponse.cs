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
    public string dateTime { get; set; }
    public double value { get; set; }
    // Add other properties as needed
}
