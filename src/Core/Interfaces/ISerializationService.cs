using EnduranceContestManager.Core.ConventionalServices;
using System;

namespace EnduranceContestManager.Core.Interfaces
{
    public interface ISerializationService : IService
    {
        string Serialize<T>(T data);

        string Serialize(object data, Type dataType);

        T Deserialize<T>(string serialized);

        object Deserialize(string serialized, Type resultType);
    }
}