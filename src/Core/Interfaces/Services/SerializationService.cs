using Newtonsoft.Json;
using System;

namespace EnduranceContestManager.Core.Interfaces.Services
{
    public class SerializationService : ISerializationService
    {
        public string Serialize(object data)
        {
            var serialized = JsonConvert.SerializeObject(data);
            return serialized;
        }

        public T Deserialize<T>(string serialized)
        {
            var deserialized = JsonConvert.DeserializeObject<T>(serialized);
            return deserialized;
        }

        public object Deserialize(string serialized, Type resultType)
        {
            var deserialized = JsonConvert.DeserializeObject(serialized, resultType);
            return deserialized;
        }
    }
}
