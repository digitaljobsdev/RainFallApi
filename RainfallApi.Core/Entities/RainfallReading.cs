namespace RainfallApi.Core.Entities
{
    public class RainfallReading
    {
        public string DateMeasured { get; set; }
        public double AmountMeasured { get; set; }

        public string StationId { get; set; }
    }
}
