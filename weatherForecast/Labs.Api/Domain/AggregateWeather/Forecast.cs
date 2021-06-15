namespace Labs.Api.Domain.AggregateWeather
{
    public class Forecast
    {
        public string Date { get; set; }
        public string Weekday { get; set; }
        public float Max { get; set; }
        public float Min { get; set; }
    }
}