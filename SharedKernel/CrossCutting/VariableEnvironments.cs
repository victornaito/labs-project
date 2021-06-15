using System;
namespace SharedKernel.CrossCutting
{
    public static class VariableEnvironments
    {
        public static string WEATHER_API { get; } = Environment.GetEnvironmentVariable("WEATHER_API");
    }
}