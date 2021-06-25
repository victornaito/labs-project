using System.Linq;
using System;
using System.Collections.Generic;
using Labs.Api.Application.Queries.Dtos;
using SharedKernel.Infraestructure.RabbitMQ;
using static Labs.Api.Application.Queries.Dtos.ResultDTO;

namespace Labs.Api.Infraestructure.Events
{
    public class WeatherEvent : Event
    {
        public string By { get; set; }
        public bool Valid_key { get; set; }
        public ResultEvent Results { get; set; }

        internal WeatherDTO ConvertToDTO()
        {
            return new WeatherDTO
            {
                By = By,
                Valid_key = Valid_key,
                Results = new ResultDTO
                {
                    city_name = Results.CityName,
                    Date = Results.Date,
                    Temp = Results.Temp,
                    Time = Results.Time,
                    Forecast = GetForecastList().ToArray()
                }
            };
        }

        private IEnumerable<ForecastDTO> GetForecastList()
        {
            foreach (var forecast in Results.Forecast)
            {
                yield return new ForecastDTO
                {
                    Date = forecast.Date,
                    Max = forecast.Max,
                    Min = forecast.Min,
                    Weekday = forecast.Weekday
                };
            }
        }
    }

    public class ResultEvent
    {
        public float Temp { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string CityName { get; set; }
        public ICollection<ForecastEvent> Forecast { get; set; }

        public class ForecastEvent
        {
            public string Date { get; set; }
            public string Weekday { get; set; }
            public float Max { get; set; }
            public float Min { get; set; }
        }
    }
}