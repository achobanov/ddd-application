using System;

namespace EnduranceJudge.Core.Services
{
    public interface ISerializationService
    {
        string Serialize(object data);

        T Deserialize<T>(string serialized);

        object Deserialize(string serialized, Type resultType);
    }
}
