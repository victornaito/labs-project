namespace Labs.Api.Domain.AggregateWeather
{
    public class Weather
    {
        public string By { get; set; }
        public bool Valid_key { get; set; }
        public Result Results { get; set; }
    }
}