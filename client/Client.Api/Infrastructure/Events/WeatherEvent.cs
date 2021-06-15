using System.Collections.Generic;
using SharedKernel.Infraestructure.RabbitMQ;

namespace Cliente.Api.Infrastructure.Events
{
    public class WeatherEvent : Event
    {
        public WeatherEvent()
        {
        }

        public WeatherEvent(string json)
        {
            var weather = ToObject<WeatherEvent>(json);
            By = weather.By;
            Valid_key = weather.Valid_key;
            Results = weather.Results;
        }

        public string By { get; set; }
        public bool Valid_key { get; set; }
        public Result Results { get; set; }

        public class Result
        {
            public float Temp { get; set; }
            public string Date { get; set; }
            public string Time { get; set; }
            public string city_name { get; set; }
            public List<ForecastDto> Forecast { get; set; }

            public class ForecastDto
            {
                public string Date { get; set; }
                public string Weekday { get; set; }
                public float Max { get; set; }
                public float Min { get; set; }
            }
        }
    }
}