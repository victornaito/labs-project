using System;
using Newtonsoft.Json;

namespace SharedKernel.Infraestructure.RabbitMQ
{
    public abstract class Event
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public static T ToObject<T>(string json)
        {
            if (string.IsNullOrWhiteSpace(json))
                return default(T);
            
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}