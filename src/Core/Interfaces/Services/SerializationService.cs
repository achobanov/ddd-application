using System;
using System.Text.Json;

namespace EnduranceContestManager.Core.Interfaces.Services
{
    public class SerializationService : ISerializationService
    {
        public string Serialize<T>(T data)
        {
            var serialized = JsonSerializer.Serialize(data);
            return serialized;
        }

        public string Serialize(object data, Type dataType)
        {
            var serialized = JsonSerializer.Serialize(data, dataType);
            return serialized;
        }

        public T Deserialize<T>(string serialized)
        {
            var deserialized = JsonSerializer.Deserialize<T>(serialized);
            return deserialized;
        }

        public object Deserialize(string serialized, Type resultType)
        {
            var deserialized = JsonSerializer.Deserialize(serialized, resultType);
            return deserialized;
        }
    }
}