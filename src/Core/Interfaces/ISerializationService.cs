using EnduranceJudge.Core.ConventionalServices;
using System;

namespace EnduranceJudge.Core.Interfaces
{
    public interface ISerializationService : IService
    {
        string Serialize(object data);

        T Deserialize<T>(string serialized);

        object Deserialize(string serialized, Type resultType);
    }
}
