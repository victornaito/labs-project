using System.Collections.Generic;

namespace Labs.Api.Application.Queries.Dtos
{
    public class WeatherDTO
    {
        public string By { get; set; }
        public bool Valid_key { get; set; }
        public ResultDTO Results { get; set; }
    }

    public class ResultDTO
    {
        public float Temp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string city_name { get; set; }
        public ICollection<ForecastDTO> Forecast { get; set; }

        public class ForecastDTO
        {
            public string Date { get; set; }
            public string Weekday { get; set; }
            public float Max { get; set; }
            public float Min { get; set; }
        }
    }
}