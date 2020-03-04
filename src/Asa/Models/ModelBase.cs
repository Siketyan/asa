using System;
using System.Text.Json.Serialization;

namespace Asa.Models
{
    public abstract class ModelBase<T> : IModel where T : IModel, new()
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        protected static T Create()
        {
            return new T
            {
                Id = Guid.NewGuid().ToString(),
                CreatedAt = DateTime.Now
            };
        }
    }
}
