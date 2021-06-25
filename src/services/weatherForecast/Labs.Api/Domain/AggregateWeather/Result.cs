using System.Collections.Generic;

namespace Labs.Api.Domain.AggregateWeather
{
    public class Result
    {
        public float Temp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string city_name { get; set; }
        public List<Forecast> Forecast { get; set; }
    }
}