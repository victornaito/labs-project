using System;
namespace SharedKernel.CrossCutting
{
    public static class VariableEnvironments
    {
        public static string WEATHER_API { get; } = Environment.GetEnvironmentVariable("WEATHER_API") ?? "https://api.hgbrasil.com/weather";
        public static string HOST_RABBITMQ { get; } = Environment.GetEnvironmentVariable("HOST_RABBITMQ") ?? "localhost";
    }
}